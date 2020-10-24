using System;
using System.ComponentModel.DataAnnotations;
using RemoteVotersAPI.Domain.Bases;

namespace RemoteVotersAPI.Application.ViewModel
{
    public class CompanyViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Company Name is mandatory!")]
        public String CompanyName { get; set; }

        [Required(ErrorMessage = "CNPJ is mandatory!")]
        public String Cnpj { get; set; }

        [Required(ErrorMessage = "Address is mandatory!")]
        public String Address1 { get; set; }
        public String Address2 { get; set; }

        [Required(ErrorMessage = "Post Code is mandatory!")]
        public String PostCode { get; set; }

        [Required(ErrorMessage = "State is mandatory!")]
        public String State { get; set; }

        [Required(ErrorMessage = "City is mandatory!")]
        public String City { get; set; }

        [Required(ErrorMessage = "Country is mandatory!")]
        public String Country { get; set; }

        [Required(ErrorMessage = "Email is mandatory!")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Password is mandatory!")]
        public String Password { get; set; }
    }
}
