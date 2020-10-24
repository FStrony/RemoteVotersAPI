using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Domain.Entities
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

        /// <value> Company endpoint to voters autenticate</value>
        public String UrlAuth { get; set; }

        /// <value> Field Name used to autenticate</value>
        public String FieldName { get; set; }

        /// <value> Campaign Status</value>
        public bool status_active { get; set; }

        /// <value> Campaign Options</value>
        List<CampaignOption> CampaignOptions { get; set; }
    }
}
