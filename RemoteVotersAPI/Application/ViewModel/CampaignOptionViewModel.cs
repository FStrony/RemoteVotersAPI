using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Application.ViewModel
{
    public class CampaignOptionViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Description is mandatory!")]
        public String Description { get; set; }
    }
}
