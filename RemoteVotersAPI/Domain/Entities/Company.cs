using System;
using RemoteVotersAPI.Domain.Bases;

namespace RemoteVotersAPI.Domain.Entities
{
    public class Company : BaseEntity
    {
        public String CompanyName { get; set; }
        public String Cnpj { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String PostCode { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public String Country { get; set; }

        public String Email { get; set; }
        public String Password { get; set; }
    }
}
