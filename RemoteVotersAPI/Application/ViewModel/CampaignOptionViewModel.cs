using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using remotevotersapi.Domain.Bases;

namespace remotevotersapi.Application.ViewModel
{
    /// <summary>
    /// Campaign Option View Model
    ///
    /// Author: FStrony
    /// </summary>
    public class CampaignOptionViewModel : BaseEntity
    {
        /// <value>Option description</value>
        [Required(ErrorMessage = "Description is mandatory!")]
        public String Description { get; set; }
    }
}
