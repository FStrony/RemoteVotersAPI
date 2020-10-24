using AutoMapper;

namespace RemoteVotersAPI.Application.AutoMapper
{
    /// <summary>
    /// Auto Mapper Configuration
    /// 
    /// Author: FStrony
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Register the Mapping
        /// </summary>
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
