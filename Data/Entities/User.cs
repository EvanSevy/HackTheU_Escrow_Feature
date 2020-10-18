using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            ProjectCreations = new List<Project>();
            MoneyForProjects = new List<ProjectMoney>();
        }
        public GalileoAccount GalileoAccount { get; set; }
        public ICollection<Project> ProjectCreations { get; set; }
        public ICollection<ProjectMoney> MoneyForProjects { get; set; }
    }
}
