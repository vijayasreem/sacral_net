namespace Sacral.Service
{
    using Sacral.DataAccess;
    using Sacral.DTO;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class BaseSpringBootProjectCreationWithMavenService : IBaseSpringBootProjectCreationWithMavenService
    {
        private readonly BaseSpringBootProjectCreationWithMavenRepository _repository;
        public BaseSpringBootProjectCreationWithMavenService(SqlConnection connection)
        {
            _repository = new BaseSpringBootProjectCreationWithMavenRepository(connection);
        }

        public async Task<BaseSpringBootProjectCreationWithMavenDTO> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            if (model == null)
            {
                return null;
            }
            return new BaseSpringBootProjectCreationWithMavenDTO
            {
                Id = model.Id,
                BuildTool = model.BuildTool,
                Language = model.Language,
                Framework = model.Framework
            };
        }

        public async Task<IEnumerable<BaseSpringBootProjectCreationWithMavenDTO>> GetAllAsync()
        {
            var models = await _repository.GetAllAsync();
            var dtos = new List<BaseSpringBootProjectCreationWithMavenDTO>();
            foreach(var model in models)
            {
                dtos.Add(new BaseSpringBootProjectCreationWithMavenDTO
                {
                    Id = model.Id,
                    BuildTool = model.BuildTool,
                    Language = model.Language,
                    Framework = model.Framework
                });
            }
            return dtos;
        }

        public async Task<bool> InsertAsync(BaseSpringBootProjectCreationWithMavenDTO dto)
        {
            var model = new BaseSpringBootProjectCreationWithMavenModel
            {
                BuildTool = dto.BuildTool,
                Language = dto.Language,
                Framework = dto.Framework
            };
            return await _repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(BaseSpringBootProjectCreationWithMavenDTO dto)
        {
            var model = new BaseSpringBootProjectCreationWithMavenModel
            {
                Id = dto.Id,
                BuildTool = dto.BuildTool,
                Language = dto.Language,
                Framework = dto.Framework
            };
            return await _repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}