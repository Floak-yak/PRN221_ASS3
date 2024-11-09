using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BussinessObject.Models;
using CandidateManagement_DAOs;
using CandidateManagement_Repositories;

namespace CandidateManagement_PhamHoangKhiem.Pages.CandidateProfilePage
{
    public class EditModel : PageModel
    {
        private ICandidateRepository _candidateRepository;
        private IJobPostingRepository _jobPostingRepository;

        public EditModel(ICandidateRepository candidateRepository, IJobPostingRepository jobPostingRepository)
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
            CandidateProfile = candidateprofile;
            ViewData["PostingId"] = new SelectList(_jobPostingRepository.GetJobPostings(), "PostingId", "PostingId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(CandidateProfile).State = EntityState.Modified;

            try
            {
                _candidateRepository.UpdateCandidate(CandidateProfile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateProfileExists(CandidateProfile.CandidateId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandidateProfileExists(string id)
        {
            return (_candidateRepository.GetCandidateProfileById(id) == null);
        }
    }
}
