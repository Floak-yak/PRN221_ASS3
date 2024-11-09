using CandidateManagement_BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public interface IHrAccountRepository
    {
        Hraccount GetHraccount(string email);
    }
}
