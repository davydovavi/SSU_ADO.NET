using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SSU_ThreeLayer.Models;
using SSU_ThreeLayer.ViewModel;

namespace SSU_ThreeLayer.Controllers
{
    public class HomeController : Controller
    {
        ShopModel _shopModel;

        public HomeController(ShopModel shopModel)
        {
            _shopModel = shopModel;
        }

        public ActionResult UserProfile()
        {
            return View("~/Views/UserProfile.cshtml");
        }

        public ActionResult GetShopsOfUser()
        {
            return View("~/Views/Index.cshtml", _shopModel.GetShopsOfUser(User.Identity.Name));
        }

        public ActionResult GetRatingsOfUser() //GetShopsWithTypeOfShop, GetUsersByShop, GetAllShopsWithRate
        {
            return View("~/Views/Shops.cshtml", _shopModel.GetRatingsOfUser(User.Identity.Name));
        }

        public ActionResult LotManagment()//
        {
            return View("~/Views/Main.cshtml", _shopModel.GetUserByName(User.Identity.Name));
        }

        public ActionResult LogIn()
        {
            return View("~/Views/LogIn.cshtml");
        }
        public ActionResult LogOut()
        {
            return View("~/Views/LogOut.cshtml");
        }

        //Address
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAddress(string country, string city, string street, string build)
        {
            _shopModel.AddAddress(new AddressVM()
            {
                Country = country,
                City = city,
                Street = street,
                Build = build
            });

            return Redirect(nameof(LotManagment));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAddress(int idAddress)
        {
            _shopModel.DeleteAddress(idAddress);

            return Redirect(nameof(LotManagment));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAddress(string country, string city, string street, string build, int idAddress)
        {
            
            _shopModel.UpdateAddress(country, city, street, build, idAddress);

            return Redirect(nameof(LotManagment));
        }


        public ActionResult GetShopsWithAddress(string country, string city, string street, string build)
        {
            return View("~/Views/Main.cshtml", _shopModel.GetShopsWithAddress(country, city, street, build));
        }


        //TypeOfShop
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTypeOfShop(string description)
        {
            _shopModel.AddTypeOfShop(new TypeOfShopVM()
            {
                Description = description
            });

            return Redirect(nameof(LotManagment));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTypeOfShop(int idTypeOfShop)
        {
            _shopModel.DeleteTypeOfShop(idTypeOfShop);

            return Redirect(nameof(LotManagment));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTypeOfShop(string description, int idTypeOfShop)
        {

            _shopModel.UpdateTypeOfShop(description, idTypeOfShop);

            return Redirect(nameof(LotManagment));
        }


        public ActionResult GetShopsWithTypeOfShop(string description)
        {
            return View("~/Views/Main.cshtml", _shopModel.GetShopsWithTypeOfShop(description));
        }

        //Shop
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddShop(string nameShop, int idTypeOfShop, int idAddress)
        {
            _shopModel.AddShop(new ShopVM()
            {
                NameShop = nameShop,
                IdTypeOfShop = idTypeOfShop,
                IdAddress = idAddress
            });

            return Redirect(nameof(LotManagment));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteShop(int idShop)
        {
            _shopModel.DeleteShop(idShop);

            return Redirect(nameof(LotManagment));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateShop(string nameShop, int idTypeOfShop, int idAddress, int idShop)
        {

            _shopModel.UpdateShop(nameShop, idTypeOfShop, idAddress, idShop);

            return Redirect(nameof(LotManagment));
        }


        public ActionResult GetUsersByShop(int idShop)
        {
            return View("~/Views/Main.cshtml", _shopModel.GetUsersByShop(idShop));
        }

        //User
        public ActionResult GetUserById(int idUser)
        {
            _shopModel.GetUserById(idUser);
            return Redirect(nameof(UserProfile));
        }
        public ActionResult GetUserByName(string nameUser)
        {
            _shopModel.GetUserByName(nameUser);
            return Redirect(nameof(UserProfile));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(string newName, string login, string newlogin, string password, string newPassword)
        {
            _shopModel.UpdateUser(User.Identity.Name, newName, login, newlogin, password, newPassword);
            return Redirect(nameof(UserProfile));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(string login, string password, string doublePassword)
        {
            if (password == doublePassword)
            {
                _shopModel.SignUp(login, password, doublePassword);
            }

            return RedirectToAction(nameof(LogIn));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(string login, string password)
        {
            if (_shopModel.SignIn(login, password))
            {
                FormsAuthentication.SetAuthCookie(login, true);
                return RedirectToAction(nameof(GetShopsOfUser));//UserProfile
            }

            return RedirectToAction(nameof(LogIn));
        }

        //Rating

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetRate(int idUser, int idShop, int rate)
        {
            _shopModel.SetRate(idUser, idShop, rate);

            return RedirectToAction(nameof(GetShopsOfUser));//GetRatingsOfUser //lotManagement
        }

        public ActionResult GetShopRateById(int idShop)
        {
            _shopModel.GetShopRateById(idShop);
            return Redirect(nameof(GetRatingsOfUser));
        }

        public ActionResult GetAllShopsWithRate(int rate)
        {
            _shopModel.GetAllShopsWithRate(rate);
            return Redirect(nameof(GetShopsOfUser));
        }














    }
}