using Sacral.Service;
using Sacral.DTO;

namespace Sacral.Service 
{
    public interface IDesignatedPersonService
    {
        Task<DesignatedPersonModel> GetDesignatedPersonAsync(int id);
        Task<int> CreateDesignatedPersonAsync(DesignatedPersonModel designatedPerson);
        Task UpdateDesignatedPersonAsync(DesignatedPersonModel designatedPerson);
        Task DeleteDesignatedPersonAsync(int id);
    }
}