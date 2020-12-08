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
    public class AddressLogic:IAddressLogic
    {
        private IAddressDAL _addressDAL;

        public AddressLogic(IAddressDAL addressDAL)
        {
            _addressDAL = addressDAL;
        }

        public void AddAddress(string country, string city, string street, string build, out string alert)
        {
            if (country == null || city == null || street == null || build == null)
            {
                alert = "Couldn't add address! One of the fields is null.";
                return;
            }
            else
            {
                _addressDAL.AddAddress(new Address()
                {
                    Country = country,
                    City = city,
                    Street = street,
                    Build = build
                });
                alert = "Address added successfully";
            }
        }

        public void DeleteAddress(Address address, out string alert)
        {
            _addressDAL.DeleteAddress(address);
            alert = "Address deleted successfully";
        }

        public void UpdateAddress(Address address, string country, string city, string street, string build, out string alert)
        {
            if (country == null || city == null || street == null || build == null)
            {
                alert = "Couldn't update address! One of the fields is null.";
                return;
            }
            else
            {
                address.Country = country;
                address.City = city;
                address.Street = street;
                address.Build = build;
                _addressDAL.UpdateAddress(address);
                alert = "Address update successfully";
            }
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return _addressDAL.GetAllAddresses();
        }

        public Address GetAddressById(int idAddress)
        {
            return _addressDAL.GetAddressById(idAddress);
        }
    }
}
