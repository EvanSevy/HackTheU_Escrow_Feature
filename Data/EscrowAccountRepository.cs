using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using HackTheU_Escrow_Feature.Contracts;
using HackTheU_Escrow_Feature.Contracts.CreateCardHolder;

namespace HackTheU_Escrow_Feature.Data
{
    public class EscrowAccountRepository : IEscrowAccountRepository
    {
        private readonly IConfiguration configuration;

        public EscrowAccountRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<bool> CreateUser(string username)
        {
            var ApiUrl = configuration.GetValue<string>("Galileo:url");

            // Note:  This returns valid tokens
            LoginTokens tokens = await GetTokens();

            // Note:  This returns valid agreements
            AgreementsInfo agreements = await GetAgreements(tokens.Access_Token);

            // Note:  Having trouble with the final POST to actually create the cardholder
            int cardholder_id = await CreateCardHolder(tokens.Access_Token, agreements, username);

            return true;
        }
        public async Task<LoginTokens> GetTokens()
        {
            var ApiUsername = configuration.GetValue<string>("Galileo:username");
            var ApiPassword = configuration.GetValue<string>("Galileo:password");
            var ApiUrl = configuration.GetValue<string>("Galileo:url");

            using (var httpClient = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "username", ApiUsername },
                    { "password", ApiPassword }
                };
                var content = new FormUrlEncodedContent(values);

                var response = await httpClient.PostAsync(ApiUrl + "/login", content);

                var responseString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                LoginTokens tokens = JsonSerializer.Deserialize<LoginTokens>
                    (responseString, options);

                return tokens;
            }
        }
        public async Task<AgreementsInfo> GetAgreements(string accessToken)
        {
            var ApiUrl = configuration.GetValue<string>("Galileo:url");
            var ApiBusinessId = configuration.GetValue<string>("Galileo:business_id");
            var ApiProductId = configuration.GetValue<string>("Galileo:product_id");

            using (var httpClient = new HttpClient())
            {
                ///businesses/{{business_id}}/products/{{product_id}}/agreements
                var urlStr = $"{ApiUrl}/businesses/{ApiBusinessId}/products/{ApiProductId}/agreements";
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
                var response = await httpClient.GetAsync(urlStr);
                var responseString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                AgreementsInfo agreements = JsonSerializer.Deserialize<AgreementsInfo>(responseString, options);
                return agreements;
            }
        }
        public async Task<int> CreateCardHolder(string accessToken, AgreementsInfo agreements, string username)
        {
            var ApiUrl = configuration.GetValue<string>("Galileo:url");
            var ApiProductId = configuration.GetValue<string>("Galileo:product_id");
            using (var httpClient = new HttpClient())
            {
                var values = new CreateCardHolder()
                {
                    CardHolder = new CardHolder()
                    {
                        Address = new Address()
                        {
                            City = "Layton",
                            State = "Utah",
                            Street = "123 St.",
                            Zip_Code = "84040"
                        },
                        Agreements = agreements.Agreements.Select(s => s.Agreement_Id).ToArray(),
                        Email = "Awesome@Email.com",
                        First_Name = username,
                        Identification = new Identification()
                        {
                            Date_Of_Birth = "2000-01-01",
                            Id = "123456222",
                            Id_Type = "ssn"
                        },
                        Income = new Income()
                        {
                            Amount = "u1000000k",
                            Frequency = "biweekly",
                            Occupation = "information_technology",
                            Source = "entrepreneurial"
                        },
                        Last_Name = username,
                        Mobile = "1234567111"
                    },
                    Product_Id = Int32.Parse(ApiProductId)
                };
                string stringData = JsonSerializer.Serialize(values);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json"); ;

                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                // To Do:  Left off here: Having trouble with this Post not returning an error...
                var response = await httpClient.PostAsync(ApiUrl + "/cardholders", contentData);
                //var response = await httpClient.PostAsync(ApiUrl + "/cardholders", values, new JsonMediaTypeFormatter());
                //HttpResponseMessage response = httpClient.PutAsync(ApiUrl, contentData).Result;

                var responseContent = response.Content;

                var responseInt = JsonSerializer.Deserialize<CardHolderId>(response.Content.ReadAsStringAsync().Result);
                return responseInt.Cardholder_Id;
            }
        }
    }
}
