using System.Threading.Tasks;
using Sacral.DataAccess;
using Sacral.DTO;

namespace Sacral.Service
{
    public class ConfigureJiraService
    {
        private readonly IConfigureJiraRepository _configureJiraRepository;

        public ConfigureJiraService(IConfigureJiraRepository configureJiraRepository)
        {
            _configureJiraRepository = configureJiraRepository;
        }

        public async Task<ConfigureJiraModel> GetConfigureJiraAsync(int id)
        {
            return await _configureJiraRepository.GetConfigureJiraAsync(id);
        }

        public async Task<string> CreateConfigureJiraAsync(ConfigureJiraModel model)
        {
            return await _configureJiraRepository.CreateConfigureJiraAsync(model);
        }

        public async Task<string> UpdateConfigureJiraAsync(ConfigureJiraModel model)
        {
            return await _configureJiraRepository.UpdateConfigureJiraAsync(model);
        }

        public async Task<string> DeleteConfigureJiraAsync(int id)
        {
            return await _configureJiraRepository.DeleteConfigureJiraAsync(id);
        }
    }
}