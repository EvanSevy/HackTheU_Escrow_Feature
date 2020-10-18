using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Data
{
    public interface IEscrowAccountRepository
    {
        Task<bool> CreateUser(string username);
    }
}
