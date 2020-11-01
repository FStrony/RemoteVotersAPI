using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using remotevotersapi.Utils;

namespace remotevotersapi.Application.ViewModel
{
    /// <summary>
    /// Vote View Request Model
    ///
    /// Author: FStrony
    /// </summary>
    public class VoteRequestViewModel
    {
        /// <value>Voter Identity dictonary info to check if he/she already voted</value>
        public Dictionary<String, String> VoterIdentity { get; set; }

        /// <value>Campaign ID</value>
        [Required(ErrorMessage = "CampaignId is mandatory!")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CampaignId { get; set; }

        /// <value>Company ID</value>
        [Required(ErrorMessage = "CompanyId is mandatory!")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CompanyId { get; set; }

        /// <value>Campaign Option ID</value>
        [Required(ErrorMessage = "CampaignOptionId is mandatory!")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CampaignOptionId { get; set; }
    }
}
