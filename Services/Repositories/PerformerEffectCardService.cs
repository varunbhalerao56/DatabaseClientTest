using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseClientTest.Services
{
    public class PerformerEffectCardService : Repository<OwnPerformerEffectCard>, IPerformerEffectCardService
    {
        
    }
    public interface IPerformerEffectCardService : IRepository<OwnPerformerEffectCard>
    {
        
    }
}