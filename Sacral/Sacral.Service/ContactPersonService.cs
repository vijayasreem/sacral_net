using Sacral.DataAccess;
using Sacral.DTO;

namespace Sacral.Service
{
    public class ContactPersonService : IContactPersonService
    {
        public async Task<int> CreateContactPerson(ContactPersonDTO contactPersonDTO)
        {
            using(var dbContext = new SacralContext())
            {
                var contactPerson = new ContactPerson
                {
                    FirstName = contactPersonDTO.FirstName,
                    LastName = contactPersonDTO.LastName, 
                    Email = contactPersonDTO.Email,
                    Phone = contactPersonDTO.Phone
                };

                dbContext.ContactPersons.Add(contactPerson);
                await dbContext.SaveChangesAsync();

                return contactPerson.Id;
            }
        }
    }
}