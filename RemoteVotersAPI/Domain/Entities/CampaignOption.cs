using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Domain.Entities
{
    /// <summary>
    /// Campaign Option Entity
    ///
    /// Author: FStrony
    /// </summary>
    public class CampaignOption : BaseEntity
    {
        /// <value>Option description</value>
        public String Description { get; set; }
    }
}
