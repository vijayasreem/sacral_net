using Microsoft.AspNetCore.Mvc;
using Sacral.DTO;
using Sacral.Service;
using System.Threading.Tasks;

namespace Sacral.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigureJiraController : ControllerBase
    {
        private readonly ConfigureJiraService _configureJiraService;

        public ConfigureJiraController(ConfigureJiraService configureJiraService)
        {
            _configureJiraService = configureJiraService;
        }

        [HttpGet]
        public async Task<ActionResult<ConfigureJiraModel>> GetConfigureJiraAsync(int id)
        {
            var result = await _configureJiraService.GetConfigureJiraAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateConfigureJiraAsync(ConfigureJiraModel model)
        {
            var result = await _configureJiraService.CreateConfigureJiraAsync(model);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }

            return result;
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateConfigureJiraAsync(ConfigureJiraModel model)
        {
            var result = await _configureJiraService.UpdateConfigureJiraAsync(model);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }

            return result;
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteConfigureJiraAsync(int id)
        {
            var result = await _configureJiraService.DeleteConfigureJiraAsync(id);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }

            return result;
        }
    }
}