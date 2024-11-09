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

namespace CandidateManagement_DAOs
{
    public class CandidateProfileDAO
    {
        static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }
        internal static List<CandidateProfile> ReadData()
        {
            List<CandidateProfile> candidates = new();
            var canJSON = ReadFile("Data/candidateprofiles.json");
            candidates.AddRange(JsonConvert.DeserializeObject<List<CandidateProfile>>(canJSON));
            return candidates;
        }
        private static CandidateProfileDAO instance = null;

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public void writeJson(List<CandidateProfile> candidateProfiles)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            string jsonData = System.Text.Json.JsonSerializer.Serialize(candidateProfiles, options);
            // Write the JSON string to a file
            File.WriteAllText("Data/candidateprofiles.json", jsonData);
        }
        public CandidateProfileDAO()
        {
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return ReadData();
        }
        public List<CandidateProfile> GetCandidateProfilesWithPost() => ReadData();
        public CandidateProfile GetCandidateProfileById(string ID)
        {
            foreach (var candidateProfile in ReadData())
            {
                if (candidateProfile.CandidateId == ID)
                {
                    return candidateProfile;
                }
            }
            return null;
        }

        public bool DeleteCandidate(string ID)
        {
            var candidate = ReadData();
            CandidateProfile candi = new CandidateProfile();
            foreach (var item in candidate)
            {
                if (item.CandidateId == ID)
                {
                    candi = item;
                }
            }
            candidate.Remove(candi);
            writeJson(candidate);
            return true;
        }

        public bool UpdateCandidate(CandidateProfile candidate)
        {
            var candidateList = ReadData();
            CandidateProfile candi = new CandidateProfile();
            foreach (var item in candidateList)
            {
                if (item.CandidateId == candidate.CandidateId)
                {
                    candi = item;
                }
            }
            candidateList.Remove(candi);
            candidateList.Add(candidate);
            writeJson(candidateList);
            return true;
        }

        public bool CreateCandidate(CandidateProfile candidate)
        {
            var candidateList = ReadData();
            candidateList.Add(candidate);
            writeJson(candidateList);
            return true;
        }
    }
}
