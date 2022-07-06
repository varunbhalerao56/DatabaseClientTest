using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DatabaseClientTest.Services;
using Newtonsoft.Json;


IDbService dbService = new DbService();

async Task<bool> IsNewPlayer(string walletAddress)
{
    try
    {
        List<DataItem> dataItems = new List<DataItem>();
        dataItems.Add(new DataItem("walletAddress", walletAddress));

        await dbService.PlayerData.GetSingle("GetPlayer", dataItems);
        Console.WriteLine("Is New Player: false");
        return false;
    }
    catch (System.Exception)
    {
        Console.WriteLine("Is New Player: true");
        return true;
    }
}

async Task<int?> GetPlayerId(string walletAddress)
{
    try
    {
        List<DataItem> dataItems = new List<DataItem>();
        dataItems.Add(new DataItem("walletAddress", walletAddress));

        OlliePlayer player = await dbService.PlayerData.GetSingle("GetPlayer", dataItems);
        Console.WriteLine($"Get Player ID: {player.Id}");
        return player.Id;
    }
    catch (System.Exception)
    {
        Console.WriteLine($"Get Player ID: NULL");
        return null;
    }

}

async Task<OlliePlayer> AddNewPlayer(string walletAddress)
{

    List<DataItem> dataItems = new List<DataItem>();
    dataItems.Add(new DataItem("walletAddress", walletAddress));
    return await dbService.PlayerData.GetSingle("AddNewPlayer", dataItems);
}

async Task<List<UseableItem>> GetUsableItems()
{
    return await dbService.UseableItem.GetAll("GetUsableItems");
}

async Task<List<PerformerCertificate>> GetPerformerCertificates()
{
    return await dbService.PerformerCertificate.GetAll("GetPerformerCertificates");
}

async Task<List<CardBackground>> GetCardBackgrounds()
{
    return await dbService.CardBackground.GetAll("GetCardBackgrounds");
}

async Task<List<PerformerCard>> GetPerformerCards()
{
    return await dbService.PerformerCard.GetAll("GetPerformerCards");
}

async Task<List<OwnPerformerEffectCard>> GetPerformerEffectCards()
{
    return await dbService.PerformerEffectCard.GetAll("GetPerformerEffectCards");
}

async Task AddPerformerCertificateToPlayer(int performerCertificateId, int playerId)
{

    List<DataItem> dataItems = new List<DataItem>();
    dataItems.Add(new DataItem("playerId", playerId));
    dataItems.Add(new DataItem("performerCertificateId", performerCertificateId));
    await dbService.PlayerData.GetSingle("AddPerformerCertificateToPlayer", dataItems);
}

async Task AddUsableItemToPlayer(int usableItemId, int playerId)
{

    List<DataItem> dataItems = new List<DataItem>();
    dataItems.Add(new DataItem("playerId", playerId));
    dataItems.Add(new DataItem("usableItemId", usableItemId));
    var d = await dbService.PlayerData.GetSingle("AddUsableItemToPlayer", dataItems);
}

async Task AddCardBackgroundToPlayer(int cardBackgroundId, int playerId)
{
    List<DataItem> dataItems = new List<DataItem>();
    dataItems.Add(new DataItem("playerId", playerId));
    dataItems.Add(new DataItem("cardBackgroundId", cardBackgroundId));
    await dbService.PlayerData.GetSingle("AddCardBackgroundToPlayer", dataItems);
}

async Task<List<int>> GetUsableItemIdsOwnedByPlayer(int playerId)
{
    List<int> array = new List<int>();

    try
    {
        List<DataItem> dataItems = new List<DataItem>();

        dataItems.Add(new DataItem("playerId", playerId));

        OlliePlayer player = await dbService.PlayerData.GetSingle("GetPlayerFromId", dataItems);
        Console.WriteLine($"Get Player UsableItemIds: {player.UsableItemIds}");
        foreach (var i in player.UsableItemIds)
        {
            Console.WriteLine(i);
        }


        return player.UsableItemIds ?? array;
    }
    catch (System.Exception)
    {
        Console.WriteLine($"Get Player UsableItemIds: NULL");
        return array;
    }

}

async Task<List<int>> GetPerformerCertificateIdsOwnedByPlayer(int playerId)
{

    List<int> array = new List<int>();

    try
    {
        List<DataItem> dataItems = new List<DataItem>();

        dataItems.Add(new DataItem("playerId", playerId));

        OlliePlayer player = await dbService.PlayerData.GetSingle("GetPlayerFromId", dataItems);
        Console.WriteLine($"Get Player PerformerCertificateIds: {player.PerformerCertificateIds}");

        foreach (var i in player.PerformerCertificateIds)
        {
            Console.WriteLine(i);
        }

        return player.PerformerCertificateIds ?? array;
    }
    catch (System.Exception)
    {
        Console.WriteLine($"Get Player PerformerCertificateIds: NULL");
        return array;
    }


}

async Task<List<int>> GetCardBackgroundIdsOwnedByPlayer(int playerId)
{

    List<int> array = new List<int>();

    try
    {
        List<DataItem> dataItems = new List<DataItem>();

        dataItems.Add(new DataItem("playerId", playerId));

        OlliePlayer player = await dbService.PlayerData.GetSingle("GetPlayerFromId", dataItems);
        Console.WriteLine($"Get Player CardBackgroundIds: {player.CardBackgroundIds}");

        foreach (var i in player.CardBackgroundIds)
        {
            Console.WriteLine(i);
        }


        return player.CardBackgroundIds ?? array;
    }
    catch (System.Exception)
    {
        Console.WriteLine($"Get Player CardBackgroundIds: NULL");
        return array;
    }
}

async Task AddDefaultPerformerCardsToPlayer(int playerId)
{
    List<DataItem> dataItems = new List<DataItem>();
    dataItems.Add(new DataItem("playerId", playerId));
    await dbService.PlayerData.GetSingle("AddDefaultPerformerCardsToPlayer", dataItems);
}

async Task AddDefaultPerformerEffectCardsToPlayer(int playerId)
{
    List<DataItem> dataItems = new List<DataItem>();
    dataItems.Add(new DataItem("playerId", playerId));
    await dbService.PlayerData.GetSingle("AddDefaultPerformerEffectCardsToPlayer", dataItems);
}

async Task AddDefaultPlayerEffectCardsToPlayer(int playerId)
{
    List<DataItem> dataItems = new List<DataItem>();
    dataItems.Add(new DataItem("playerId", playerId));
    await dbService.PlayerData.GetSingle("AddDefaultPlayerEffectCardsToPlayer", dataItems);
}

async Task<List<int>> GetPerformerCardIdsOwnedByPlayer(int playerId)
{
    List<int> array = new List<int>();

    try
    {
        List<DataItem> dataItems = new List<DataItem>();

        dataItems.Add(new DataItem("playerId", playerId));

        OlliePlayer player = await dbService.PlayerData.GetSingle("GetPlayerFromId", dataItems);
        Console.WriteLine($"Get Player PerformerCards: {player.PerformerCards}");
        foreach (var i in player.PerformerCards)
        {
            Console.WriteLine(i);
        }


        return player.PerformerCards ?? array;
    }
    catch (System.Exception)
    {
        Console.WriteLine($"Get Player PerformerCards: NULL");
        return array;
    }

}

async Task<List<int>> GetPerformerEffectCardIdsOwnedByPlayer(int playerId)
{

    List<int> array = new List<int>();

    try
    {
        List<DataItem> dataItems = new List<DataItem>();

        dataItems.Add(new DataItem("playerId", playerId));

        OlliePlayer player = await dbService.PlayerData.GetSingle("GetPlayerFromId", dataItems);
        Console.WriteLine($"Get Player PerformerEffectCards: {player.PerformerEffectCards}");

        foreach (var i in player.PerformerEffectCards)
        {
            Console.WriteLine(i);
        }

        return player.PerformerEffectCards ?? array;
    }
    catch (System.Exception)
    {
        Console.WriteLine($"Get Player PerformerEffectCards: NULL");
        return array;
    }


}

async Task<List<int>> GetPlayerEffectCardIdsOwnedByPlayer(int playerId)
{

    List<int> array = new List<int>();

    try
    {
        List<DataItem> dataItems = new List<DataItem>();

        dataItems.Add(new DataItem("playerId", playerId));

        OlliePlayer player = await dbService.PlayerData.GetSingle("GetPlayerFromId", dataItems);
        Console.WriteLine($"Get Player PlayerEffectCard: {player.PlayerEffectCards}");

        foreach (var i in player.PlayerEffectCards)
        {
            Console.WriteLine(i);
        }


        return player.PlayerEffectCards ?? array;
    }
    catch (System.Exception)
    {
        Console.WriteLine($"Get Player PlayerEffectCards: NULL");
        return array;
    }
}

await AddNewPlayer("C123");
Console.WriteLine("---------------");
await GetPlayerId("C123");
Console.WriteLine("---------------");
await IsNewPlayer("C123");
Console.WriteLine("---------------");
await GetCardBackgrounds();
Console.WriteLine("---------------");
await GetUsableItems();
Console.WriteLine("---------------");
await GetPerformerCertificates();
Console.WriteLine("---------------");
await GetPerformerCards();
Console.WriteLine("---------------");
await GetPerformerEffectCards();
Console.WriteLine("---------------");
await AddPerformerCertificateToPlayer(12, 1);
Console.WriteLine("---------------");
await AddUsableItemToPlayer(2, 1);
Console.WriteLine("---------------");
await AddCardBackgroundToPlayer(3, 1);
Console.WriteLine("---------------");
await GetPerformerCertificateIdsOwnedByPlayer(1);
Console.WriteLine("---------------");
await GetUsableItemIdsOwnedByPlayer(1);
Console.WriteLine("---------------");
await GetCardBackgroundIdsOwnedByPlayer(1);
Console.WriteLine("---------------");
await AddDefaultPerformerCardsToPlayer(1);
Console.WriteLine("---------------");
await AddDefaultPerformerEffectCardsToPlayer(1);
Console.WriteLine("---------------");
await AddDefaultPlayerEffectCardsToPlayer(1);
Console.WriteLine("---------------");
await GetPerformerCardIdsOwnedByPlayer(1);
Console.WriteLine("---------------");
await GetPerformerEffectCardIdsOwnedByPlayer(1);
Console.WriteLine("---------------");
await GetPlayerEffectCardIdsOwnedByPlayer(1);
Console.WriteLine("---------------");



