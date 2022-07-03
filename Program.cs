using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DatabaseClient.Services;
using Newtonsoft.Json;

IDbService dbService = new DbService();

async Task<bool> IsNewPlayer(string walletAddress)
{
    try
    {
        await dbService.PlayerData.GetSingle("getPlayer", "walletAddress", walletAddress);
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
        OlliePlayer player = await dbService.PlayerData.GetSingle("getPlayer", "walletAddress", walletAddress);
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

async Task<List<PerformerCard>> GetPerformerCards()
{
    return await dbService.PerformerCard.GetAll("getPerformerCards");
}
async Task<List<OwnPerformerEffectCard>> GetPerformerEffectCards()
{
    return await dbService.PerformerEffectCard.GetAll("getPerformerEffectCards");
}

await AddNewPlayer("C123");
//Console.WriteLine("---------------");
//await GetPlayerId("C123");
//Console.WriteLine("---------------");
//await IsNewPlayer("C123");
//Console.WriteLine("---------------");
//await GetCardBackgrounds();
//Console.WriteLine("---------------");
//await GetUsableItems();
//Console.WriteLine("---------------");
//await GetPerformerCertificates();
//Console.WriteLine("---------------");
//var perfCard = await GetPerformerCards();
//foreach (var card in perfCard)
//{
//    Console.WriteLine($"{card.Id}, {card.Name}, {card.PerformerType}");
//}
//Console.WriteLine("---------------");
//var perfEffectCard = await GetPerformerEffectCards();
//foreach (var card in perfEffectCard)
//{
//    Console.WriteLine($"{card.Id}, {card.Name}, {card.ApplicableType}, {card.ApplicableEffect}, {card.ImageAddress}");
//}

Console.WriteLine("-------TEST--------");


async Task AddPerformerCertificateToPlayer(int performerCertificateId, int playerId)
{
    await dbService.PlayerData.GetSingle("addPerformerCertificateToPlayer", "playerId", playerId.ToString(), "performerCertificateId", performerCertificateId.ToString());
}

await AddPerformerCertificateToPlayer(1, 39);
await AddPerformerCertificateToPlayer(2, 39);
await AddPerformerCertificateToPlayer(3, 39);






