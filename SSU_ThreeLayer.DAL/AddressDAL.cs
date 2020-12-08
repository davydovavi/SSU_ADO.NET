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
    public class AddressDAL : IAddressDAL
    {
        public void AddAddress(Address address)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Addresses.Add(address);
                appContext.SaveChanges();
            }
        }

        public void DeleteAddress(Address address)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Entry<Address>(address).State = EntityState.Deleted;
                appContext.SaveChanges();
            }
        }

        public void UpdateAddress(Address address)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Entry<Address>(address).State = EntityState.Modified;
                appContext.SaveChanges();
            }
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Addresses
                    .Include(p => p.Country)
                    .Include(p => p.City)
                    .Include(p => p.Street)
                    .Include(p => p.Build)
                    .ToList();
            }
        }

        public Address GetAddressById(int idAddress)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Addresses.FirstOrDefault(p => p.IdAddress == idAddress);
            }
        }
    }
}
