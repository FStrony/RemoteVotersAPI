using AutoMapper;

namespace RemoteVotersAPI.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappingMVC()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
