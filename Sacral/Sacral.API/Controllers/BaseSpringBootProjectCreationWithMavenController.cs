namespace Sacral.API
{
    using Microsoft.AspNetCore.Mvc;
    using Sacral.DTO;
    using Sacral.Service;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    
    [Route("api/[controller]")]
    [ApiController]
    public class BaseSpringBootProjectCreationWithMavenController : ControllerBase
    {
        private readonly BaseSpringBootProjectCreationWithMavenService _service;
        public BaseSpringBootProjectCreationWithMavenController(SqlConnection connection)
        {
            _service = new BaseSpringBootProjectCreationWithMavenService(connection);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseSpringBootProjectCreationWithMavenDTO>>> GetAsync()
        {
            var models = await _service.GetAllAsync();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseSpringBootProjectCreationWithMavenDTO>> GetAsync(int id)
        {
            var model = await _service.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<BaseSpringBootProjectCreationWithMavenDTO>> PostAsync(BaseSpringBootProjectCreationWithMavenDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _service.InsertAsync(dto))
            {
                return CreatedAtAction(nameof(GetAsync), new { id = dto.Id }, dto);
            }
            return Conflict();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseSpringBootProjectCreationWithMavenDTO>> PutAsync(int id, BaseSpringBootProjectCreationWithMavenDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dto.Id = id;
            if (await _service.UpdateAsync(dto))
            {
                return Ok(dto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (await _service.DeleteAsync(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}