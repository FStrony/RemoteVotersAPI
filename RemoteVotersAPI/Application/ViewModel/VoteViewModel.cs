using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Application.ViewModel
{
    public class VoteViewModel : BaseEntity
    {
        [Required(ErrorMessage = "VoterIdentity is mandatory!")]
        public String VoterIdentity { get; set; }

        [Required(ErrorMessage = "CampaignId is mandatory!")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CampaignId { get; set; }

        [Required(ErrorMessage = "CompanyId is mandatory!")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CompanyId { get; set; }

        [Required(ErrorMessage = "CampaignOptionId is mandatory!")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CampaignOptionId { get; set; }
    }
}
