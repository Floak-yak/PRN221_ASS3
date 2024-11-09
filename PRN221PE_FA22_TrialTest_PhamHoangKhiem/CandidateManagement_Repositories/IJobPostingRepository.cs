using CandidateManagement_BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public interface IJobPostingRepository
    {
        bool DeleteJobPosting(string ID);
        bool UpdateJobPosting(JobPosting jobPosting);
        bool addJostPosting(JobPosting jobPosting);
        JobPosting GetJobPosting(string Id);
        List<JobPosting> GetJobPostings();
    }
}
