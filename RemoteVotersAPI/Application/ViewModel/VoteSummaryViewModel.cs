using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Application.ViewModel
{
    /// <summary>
    /// Votes Summary
    ///
    /// Author: FStrony
    /// </summary>
    public class VoteSummaryViewModel
    {
        /// <value>Campaign Option ID</value>
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId OptionId { get; set; }

        /// <value>Campaign Option Description</value>
        public String Description { get; set; }

        /// <value>Total of votes</value>
        public long TotalVotes { get; set; }
    }
}
