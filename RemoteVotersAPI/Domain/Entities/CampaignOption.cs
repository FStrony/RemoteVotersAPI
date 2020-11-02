using System;
using remotevotersapi.Domain.Bases;

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
