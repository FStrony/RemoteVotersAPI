using System;
using System.ComponentModel.DataAnnotations;
using remotevotersapi.Domain.Bases;

namespace remotevotersapi.Application.ViewModel
{
    /// <summary>
    /// Company View Model
    ///
    /// Author: FStrony
    /// </summary>
    public class CompanyViewModel : BaseEntity
    {
        /// <value>Company Name </value>
        [Required(ErrorMessage = "Company Name is mandatory!")]
        public String CompanyName { get; set; }

        /// <value>Company's CNPJ</value>
        [Required(ErrorMessage = "CNPJ is mandatory!")]
        public String Cnpj { get; set; }

        /// <value>Company's Address</value>
        [Required(ErrorMessage = "Address is mandatory!")]
        public String Address1 { get; set; }
        public String Address2 { get; set; }

        /// <value>Company's PostCode</value>
        [Required(ErrorMessage = "Post Code is mandatory!")]
        public String PostCode { get; set; }

        /// <value>Company's State</value>
        [Required(ErrorMessage = "State is mandatory!")]
        public String State { get; set; }

        /// <value>Company's City</value>
        [Required(ErrorMessage = "City is mandatory!")]
        public String City { get; set; }

        /// <value>Company's Country</value>
        [Required(ErrorMessage = "Country is mandatory!")]
        public String Country { get; set; }

        /// <value>Company's Email</value>
        [Required(ErrorMessage = "Email is mandatory!")]
        public String Email { get; set; }

        /// <value>Company's Password</value>
        [Required(ErrorMessage = "Password is mandatory!")]
        public String Password { get; set; }
    }
}
