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
    public class DeleteModel : PageModel
    {
        private ICandidateRepository _candidateRepository;
        private IJobPostingRepository _jobPostingRepository;

        public DeleteModel(ICandidateRepository candidateRepository, IJobPostingRepository jobPostingRepository)
        {
            _candidateRepository = candidateRepository;
            _jobPostingRepository = jobPostingRepository;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateRepository.GetCandidateProfileById(id);

            if (candidateprofile == null)
            {
                return NotFound();
            }
            else
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var candidateprofile = _candidateRepository.GetCandidateProfileById(id);

            if (candidateprofile != null)
            {
                CandidateProfile = candidateprofile;
                _candidateRepository.DeleteCandidate(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
