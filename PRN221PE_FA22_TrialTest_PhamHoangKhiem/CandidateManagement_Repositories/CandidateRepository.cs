using CandidateManagement_BussinessObject.Models;
using CandidateManagement_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        public bool CreateCandidate(CandidateProfile candidate)
        {
            return CandidateProfileDAO.Instance.CreateCandidate(candidate);
        }

        public bool DeleteCandidate(string ID)
        {
            return CandidateProfileDAO.Instance.DeleteCandidate(ID);
        }

        public CandidateProfile GetCandidateProfileById(string ID)
        {
            return CandidateProfileDAO.Instance.GetCandidateProfileById(ID);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return CandidateProfileDAO.Instance.GetCandidateProfilesWithPost();
        }

        public bool UpdateCandidate(CandidateProfile candidate)
        {
            return CandidateProfileDAO.Instance.UpdateCandidate(candidate);
        }
    }
}
