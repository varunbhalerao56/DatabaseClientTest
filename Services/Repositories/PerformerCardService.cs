using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseClientTest.Services
{
    public class PerformerCardService : Repository<PerformerCard>, IPerformerCardService
    {
        
    }

    public interface IPerformerCardService : IRepository<PerformerCard>
    {
        
    }
}