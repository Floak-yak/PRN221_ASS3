using CandidateManagement_BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace CandidateManagement_DAOs
{
    public class JobPostingDAO
    {
        static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }
        internal static List<JobPosting> ReadData()
        {
            List<JobPosting> jobPostings = new();
            var jobJSON = ReadFile("Data/jobposting.json");
            jobPostings.AddRange(JsonConvert.DeserializeObject<List<JobPosting>>(jobJSON));
            return jobPostings;
        }

        public void writeJson(List<JobPosting> jobPostings)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            string jsonData = System.Text.Json.JsonSerializer.Serialize(jobPostings, options);
            // Write the JSON string to a file
            File.WriteAllText("Data/jobposting.json", jsonData);
        }

        private static JobPostingDAO instance;

        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }

        public JobPostingDAO()
        {
        }

        public bool addJostPosting(JobPosting jobPosting)
        {
            var jobPostingsList = ReadData();
            jobPostingsList.Add(jobPosting);
            writeJson(jobPostingsList);
            return true;
        }

        public JobPosting GetJobPosting(string Id)
        {
            var accounts = ReadData();
            foreach (var item in accounts)
            {
                if (item.PostingId == Id) { return item; }
            }
            return null;
        }

        public List<JobPosting> GetJobPostings()
        {
            return ReadData();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            var jobPostingsList = ReadData();
            JobPosting jobPostingRe = new JobPosting();
            foreach (var item in jobPostingsList)
            {
                if (item.PostingId == jobPosting.PostingId)
                {
                    jobPostingRe = item;
                }
            }
            jobPostingsList.Remove(jobPostingRe);
            jobPostingsList.Add(jobPosting);
            writeJson(jobPostingsList);
            return true;
        }

        public bool DeleteJobPosting(string ID)
        {
            var jobPostingsList = ReadData();
            JobPosting jobPostingRe = new JobPosting();
            foreach (var item in jobPostingsList)
            {
                if (item.PostingId == ID)
                {
                    jobPostingRe = item;
                    
                }
            }
            jobPostingsList.Remove(jobPostingRe);
            writeJson(jobPostingsList);
            return true;
        }
    }
}
