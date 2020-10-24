using AutoMapper;
using RemoteVotersAPI.Application.ViewModel;
using RemoteVotersAPI.Domain.Entities;

namespace RemoteVotersAPI.Application.AutoMapper
{
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
