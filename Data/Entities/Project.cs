using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public User Creator { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double MoneyThresholdForRelease { get; set; }
        public double CurrentMoneyDonated { get; set; }
        public User MoneyTrustee { get; set; }
        public GalileoAccount GalileoAccount { get; set; }
    }
}
