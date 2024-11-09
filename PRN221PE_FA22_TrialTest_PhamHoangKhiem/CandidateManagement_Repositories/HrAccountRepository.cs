using CandidateManagement_BussinessObject.Models;
using CandidateManagement_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public class HrAccountRepository : IHrAccountRepository
    {
        public Hraccount GetHraccount(string email) => HraccountDAO.Instance.GetAccount(email);
    }
}
