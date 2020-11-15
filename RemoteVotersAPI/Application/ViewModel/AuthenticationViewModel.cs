using System.ComponentModel.DataAnnotations;

namespace remotevotersapi.Application.ViewModel
{
    /// <summary>
    /// Authentication View Model
    ///
    /// Author: FStrony
    /// </summary>
    public class AuthenticationViewModel
    {
        /// <value>Email</value>
        [Required(ErrorMessage = "E-mail is mandatory!")]
        public string Email { get; set; }

        /// <value>Password</value>
        [Required(ErrorMessage = "Password is mandatory!")]
        public string Password { get; set; }
    }
}
