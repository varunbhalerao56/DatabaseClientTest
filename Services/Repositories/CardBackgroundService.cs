using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseClientTest.Services
{
    public class CardBackgroundService : Repository<CardBackground>, ICardBackgroundService
    {
        
    }

    public interface ICardBackgroundService: IRepository<CardBackground>
    {
        
    }
}