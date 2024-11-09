using CandidateManagement_BussinessObject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAOs
{
    public class HraccountDAO
    {
        static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }
        internal static List<Hraccount> ReadData()
        {
            List<Hraccount> accounts = new();
            var cadJSON = ReadFile("Data/hraccount.json");
            accounts.AddRange(JsonConvert.DeserializeObject<List<Hraccount>>(cadJSON));
            return accounts;
        }
        private static HraccountDAO instance = null;

        public HraccountDAO()
        {
        }

        public static HraccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HraccountDAO();
                }
                return instance;
            }
        }

        public Hraccount GetAccount(string email)
        {
            var accounts = ReadData();
            foreach (var item in accounts)
            {
                if (item.Email == email) { return item; }
            }
            return null;
        }
    }
}
