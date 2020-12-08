using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.DAL.Interfaces
{
    public interface IAddressDAL
    {
        void AddAddress(Address address);

        void DeleteAddress(Address address);

        void UpdateAddress(Address address);

        IEnumerable<Address> GetAllAddresses();

        Address GetAddressById(int idAddress);
        
    }
}
