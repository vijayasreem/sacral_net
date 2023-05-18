}
        }
    }
}

namespace Sacral.Service
{
    using Sacral.DTO;

    public interface IBaseSpringBootProjectCreationWithMavenRepository
    {
        Task<BaseSpringBootProjectCreationWithMavenModel> GetAsync(int id);
        Task<IEnumerable<BaseSpringBootProjectCreationWithMavenModel>> GetAllAsync();
        Task<bool> InsertAsync(BaseSpringBootProjectCreationWithMavenModel model);
        Task<bool> UpdateAsync(BaseSpringBootProjectCreationWithMavenModel model);
        Task<bool> DeleteAsync(int id);
    }
}