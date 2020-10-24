using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Application.ViewModel
{
    /// <summary>
    /// Vote View Model
    ///
    /// Author: FStrony
    /// </summary>
    public class VoteViewModel : BaseEntity
    {
        /// <value>Voter Identity to check if he/she already voted</value>
        [Required(ErrorMessage = "VoterIdentity is mandatory!")]
        public String VoterIdentity { get; set; }

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
