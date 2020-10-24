using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Application.ViewModel
{
    public class CampaignViewModel : BaseEntity
    {
        [Required(ErrorMessage = "CompanyId is mandatory!")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId CompanyId { get; set; }

        [Required(ErrorMessage = "Title is mandatory!")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Description is mandatory!")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Campaign Code is mandatory!")]
        public String CampaignCode { get; set; }

        [Required(ErrorMessage = "UrlAuth is mandatory!")]
        public String UrlAuth { get; set; }

        [Required(ErrorMessage = "Field Name is mandatory!")]
        public String FieldName { get; set; }

        [Required(ErrorMessage = "Status is mandatory!")]
        public bool status_active { get; set; }

        [Required(ErrorMessage = "Campaign Options is mandatory!")]
        List<CampaignOptionViewModel> CampaignOptions { get; set; }
    }
}
