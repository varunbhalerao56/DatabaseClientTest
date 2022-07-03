using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseClient.Services
{
    public class DbService : IDbService
    {
        public DbService()
        {
            UseableItem = new UseableItemService();
            PerformerCertificate = new PerformerCertificateService();
            CardBackground = new CardBackgroundService();
            PlayerData = new PlayerDataService();
            PerformerCard = new PerformerCardService();
            PerformerEffectCard = new PerformerEffectCardService();
        }

        public IPlayerDataService PlayerData { get; private set; }
        public IUseableItemService UseableItem { get; private set; }
        public IPerformerCertificateService PerformerCertificate { get; private set; }
        public ICardBackgroundService CardBackground { get; private set; }
        public IPerformerCardService PerformerCard { get; private set; }
        public IPerformerEffectCardService PerformerEffectCard { get; private set; }

    }

    public interface IDbService
    {
        IPlayerDataService PlayerData { get; }
        IUseableItemService UseableItem { get; }
        IPerformerCertificateService PerformerCertificate { get; }
        ICardBackgroundService CardBackground { get; }
        IPerformerCardService PerformerCard { get; }
        IPerformerEffectCardService PerformerEffectCard { get;}
    }

}