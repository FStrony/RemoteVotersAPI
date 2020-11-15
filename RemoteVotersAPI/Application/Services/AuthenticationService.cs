using System.Threading.Tasks;
using remotevotersapi.Application.ViewModel;
using remotevotersapi.Domain.Entities;
using remotevotersapi.Infra.Data.Repositories;
using remotevotersapi.Utils;
namespace remotevotersapi.Application.Services
{
    /// <summary>
    /// Antentication Service
    ///
    /// Author: FStrony
    /// </summary>
    public class AuthService
    {

        // <value> company service</value>
        private CompanyRepository companyRepository;

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="companyRepository"></param>
        public AuthService(CompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        /// <summary>
        /// Company Authentication
        /// </summary>
        /// <param name="model">AuthenticationViewModel</param>
        /// <returns></returns>
        public async Task<string> Authenticate(AuthenticationViewModel model)
        {
            try
            {
                Company company = company = await companyRepository.Retrieve(model.Email, Encryptor.Encrypt(model.Password));
                return company.Id.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
