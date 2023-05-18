namespace Sacral.Service
{
    using Sacral.DTO;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public interface IDesignatedPersonRepository
    {
        Task<DesignatedPersonModel> CreateDesignatedPersonAsync(DesignatedPersonModel model);
        Task<DesignatedPersonModel> GetDesignatedPersonAsync(int id);
        Task<DesignatedPersonModel> UpdateDesignatedPersonAsync(DesignatedPersonModel model);
        Task DeleteDesignatedPersonAsync(int id);
    }
}