using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.BLL.Interfaces
{
    public interface IAddressLogic
    {
        void AddAddress(string country, string city, string street, string build, out string alert);

        void DeleteAddress(Address address, out string alert);

        void UpdateAddress(Address address, string country, string city, string street, string build, out string alert);

        IEnumerable<Address> GetAllAddresses();

        Address GetAddressById(int idAddress);
        
    }
}
