using AutoMapper;
using remotevotersapi.Application.ViewModel;
using remotevotersapi.Domain.Entities;

namespace remotevotersapi.Application.AutoMapper
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
