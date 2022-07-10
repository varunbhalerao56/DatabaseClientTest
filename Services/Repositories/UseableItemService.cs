using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseClientTest.Services;

namespace DatabaseClientTest.Services
{
    public class UseableItemService : Repository<UseableItem>, IUseableItemService
    {

    }

    public interface IUseableItemService : IRepository<UseableItem>
    {
        
    }
}