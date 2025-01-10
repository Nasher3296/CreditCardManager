using CreditCardManager.Exceptions;
using CreditCardManager.Models.Auth;
using CreditCardManager.Models.Users;
using CreditCardManager.Repositories.Users;

namespace CreditCardManager.Services.Users
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<User?> RegisterUserAsync(RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Password))
            {
                throw new BusinessException($"Invalid password.");
            }

            var existingUser = await _userRepository.GetByUsernameAsync(request.Email);

            if (existingUser != null)
            {
                throw new BusinessException($"The username '{request.Username}' is already in use.");
            }

            existingUser = await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser != null)
            {
                throw new BusinessException($"The email '{request.Email}' is already in use.");
            }

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
            return user;
        }

        public async Task<User?> AuthenticateAsync(LoginRequest request)
        {
            User? user = (!string.IsNullOrEmpty(request.Username))
                ? await _userRepository.GetByUsernameAsync(request.Username)
                : (!string.IsNullOrEmpty(request.Email))
                ? await _userRepository.GetByEmailAsync(request.Email)
                : null;

            return user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.HashedPassword)
                ? user
                : null;
        }
    }
}
