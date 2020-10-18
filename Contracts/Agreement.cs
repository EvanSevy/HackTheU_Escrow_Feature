using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Contracts
{
    public class Agreement
    {
        public int Agreement_Id { get; set; }
        public string Agreement_Type { get; set; }
        public string Agreement_Url { get; set; }
        public string Agreement_Version { get; set; }
    }
}
