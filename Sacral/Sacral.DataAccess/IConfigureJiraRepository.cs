using System.Threading.Tasks;
using Sacral.DTO;

namespace Sacral.Service
{
    public interface IConfigureJiraRepository
    {
        Task<ConfigureJiraModel> GetConfigureJiraAsync(int id);
        Task<string> CreateConfigureJiraAsync(ConfigureJiraModel model);
        Task<string> UpdateConfigureJiraAsync(ConfigureJiraModel model);
        Task<string> DeleteConfigureJiraAsync(int id);
    }
}