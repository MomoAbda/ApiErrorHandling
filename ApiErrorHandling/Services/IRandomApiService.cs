using ApiErrorHandling.Core;
using ApiErrorHandling.Models;
using ApiErrorHandling.Repository;
namespace ApiErrorHandling.Services
{
    public interface IRandomApiService
    {
        UserInformations GetRandomUserInformation(int idUser);
    }

    public class RandomApiService : IRandomApiService
    {
        private readonly IUserRepository _userRepository;
        public RandomApiService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserInformations GetRandomUserInformation(int idUser)
        {
            var userInformations = _userRepository.GetUserInformations(idUser);

            if (userInformations.IsPrivate)
                throw new UserInformationsPrivateException(System.Net.HttpStatusCode.UnavailableForLegalReasons);
            else return userInformations;
        }
    }
}
