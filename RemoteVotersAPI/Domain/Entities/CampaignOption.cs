using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Domain.Entities
{
    public class CampaignOption : BaseEntity
    {
        public String Description { get; set; }
    }
}
