using CandidateManagement_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_PhamHoangKhiem.Pages
{
    public class LoginModel : PageModel
    {
        private IHrAccountRepository _hrAccountRepository;
        public LoginModel(IHrAccountRepository hrAccountRepository)
        {
            _hrAccountRepository = hrAccountRepository;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string email = Request.Form["txtEmail"];
            string password = Request.Form["txtPassword"];

            var account = _hrAccountRepository.GetHraccount(email);

            if (account != null && account.Password.Equals(password) && account.MemberRole == 2)
            {
                int? roleID = account.MemberRole;
                HttpContext.Session.SetString("RoleID", roleID.ToString());
                Response.Redirect("/CandidateProfilePage/Index");
            }
            else
            {
                Response.Redirect("/PermissionDenyPage");
            }
        }
    }
}
