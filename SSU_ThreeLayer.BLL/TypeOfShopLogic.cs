using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.BLL.Interfaces;
using SSU_ThreeLayer.DAL.Interfaces;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.BLL
{
    public class TypeOfShopLogic:ITypeOfShopLogic
    {
        private ITypeOfShopDAL _typeOfShopDAL;

        public TypeOfShopLogic(ITypeOfShopDAL typeOfShopDAL)
        {
            _typeOfShopDAL = typeOfShopDAL;
        }

        public void AddTypeOfShop(string description, out string alert)
        {
            if (description == null)
            {
                alert = "Couldn't add type of shop! Description field is null.";
                return;
            }
            else if (description.Length >= 256)
            {
                alert = "Description length mustn't be more than 255.";
                return;
            }
            else
            {
                _typeOfShopDAL.AddTypeOfShop(new TypeOfShop()
                {
                    Description = description                   
                });
                alert = "Type of shop added successfully";
            }
        }

        public void DeleteTypeOfShop(TypeOfShop typeOfShop, out string alert)
        {
            _typeOfShopDAL.DeleteTypeOfShop(typeOfShop);
            alert = "Type of shop deleted successfully";
        }

        public void UpdateTypeOfShop(TypeOfShop typeOfShos, string description, out string alert)
        {
            if (description == null)
            {
                alert = "Couldn't add type of shop! Description field is null.";
                return;
            }
            else if (description.Length >= 256)
            {
                alert = "Description length mustn't be more than 255.";
                return;
            }
            else
            {
                typeOfShos.Description = description;
                _typeOfShopDAL.UpdateTypeOfShop(typeOfShos);
                alert = "Type of shop update successfully";
            }
        }

        public IEnumerable<TypeOfShop> GetAllTypeOfShops()
        {
            return _typeOfShopDAL.GetAllTypeOfShops();
        }

        public TypeOfShop GetTypeOfShopById(int idTypeOfShop)
        {
            return _typeOfShopDAL.GetTypeOfShopById(idTypeOfShop);
        }
    }
}
