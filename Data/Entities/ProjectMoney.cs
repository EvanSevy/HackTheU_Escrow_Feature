using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Data.Entities
{
    public class ProjectMoney
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public double MoneyForProject { get; set; }
    }
}
