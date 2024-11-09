using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement_BussinessObject.Models;
using CandidateManagement_DAOs;
using CandidateManagement_Repositories;

namespace CandidateManagement_PhamHoangKhiem.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private ICandidateRepository _candidateRepository;
        private IJobPostingRepository _jobPostingRepository;

        public CreateModel(ICandidateRepository candidateRepository, IJobPostingRepository jobPostingRepository)
        {
            _candidateRepository = candidateRepository;
            _jobPostingRepository = jobPostingRepository;
        }

        public IActionResult OnGet()
        {
            ViewData["PostingId"] = new SelectList(_jobPostingRepository.GetJobPostings(), "PostingId", "PostingId");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _candidateRepository.CreateCandidate(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
