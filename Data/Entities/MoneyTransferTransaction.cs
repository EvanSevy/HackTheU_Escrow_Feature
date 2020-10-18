using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Data.Entities
{
    public class MoneyTransferTransaction
    {
        public int Id { get; set; }
        public string SenderAccountId { get; set; }
        public string ReceiverAccountId { get; set; }
        public double Amt { get; set; }
    }
}
