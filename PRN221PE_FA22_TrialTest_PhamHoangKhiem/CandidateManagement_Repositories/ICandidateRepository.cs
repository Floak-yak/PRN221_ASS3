using CandidateManagement_BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public interface ICandidateRepository
    {
        public List<CandidateProfile> GetCandidateProfiles();
        public CandidateProfile GetCandidateProfileById(string ID);
        public bool DeleteCandidate(string ID);
        public bool UpdateCandidate(CandidateProfile candidate);
        public bool CreateCandidate(CandidateProfile candidate);
    }
}
