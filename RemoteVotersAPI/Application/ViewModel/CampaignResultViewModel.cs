using System.Collections.Generic;

namespace remotevotersapi.Application.ViewModel
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
