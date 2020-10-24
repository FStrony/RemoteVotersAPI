using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Domain.Bases
{
    public class BaseEntity
    {
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public BaseEntity()
        {
            Id = ObjectId.GenerateNewId();
            RegistrationDate = DateTime.Now;
        }
    }
}
