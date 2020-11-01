using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using remotevotersapi.Domain.Bases;
using remotevotersapi.Utils;

namespace remotevotersapi.Application.ViewModel
{
    /// <summary>
    /// Campaign View Model
    ///
    /// Author: FStrony
    /// </summary>
    public class CampaignViewModel : BaseEntity
    {
        /// <value>Company ID</value>
        //[Required(ErrorMessage = "CompanyId is mandatory!")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CompanyId { get; set; }

        /// <value>Campaign Title </value>
        [Required(ErrorMessage = "Title is mandatory!")]
        public String Title { get; set; }

        /// <value> Campaign Description </value>
        [Required(ErrorMessage = "Description is mandatory!")]
        public String Description { get; set; }

        /// <value> Campaign Code </value>
        [Required(ErrorMessage = "Campaign Code is mandatory!")]
        public String CampaignCode { get; set; }

        //<value> Does the campaign has autentication </value>
        [DefaultValue(false)]
        [Required(ErrorMessage = "Auth is mandatory!")]
        public bool Auth { get; set; }

        /// <value> Company endpoint to voters autenticate</value>
        public String UrlAuth { get; set; }

        /// <value> Field Name used to autenticate</value>
        public String FieldsName { get; set; }

        /// <value> Campaign Status</value>
        [DefaultValue(true)]
        [Required(ErrorMessage = "Status is mandatory!")]
        public bool Status { get; set; }

        /// <value> Campaign Options</value>
        [Required(ErrorMessage = "Campaign Options is mandatory!")]
        public List<CampaignOptionViewModel> CampaignOptions { get; set; }

        public String CompanyName { get; set; }
    }
}
