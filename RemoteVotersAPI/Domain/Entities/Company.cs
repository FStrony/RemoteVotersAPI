using System;
using remotevotersapi.Domain.Bases;

namespace remotevotersapi.Domain.Entities
{
    /// <summary>
    /// Company Entity
    ///
    /// Author: FStrony
    /// </summary>
    public class Company : BaseEntity
    {
        /// <value>Company Name </value>
        public String CompanyName { get; set; }

        /// <value>Company's CNPJ</value>
        public String Cnpj { get; set; }

        /// <value>Company's Address</value>
        public String Address1 { get; set; }
        public String Address2 { get; set; }

        /// <value>Company's PostCode</value>
        public String PostCode { get; set; }

        /// <value>Company's State</value>
        public String State { get; set; }

        /// <value>Company's City</value>
        public String City { get; set; }

        /// <value>Company's Country</value>
        public String Country { get; set; }

        /// <value>Company's Email</value>
        public String Email { get; set; }

        /// <value>Company's Password</value>
        public String Password { get; set; }
    }
}
