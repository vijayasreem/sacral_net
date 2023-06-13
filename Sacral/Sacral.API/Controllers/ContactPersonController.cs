namespace Sacral.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly ContactPersonService _contactPersonService;
        public ContactPersonController(ContactPersonService contactPersonService)
        {
            _contactPersonService = contactPersonService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactPerson(ContactPersonDTO contactPersonDTO)
        {
            var id = await _contactPersonService.CreateContactPerson(contactPersonDTO);

            return Ok(id);
        }
    }
}