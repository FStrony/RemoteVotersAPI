using System;
namespace RemoteVotersAPI.Infra.ModelSettings
{
    public class MongoDBConfig
    {
        public String Database { get; set; }
        public String Url { get; set; }
        public String User { get; set; }
        public String Password { get; set; }

        public String getConnectionString()
        {
            return $"mongodb://{this.User}:{this.Password}@{this.Url}";
        }
    }
}
