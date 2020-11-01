using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using remotevotersapi.Domain.Bases;
using remotevotersapi.Utils;

namespace remotevotersapi.Domain.Entities
{
    /// <summary>
    /// Vote Entity
    ///
    /// Author: FStrony
    /// </summary>
    public class Vote : BaseEntity
    {
        /// <value>Voter Identity to check if he/she already voted</value>
        public String VoterIdentity { get; set; }

        /// <value>Campaign ID</value>
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CampaignId { get; set; }

        /// <value>Company ID</value>
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CompanyId { get; set; }

        /// <value>Campaign Option ID</value>
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CampaignOptionId { get; set; }


    }
}
