using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BussinessObject.Models;
using CandidateManagement_DAOs;
using CandidateManagement_Repositories;

namespace CandidateManagement_PhamHoangKhiem.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {

        ICandidateRepository _candidateRepository;
        public IndexModel(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public IList<CandidateProfile> CandidateProfile { get; set; } = default!;

        public async Task OnGetAsync()
        {
            CandidateProfile = _candidateRepository.GetCandidateProfiles();
        }
    }
}
