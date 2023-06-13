namespace Sacral.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody]UserDTO userDTO)
        {
            var isValidUser = await _loginService.ValidateCredentialsAsync(userDTO.Username, userDTO.Password);

            if (!isValidUser)
            {
                return Unauthorized();
            }

            return Ok(new { success = true });
        }
    }
}