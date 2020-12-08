using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.DAL.Interfaces
{
    public interface IUserDAL
    {
        void SignUp(User user);

        bool SignIn(User user);

        void UpdateUser(User user);

        IEnumerable<User> GetAllUsers();

        User GetUserById(int idUser);

        User GetUserByLogin(string login);

        User GetUserByName(string userName);
        
    }
}
