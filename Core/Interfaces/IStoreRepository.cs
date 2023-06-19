using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStoreRepository
    {
        Task Createstore(DefStore store);
        Task<List<DefStore>> GetAllStores();
        Task<DefStore> GetStore(int id);
    }
}
