using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Domain.Entities
{
    public class Campaign : BaseEntity
    {

        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CompanyId { get; set; }

        public String Title { get; set; }
        public String Description { get; set; }

        public String CampaignCode { get; set; }

        public String UrlAuth { get; set; }
        public String FieldName { get; set; }

        public bool status_active { get; set; }

        List<CampaignOption> CampaignOptions { get; set; }
    }
}
