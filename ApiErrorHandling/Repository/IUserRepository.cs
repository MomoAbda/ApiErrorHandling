using ApiErrorHandling.Models;


namespace ApiErrorHandling.Repository
{
    public interface IUserRepository
    {
        UserInformations GetUserInformations(int idUser);
    }

    public class UserRepository : IUserRepository
    {

        /// <summary>
        /// Call To the database or another web api
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public UserInformations GetUserInformations(int idUser)
        {
            //Mock
            return new UserInformations
            {
                Salary = 1500, // Need Money 
                IsPrivate = true
            };
        }
    }
}
