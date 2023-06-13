using Sacral.DataAccess;
using Sacral.DTO;

namespace Sacral.Service
{
    public interface ILoginService
    {
        Task<bool> ValidateCredentialsAsync(string username, string password);
    }

    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
  
        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByCredentialsAsync(username, password);

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}