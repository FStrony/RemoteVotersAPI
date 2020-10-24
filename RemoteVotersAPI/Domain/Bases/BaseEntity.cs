using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Domain.Bases
{
    /// <summary>
    /// Base Entity
    ///
    /// Author: FStrony
    /// </summary>
    public class BaseEntity
    {
        /// <value>ID</value>
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        /// <value>Registration Date</value>
        public DateTime RegistrationDate { get; set; }

        public BaseEntity()
        {
            Id = ObjectId.GenerateNewId();
            RegistrationDate = DateTime.Now;
        }
    }
}
