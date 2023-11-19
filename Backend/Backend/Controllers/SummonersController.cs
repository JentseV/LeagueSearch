using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using dotenv.net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;
namespace Backend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class SummonersController : ControllerBase
    {

        private string API_KEY_RG = DotEnv.Read()["RIOT_API_KEY"];

        private readonly SummonerContext _context;

        public SummonersController(SummonerContext context)
        {
            _context = context;
        }

        // GET: api/Summoners/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Summoner>> GetSummoner(string name)
        {
            foreach (var claim in User.Claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
            }
            var summoner = await Summoner.GetSummonerFromRiot(name, API_KEY_RG);

            return summoner;
        }

        [HttpGet("/matches")]
        public async Task<ActionResult<List<Match>>> GetSummonerMatches([FromQuery] string name, [FromQuery] int count)
        {

            var summoner = await Summoner.GetSummonerFromRiot(name, API_KEY_RG);
            var puuid = summoner.Puuid;
            List<string> matchIDs = await Match.GetMatchIDs(puuid, count, API_KEY_RG);
            List<Match> matches = await Match.GetMatches(matchIDs, API_KEY_RG);
            return matches;
        }

        [HttpGet("masteries/{count}")]
        public async Task<ActionResult<List<Mastery>>> GetSummonerMasteries(string name, int count)
        {
            var summoner = await Summoner.GetSummonerFromRiot(name, API_KEY_RG);
            var summonerPuuId = summoner.Puuid;
            List<Mastery> masteries = await Mastery.GetMasteries(summonerPuuId, count, API_KEY_RG);
            return masteries;
        }
    }
}
