using Sacral.Service;
using Sacral.DataAccess;
using Sacral.DTO;
using System.Threading.Tasks;

namespace Sacral.Service 
{
    public class DesignatedPersonService : IDesignatedPersonService
    {
        private readonly DesignatedPersonRepository _designatedPersonRepository;

        public DesignatedPersonService(DesignatedPersonRepository designatedPersonRepository)
        {
            _designatedPersonRepository = designatedPersonRepository;
        }

        public async Task<DesignatedPersonModel> GetDesignatedPersonAsync(int id)
        {
            return await _designatedPersonRepository.GetDesignatedPersonAsync(id);
        }

        public async Task<int> CreateDesignatedPersonAsync(DesignatedPersonModel designatedPerson)
        {
            return await _designatedPersonRepository.CreateDesignatedPersonAsync(designatedPerson);
        }

        public async Task UpdateDesignatedPersonAsync(DesignatedPersonModel designatedPerson)
        {
            await _designatedPersonRepository.UpdateDesignatedPersonAsync(designatedPerson);
        }

        public async Task DeleteDesignatedPersonAsync(int id)
        {
            await _designatedPersonRepository.DeleteDesignatedPersonAsync(id);
        }
    }
}