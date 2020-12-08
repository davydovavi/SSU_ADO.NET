using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.BLL.Interfaces;
using SSU_ThreeLayer.DAL.Interfaces;
using SSU_ThreeLayer.Entities;
using System.Security.Cryptography;

namespace SSU_ThreeLayer.BLL
{
    public class UserLogic:IUserLogic
    {
        private const int PBKDF2IterCount = 1000; // default for Rfc2898DeriveBytes
        private const int PBKDF2SubkeyLength = 256 / 8; // 256 bits
        private const int SaltSize = 128 / 8; // 128 bits

        private IUserDAL _userDAL;
        

        public UserLogic(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public void SignUp(string login, string password, string doublePassword, out string alert)
        {
            if (GetUserByLogin(login) != null)
            {
                alert = "User already exist";
            }
            else if (login == null || password == null || doublePassword == null)
            {
                alert = "You couldn't sign up! One of the fields is null.";
                return;
            }
            else if (login.Length > 32 || password.Length > 32 || doublePassword.Length > 32)
            {
                alert = "You couldn't sign up! Length of login and both passwords mustn't be more than 32.";
                return;
            }
            else if (password != doublePassword)
            {
                alert = "You couldn't sign up! Passwords don't match.";
                return;
            }
            else
            {
                byte[] salt;
                byte[] subkey;
                using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
                {
                    salt = deriveBytes.Salt;
                    subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                }

                var outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
                Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
                Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);

                User user;
                user = new User()
                {
                    Hashpassword = Convert.ToBase64String(outputBytes),
                    Login = login
                };
                _userDAL.SignUp(user);
                alert = "Sign up successful!";
            }

        }

        public bool SignIn(string login, string password, out string alert)
        {
            if (login == null || password == null)
            {
                alert = "You couldn't sign up! One of the fields is null.";
                return false;
            }
            else if (login.Length > 32 || password.Length > 32)
            {
                alert = "You couldn't sign up! Length of login and password mustn't be more than 32.";
                return false;
            }
            else
            {
                byte[] salt;
                byte[] subkey;
                using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
                {
                    salt = deriveBytes.Salt;
                    subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                }

                var outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
                Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
                Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);

                User user;
                user = new User()
                {
                    Hashpassword = Convert.ToBase64String(outputBytes),
                    Login = login
                };
                if (_userDAL.SignIn(user))
                {
                    alert = "Sign in successful!";
                    return true;
                }
                else
                {
                    alert = "Wrong password or login. Try again, please.";
                    return false;
                }
                
            }

        }

        public void UpdateUser(string nameUser, string newNameUser, string login, string newlogin, string password, string newPassword, out string alert)
        {
            if (nameUser == null || newNameUser == null || login == null || newlogin == null || password == null || newPassword == null)
            {
                alert = "You couldn't update! One of the fields is null.";
                return;
            }
            else if (GetUserByLogin(login) != null)
            {
                alert = "You couldn't update! Such login exists.";
                return;
            }
            else if(!SignIn(login, password, out alert))
            {
                alert = "You couldn't update! Invalid login or password";
                return;
            }
            else if (newlogin.Length > 32 || newPassword.Length > 32 || newNameUser.Length > 255)
            {
                alert = "You couldn't sign up! Length of login and password mustn't be more than 32, length of user name mustn't be more than 255.";
                return;
            }
            byte[] salt;
            byte[] subkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(newPassword, SaltSize, PBKDF2IterCount))
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }

            var outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);

            User user = GetUserByName(nameUser);
            user.NameUser = newNameUser;
            user.Login = newlogin;
            user.Hashpassword = Convert.ToBase64String(outputBytes);
            _userDAL.UpdateUser(user);
            alert = "Update successful.";
        }


        public User GetUserById(int idUser)
        {
            return _userDAL.GetUserById(idUser);
        }

        public User GetUserByLogin(string login)
        {
            return _userDAL.GetUserByLogin(login);
        }

        public User GetUserByName(string nameUser)
        {
            return _userDAL.GetUserByName(nameUser);
        }
    }
}
