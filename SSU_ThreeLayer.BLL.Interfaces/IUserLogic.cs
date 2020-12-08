using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.BLL.Interfaces
{
    public interface IUserLogic
    {
        void SignUp(string login, string password, string doublePassword, out string alert);

        bool SignIn(string login, string password, out string alert);

        void UpdateUser(string nameUser, string newNameUser, string login, string newlogin, string password, string newPassword, out string alert);

        User GetUserById(int idUser);

        User GetUserByLogin(string login);

        User GetUserByName(string nameUser);

    }
}
