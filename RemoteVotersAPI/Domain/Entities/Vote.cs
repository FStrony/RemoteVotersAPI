using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Domain.Entities
{
    public class Vote : BaseEntity
    {

        public String VoterIdentity { get; set; }

        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CampaignId { get; set; }

        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CompanyId { get; set; }

        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CampaignOptionId { get; set; }


    }
}
