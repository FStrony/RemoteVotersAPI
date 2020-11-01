using System;
namespace remotevotersapi.Utils.Results
{
    /// <summary>
    /// Error Entity
    /// 
    /// Author: FStrony
    /// </summary>
    public class ErrorValidate
    {
        private string property;
        public string Property
        {
            get { return property; }
            set { property = Char.ToLowerInvariant(value[0]) + value.Substring(1); }
        }
        public string Message { get; set; }
    }
}
