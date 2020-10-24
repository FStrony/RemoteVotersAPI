using AutoMapper;
using RemoteVotersAPI.Application.ViewModel;
using RemoteVotersAPI.Domain.Entities;

namespace RemoteVotersAPI.Application.AutoMapper
{
    /// <summary>
    /// Domain to View Model Mapping
    /// 
    /// Author: FStrony
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Company, CompanyViewModel>();
            CreateMap<Campaign, CampaignViewModel>();
            CreateMap<CampaignOption, CampaignOptionViewModel>();
            CreateMap<Vote, VoteViewModel>();
        }
    }
}
