namespace Sacral.Service
{
    using System.Threading.Tasks;
    using Sacral.DTO;

    public interface IDesignatedPersonRepository
    {
        Task<DesignatedPersonModel> GetDesignatedPersonAsync(int id);
        Task<int> CreateDesignatedPersonAsync(DesignatedPersonModel designatedPerson);
        Task UpdateDesignatedPersonAsync(DesignatedPersonModel designatedPerson);
        Task DeleteDesignatedPersonAsync(int id);
    }
}