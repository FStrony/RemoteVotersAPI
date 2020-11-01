using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Newtonsoft.Json;
using remotevotersapi.Domain.Bases;
using remotevotersapi.Utils;

namespace remotevotersapi.Domain.Entities
{
    /// <summary>
    /// Campaign Entity
    ///
    /// Author: FStrony
    /// </summary>
    public class Campaign : BaseEntity
    {
        /// <value>Company ID</value>
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CompanyId { get; set; }

        /// <value>Campaign Title </value>
        public String Title { get; set; }

        /// <value> Campaign Description </value>
        public String Description { get; set; }

        /// <value> Campaign Code </value>
        public String CampaignCode { get; set; }

        //<value> Does the campaign has autentication </value>
        public bool Auth { get; set; }

        /// <value> Company endpoint to voters autenticate</value>
        public String UrlAuth { get; set; }

        /// <value> List of field's names used to autenticate</value>
        public List<String> FieldsName { get; set; }


        /// <value> Campaign Status</value>
        public bool Status { get; set; }

        /// <value> Campaign Options</value>
        public List<CampaignOption> CampaignOptions { get; set; }
    }
}
