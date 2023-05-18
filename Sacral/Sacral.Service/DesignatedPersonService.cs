using System.Threading.Tasks;
using Sacral.DataAccess;
using Sacral.DTO;

namespace Sacral.Service
{
    public class DesignatedPersonService : IDesignatedPersonService
    {
        private readonly IDesignatedPersonRepository _designatedPersonRepository;

        public DesignatedPersonService(IDesignatedPersonRepository designatedPersonRepository)
        {
            _designatedPersonRepository = designatedPersonRepository;
        }

        public async Task<DesignatedPersonModel> CreateDesignatedPersonAsync(DesignatedPersonModel model)
        {
            return await _designatedPersonRepository.CreateDesignatedPersonAsync(model);
        }

        public async Task<DesignatedPersonModel> GetDesignatedPersonAsync(int id)
        {
            return await _designatedPersonRepository.GetDesignatedPersonAsync(id);
        }

        public async Task<DesignatedPersonModel> UpdateDesignatedPersonAsync(DesignatedPersonModel model)
        {
            return await _designatedPersonRepository.UpdateDesignatedPersonAsync(model);
        }

        public async Task DeleteDesignatedPersonAsync(int id)
        {
            await _designatedPersonRepository.DeleteDesignatedPersonAsync(id);
        }
    }
}