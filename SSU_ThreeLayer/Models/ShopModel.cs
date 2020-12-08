using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSU_ThreeLayer.BLL.Interfaces;
using SSU_ThreeLayer.Entities;
using SSU_ThreeLayer.App_Start;
using SSU_ThreeLayer.ViewModel;
using AutoMapper;

namespace SSU_ThreeLayer.Models
{
    public class ShopModel
    {
        IAddressLogic _addressLogic;
        IUserLogic _userLogic;
        ITypeOfShopLogic _typeOfShopLogic;
        IShopLogic _shopLogic;
        IRatingLogic _ratingLogic;
        IMapper _mapper = AutoMapperWebConfig.Config.CreateMapper();


        public ShopModel(IAddressLogic addressLogic, ITypeOfShopLogic typeOfShopLogic, IShopLogic shopLogic, IUserLogic userLogic, IRatingLogic ratingLogic)
        {
            _addressLogic = addressLogic;
            _typeOfShopLogic = typeOfShopLogic;
            _shopLogic = shopLogic;
            _userLogic = userLogic;
            _ratingLogic = ratingLogic;
        }

        //Address
        public void AddAddress(AddressVM address)
        {
            _addressLogic.AddAddress(address.Country, address.City, address.Street, address.Build, out var alert);
        }

        public void DeleteAddress(int idAddress)
        {
            _addressLogic.DeleteAddress(_addressLogic.GetAddressById(idAddress), out var alert);
        }

        public void UpdateAddress(string country, string city, string street, string build, int idAddress)
        {
            _addressLogic.UpdateAddress(_addressLogic.GetAddressById(idAddress), country, city, street, build, out var alert);
        }

        //Address + shop
        public IEnumerable<VisShopVM> GetShopsWithAddress(string country, string city, string street, string build)
        {
            return _mapper.Map<IEnumerable<VisShopVM>>(_shopLogic.GetAllShops().Where(e => e.address.Country == country && e.address.City == city && e.address.Street == street && e.address.Build == build));
        }


        //TypeOfShop
        public void AddTypeOfShop(TypeOfShopVM typeOfShop)
        {
            _typeOfShopLogic.AddTypeOfShop(typeOfShop.Description, out var alert);
        }

        public void DeleteTypeOfShop(int idTypeOfShop)
        {
            _typeOfShopLogic.DeleteTypeOfShop(_typeOfShopLogic.GetTypeOfShopById(idTypeOfShop), out var alert);
        }

        public void UpdateTypeOfShop(string description, int idTypeOfShop)
        {
            _typeOfShopLogic.UpdateTypeOfShop(_typeOfShopLogic.GetTypeOfShopById(idTypeOfShop), description,  out var alert);
        }

        //TypeOfShop + shop
        public IEnumerable<VisShopVM> GetShopsWithTypeOfShop(string description)
        {
            return _mapper.Map<IEnumerable<VisShopVM>>(_shopLogic.GetAllShops().Where(e => e.address.Country == description));
        }


        //Shop
        public void AddShop(ShopVM shop)
        {
            _shopLogic.AddShop(shop.NameShop, shop.IdTypeOfShop, shop.IdAddress, out var alert);
        }

        public void DeleteShop(int idShop)
        {
            _shopLogic.DeleteShop(_shopLogic.GetShopById(idShop), out var alert);
        }

        public void UpdateShop(string nameShop, int idTypeOfShop, int idAddress, int idShop)
        {
            _shopLogic.UpdateShop(_shopLogic.GetShopById(idShop), nameShop, idTypeOfShop, idAddress, out var alert);
        }
        //Shop + users
        public IEnumerable<VisUserVM> GetUsersByShop(int idShop)
        {
            return _mapper.Map<IEnumerable<VisUserVM>>(_shopLogic.GetAllShops().FirstOrDefault(e => e.IdShop == idShop).UserList);
        }


        //User
        public VisUserVM GetUserById(int idUser)
        {
            return _mapper.Map<VisUserVM>(_userLogic.GetUserById(idUser));
        }

        public VisUserVM GetUserByName(string nameUser)
        {
            return _mapper.Map<VisUserVM>(_userLogic.GetUserByName(nameUser));
        }

        public void UpdateUser(string nameUser, string newNameUser, string login, string newlogin, string password, string newPassword)
        {
            _userLogic.UpdateUser(nameUser, newNameUser, login, newlogin, password, newPassword, out var alert);
        }

        
        public void SignUp(string login, string password, string doublePassword)
        {
            _userLogic.SignUp(login, password, doublePassword, out var alert);
        }

        public bool SignIn(string login, string password)
        {
            return _userLogic.SignIn(login, password, out var alert);
        }

        public IEnumerable<VisShopVM> GetShopsOfUser(string nameUser)
        {
            return _mapper.Map<IEnumerable<VisShopVM>>(_userLogic.GetUserByName(nameUser).ShopList);
        }

        public IEnumerable<VisRatingVM> GetRatingsOfUser(string nameUser)
        {
            return _mapper.Map<IEnumerable<VisRatingVM>>(_userLogic.GetUserByName(nameUser).Ratings);
        }

        //Rating
        public void SetRate(int idUser, int idShop, int rate)
        {
            _ratingLogic.SetRate(idUser, idShop, rate, out var alert);
        }

        public int GetShopRateById(int idShop)
        {
            return _ratingLogic.GetShopRateById(idShop);
        }
        
        //Rating + shop
        public IEnumerable<VisShopVM> GetAllShopsWithRate(int rate)
        {
            return _mapper.Map<IEnumerable<VisShopVM>>(_ratingLogic.GetAllShopsWithRate(rate));
        }

        
    }
}