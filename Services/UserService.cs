using Data.Enumerations.RelatedData.User;
using Data.Models;
using Data.Requests.User;
using Data.Responses;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Repositories;
using System.Security.Cryptography;

namespace Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> Register(RegisterRequest request)
        {
            try
            {
                if (request.Name == null || request.Name.Length == 0) return new ErrorResponse() { Message = "Полето име е задолжително" };
                if (request.Surname == null || request.Surname.Length == 0) return new ErrorResponse() { Message = "Полето презиме е задолжително" };
                if (request.Email == null || request.Email.Length == 0) return new ErrorResponse() { Message = "Полето email е задолжително" };
                if (request.Username == null || request.Username.Length == 0) return new ErrorResponse() { Message = "Полето корисничко име е задолжително" };
                if (request.Dob == null) return new ErrorResponse() { Message = "Полето датум на раѓање е задолжително" };
                if (request.Password == null || request.Password.Length == 0) return new ErrorResponse() { Message = "Полето лозинка е задолжително" };

                if (request.Password.Length < 8) return new ErrorResponse() { Message = "Лозинката мора да содржи најмалку 8 карактери" };

                List<User> foundUsers = await _userRepository.FindAll(u => u.Email == request.Email || u.Username == request.Username);
                if (foundUsers.Count > 0) return new ErrorResponse() { Message = "Во системот веќе постои корисник со исто корисничко име или email адреса" };

                byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

                string passwordHashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: request.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                User user = new()
                {
                    Email = request.Email,
                    Username = request.Username,
                    Name = request.Name,
                    Surname = request.Surname,
                    PasswordHashed = passwordHashed,
                    PasswordSalt = salt,
                    Dob = request.Dob
                };

                user = await _userRepository.Insert(user);

                return new SuccessResponse<User>() { Data = user };
            }
            catch (Exception)
            {
                return new ErrorResponse() { Message = "Се случи грешка, обидете се повторно" };
            }
        }

        public async Task<Response> Login(LoginRequest request)
        {
            try
            {
                User? user = await _userRepository.FindSingle(u => u.Email == request.UserNameOrEmail || u.Username == request.UserNameOrEmail);
                if (user == null) return new ErrorResponse() { Message = "Погрешно корисничко име, email адреса или лозинка. Обидете се повторно" };

                string passwordHashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: request.Password,
                    salt: user.PasswordSalt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                await _userRepository.LoadRelatedReference<Address>(user, UserRelatedDataReferences.ADDRESS);
                await _userRepository.LoadRelatedCollection(user, UserRelatedDataCollections.VEHICLES);
                return user.PasswordHashed == passwordHashed ?
                    new SuccessResponse<User> { Data = user } :
                    new ErrorResponse() { Message = "Погрешно корисничко име, email адреса или лозинка. Обидете се повторно" };
            }
            catch (Exception)
            {
                return new ErrorResponse() { Message = "Се случи грешка, обидете се повторно" };
            }
        }
    }
}
