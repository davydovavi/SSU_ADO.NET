using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;
using SSU_ThreeLayer.DAL.Interfaces;
using System.Data.Entity;

namespace SSU_ThreeLayer.DAL
{
    public class UserDAL: IUserDAL
    {
        public void SignUp(User user)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Users.Add(user);
                appContext.SaveChanges();
            }
        }

        public bool SignIn(User user)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Users.Any(p =>
                p.Hashpassword == user.Hashpassword && p.Login == user.Login);
            }
        }

        public void UpdateUser(User user)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Entry<User>(user).State = EntityState.Modified;
                appContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Users
                    .Include(p => p.NameUser)
                    .Include(p => p.DateOfBirth)
                    .Include(p => p.Ratings)
                    .ToList();
            }
        }

        public User GetUserById(int idUser)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Users
                    .Include(p => p.NameUser)
                    .Include(p => p.DateOfBirth)
                    .Include(p => p.ShopList)
                    .FirstOrDefault(p => p.IdUser == idUser);
            }
        }

        public User GetUserByLogin(string login)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Users
                    .Include(p => p.NameUser)
                    .Include(p => p.DateOfBirth)
                    .Include(p => p.ShopList)
                    .FirstOrDefault(p => p.Login == login);
            }
        }

        public User GetUserByName(string nameUser)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Users
                    //.Include(p => p.DateOfBirth)
                    .Include(p => p.ShopList)
                    .FirstOrDefault(p => p.NameUser == nameUser);
            }
        }
    }
}
