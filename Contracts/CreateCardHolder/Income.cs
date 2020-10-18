using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Contracts.CreateCardHolder
{
    public class Income
    {
        public string Amount { get; set; }
        public string Frequency { get; set; }
        public string Occupation { get; set; }
        public string Source { get; set; }
    }
}
