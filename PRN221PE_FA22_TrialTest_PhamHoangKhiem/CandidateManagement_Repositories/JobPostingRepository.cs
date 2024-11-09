using CandidateManagement_BussinessObject.Models;
using CandidateManagement_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public class JobPostingRepository : IJobPostingRepository
    {
        public bool addJostPosting(JobPosting jobPosting)
        {
            return JobPostingDAO.Instance.addJostPosting(jobPosting);
        }

        public bool DeleteJobPosting(string ID)
        {
            return JobPostingDAO.Instance.DeleteJobPosting(ID);
        }

        public JobPosting GetJobPosting(string Id)
        {
            return JobPostingDAO.Instance.GetJobPosting(Id);
        }

        public List<JobPosting> GetJobPostings()
        {
            return JobPostingDAO.Instance.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return JobPostingDAO.Instance.UpdateJobPosting(jobPosting);
        }
    }
}
