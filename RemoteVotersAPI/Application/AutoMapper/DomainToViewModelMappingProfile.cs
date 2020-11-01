using AutoMapper;
using remotevotersapi.Application.ViewModel;
using remotevotersapi.Domain.Entities;

namespace remotevotersapi.Application.AutoMapper
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
