using System.Threading.Tasks;
using Sacral.DataAccess;
using Sacral.DTO;

namespace Sacral.Service
{
    public interface IDesignatedPersonService
    {
        Task<DesignatedPersonModel> CreateDesignatedPersonAsync(DesignatedPersonModel model);
        Task<DesignatedPersonModel> GetDesignatedPersonAsync(int id);
        Task<DesignatedPersonModel> UpdateDesignatedPersonAsync(DesignatedPersonModel model);
        Task DeleteDesignatedPersonAsync(int id);
    }
}