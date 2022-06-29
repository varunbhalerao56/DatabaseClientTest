using System.Collections;
using System.Collections.Generic;
public abstract class Card
{
    protected Card(
        int id,
        string creatorWalletAddress,
        string transactionHash,
        string tokenId,
        string name,
        int actionCostForSummon,
        string imageAddress)
    {
        Id = id;
        Name = name;
        ActionCostForSummon = actionCostForSummon;
        ImageAddress = imageAddress;
    }

    public int Id;
    public string CreatorWalletAddress;
    public string TransactionHash;
    public string TokenId;
    public string Name;
    public int ActionCostForSummon;
    public string ImageAddress;
}
public class PerformerCard : Card
{
    public enum Type
    {
        COMEDIAN,
        DANCER,
        MARTIAL_ARTIST
    }


    public PerformerCard(int id, string creatorWalletAddress, string transactionHash, string tokenId, string name, int actionCostForSummon, string imageAddress, Type performerType, int cardQuality, int defaultMaxHealth, int defaultAttackPower, string backgroundAddress)
        : base(id, creatorWalletAddress, transactionHash, tokenId, name, actionCostForSummon, imageAddress)
    {
        PerformerType = performerType;
        CardQuality = cardQuality;
        DefaultMaxHealth = defaultMaxHealth;
        DefaultAttackPower = defaultAttackPower;
        BackgroundAddress = backgroundAddress;
    }

    public Type PerformerType;
    public int CardQuality;
    public int DefaultMaxHealth;
    public int DefaultAttackPower;
    public string BackgroundAddress;

}


public abstract class Item
{
    public int Id;
    public string Name;
    public string ImageAddress;

    protected Item(int id, string name, string imageAddress)
    {
        Id = id;
        Name = name;
        ImageAddress = imageAddress;
    }
}




public class UseableItem : Item
{
    public PerformerCard.Type BestType;
    public int Quality;

    public UseableItem(int id, string name, string imageAddress, PerformerCard.Type bestType, int quality) : base(id, name, imageAddress)
    {
        BestType = bestType;
        Quality = quality;
    }

     public override string ToString()  {
        return $"{Id}, {Name}, {BestType}, {Quality}, {ImageAddress},";
     }

}

public class PerformerCertificate : Item
{
    public PerformerCard.Type Type;

    public PerformerCertificate(int id, string name, string imageAddress, PerformerCard.Type type) : base(id, name, imageAddress)
    {
        Type = type;
    }
       public override string ToString()  {
        return $"{Id}, {Name}, {Type}, {ImageAddress}";
     }

}

public class CardBackground : Item
{
    public int Quality;

    public CardBackground(int id, string name, string imageAddress, int quality) : base(id, name, imageAddress)
    {
        Quality = quality;
    }

     public override string ToString()  {
        return $"{Id}, {Name}, {Quality}, {ImageAddress}";
     }

}

public class OlliePlayer {

    public int Id;
    public string WalletAddress;

    public OlliePlayer(int id, string walletAddress)
    {
        Id = id;
        WalletAddress = walletAddress;
    }

         public override string ToString()  {
        return $"{Id}, {WalletAddress}";
     }
}


//  public List<int> UsableItemsIds;
//     public List<int> PerformerCertificateIds;
//     public List<int> CardBackgroundIds;
//     public List<int> PerformerCardIds;
//     public List<int> PerformerEffectCardIds;
//     public List<int> PlayerEffectCardIds;

//     public OlliePlayer(string id, List<int> usableItemsIds, List<int> performerCertificateIds, List<int> cardBackgroundIds, List<int> performerCardIds, List<int> performerEffectCardIds, List<int> playerEffectCardIds)
//     {
//         Id = id;
//         UsableItemsIds = usableItemsIds;
//         PerformerCertificateIds = performerCertificateIds;
//         CardBackgroundIds = cardBackgroundIds;
//         PerformerCardIds = performerCardIds;
//         PerformerEffectCardIds = performerEffectCardIds;
//         PlayerEffectCardIds = playerEffectCardIds;
//     }