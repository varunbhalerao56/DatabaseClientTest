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
        await dbService.PlayerData.GetSingle("getPlayerId", "walletAddress", walletAddress);
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
        OlliePlayer player = await dbService.PlayerData.GetSingle("getPlayerId", "walletAddress", walletAddress);
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
    return await dbService.PlayerData.GetSingle("addNewPlayer", "walletAddress", walletAddress);
}

async Task<List<UseableItem>> GetUsableItems()
{
    return await dbService.UseableItem.GetAll("getUsableItems");
}

async Task<List<PerformerCertificate>> GetPerformerCertificates()
{
    return await dbService.PerformerCertificate.GetAll("getPerformerCertificates");
}

async Task<List<CardBackground>> GetCardBackgrounds()
{
    return await dbService.CardBackground.GetAll("getCardBackgrounds");
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





