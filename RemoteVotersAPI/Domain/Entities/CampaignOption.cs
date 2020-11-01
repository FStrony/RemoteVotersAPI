using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using remotevotersapi.Domain.Bases;
using remotevotersapi.Utils;

namespace remotevotersapi.Domain.Entities
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
