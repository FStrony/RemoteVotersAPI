using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Application.ViewModel
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
