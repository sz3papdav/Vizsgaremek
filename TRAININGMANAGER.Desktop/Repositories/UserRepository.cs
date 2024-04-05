using TRAININGMANAGER.Desktop.Models;
using TRAININGMANAGER.Shared.Models;
using System.Net;

namespace TRAININGMANAGER.Desktop.Repositories
{
    public class UserRepository
    {
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = true;
            return validUser;
        }

        public User? GetByUsername(string userName)
        {
             return new User
             {
                 Username = "teszt",
                 Email = "teszt@teszt.hu",
                 FirstName = "Elek",
                 LastName = "Teszt",
                 Password = "test@123"
             };
        }
    }
}
