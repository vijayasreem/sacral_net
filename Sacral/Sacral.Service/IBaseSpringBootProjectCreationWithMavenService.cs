//Answer

using Sacral.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sacral.Service
{
    public interface IBaseSpringBootProjectCreationWithMavenService
    {
        Task<BaseSpringBootProjectCreationWithMavenDTO> GetAsync(int id);
        Task<IEnumerable<BaseSpringBootProjectCreationWithMavenDTO>> GetAllAsync();
        Task<bool> InsertAsync(BaseSpringBootProjectCreationWithMavenDTO dto);
        Task<bool> UpdateAsync(BaseSpringBootProjectCreationWithMavenDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}