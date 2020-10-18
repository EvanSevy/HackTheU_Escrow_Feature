using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Data.Entities
{
    public class GalileoAccount
    {
        public GalileoAccount()
        {
            TransactionHistory = new List<MoneyTransferTransaction>();
        }
        public int Id { get; set; }
        public string CardholderId { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public ICollection<MoneyTransferTransaction> TransactionHistory { get; set; }
    }
}
