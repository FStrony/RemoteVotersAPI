using System;
namespace remotevotersapi.Infra.ModelSettings
{
    /// <summary>
    /// MongoDB configs
    /// 
    /// Author: FStrony
    /// </summary>
    public sealed class MongoDBConfig
    {
        /// <value> Database </value>
        public String Database { get; set; }
        
        /// <value> DB URL </value>
        public String Url { get; set; }

        /// <value> User </value>
        public String User { get; set; }

        /// <value> Password </value>
        public String Password { get; set; }

        /// <summary>
        /// Builds the connection String
        /// </summary>
        /// <returns>MongoDB connection String</returns>
        public String getConnectionString()
        {
            return $"mongodb+srv://{this.User}:{this.Password}@{this.Url}/{this.Database}?retryWrites=true&w=majority";
        }
    }
}
