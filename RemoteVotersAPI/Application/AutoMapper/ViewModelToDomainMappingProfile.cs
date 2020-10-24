using AutoMapper;
using RemoteVotersAPI.Application.ViewModel;
using RemoteVotersAPI.Domain.Entities;

namespace RemoteVotersAPI.Application.AutoMapper
{
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
