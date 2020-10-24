using AutoMapper;
using RemoteVotersAPI.Application.ViewModel;
using RemoteVotersAPI.Domain.Entities;

namespace RemoteVotersAPI.Application.AutoMapper
{
    /// <summary>
    /// View Model to Domain Mapping
    /// 
    /// Author: FStrony
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CompanyViewModel, Company>();
            CreateMap<VoteViewModel, Vote>();
            CreateMap<CampaignViewModel, Campaign>();
            CreateMap<CampaignOptionViewModel, CampaignOption>();
        }
    }
}
