using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseClientTest.Services
{
    public class PlayerDataService : Repository<OlliePlayer>, IPlayerDataService
    {
        
    }

    public interface IPlayerDataService: IRepository<OlliePlayer>
    {
        
    }
}