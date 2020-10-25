using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Newtonsoft.Json;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Application.ViewModel
{
    /// <summary>
    /// Campaign Result View Model
    ///
    /// Author: FStrony
    /// </summary>
    public class CampaignResultViewModel
    {
        /// <value>Campaign</value>
        public CampaignViewModel Campaign { get; set; }

        /// <value>Votes summary</value>
        public List<VoteSummaryViewModel> VoteSummary { get; set; }

    }
}
