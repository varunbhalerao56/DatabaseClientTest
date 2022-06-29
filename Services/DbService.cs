using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseClientTest.Services
{
    public class DbService : IDbService
    {
        public DbService()
        {
            UseableItem = new UseableItemService();
            PerformerCertificate = new PerformerCertificateService();
            CardBackground = new CardBackgroundService();
            PlayerData = new PlayerDataService();
        }

        public IPlayerDataService PlayerData { get; private set; }
        public IUseableItemService UseableItem { get; private set; }
        public IPerformerCertificateService PerformerCertificate { get; private set; }
        public ICardBackgroundService CardBackground { get; private set; }

    }

    public interface IDbService
    {
        IPlayerDataService PlayerData { get; }
        IUseableItemService UseableItem { get; }
        IPerformerCertificateService PerformerCertificate { get; }
        ICardBackgroundService CardBackground { get; }
    }
}