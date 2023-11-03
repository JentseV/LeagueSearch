using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using NuGet.Protocol;
using System.Web.Http.Cors;
using Humanizer.Localisation.DateToOrdinalWords;
using System.Xml.Linq;
using dotenv.net;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonersController : ControllerBase
    {
        
        private string API_KEY_RG = DotEnv.Read()["RIOT_API_KEY"];

        private readonly SummonerContext _context;

        public SummonersController(SummonerContext context)
        {
            _context = context;
        }

        // GET: api/Summoners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Summoner>>> GetSummoners()
        {
          if (_context.Summoners == null)
          {
              return NotFound();
          }
            return await _context.Summoners.ToListAsync();
        }

        // GET: api/Summoners/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Summoner>> GetSummoner(string name)
        {
          if (_context.Summoners == null)
          {
              return NotFound();
          }
            var summoner = await Summoner.GetSummonerFromRiot(name, API_KEY_RG);

            Console.WriteLine(API_KEY_RG);
            
            if (summoner == null)
            {
                return NotFound();
            }

            return summoner;
        }

        [HttpGet("matches")]
        public async Task<ActionResult<List<Match>>> GetSummonerMatches([FromQuery] string name, [FromQuery]int count)
        {
            
            var summoner = await Summoner.GetSummonerFromRiot(name, API_KEY_RG);
            var puuid = summoner.Puuid;
            List<string> matchIDs = await Match.GetMatchIDs(puuid, count,API_KEY_RG);
            List<Match> matches = await Match.GetMatches(matchIDs,API_KEY_RG);
            return matches;
        }

        [HttpGet("masteries/{count}")]
        public async Task<ActionResult<List<Mastery>>> GetSummonerMasteries( string name,int count)
        {
            var summoner = await Summoner.GetSummonerFromRiot(name, API_KEY_RG);
            var summonerPuuId = summoner.Puuid;
            List<Mastery> masteries = await Mastery.GetMasteries(summonerPuuId,count , API_KEY_RG);
            return masteries;
        }

        // PUT: api/Summoners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSummoner(string id, Summoner summoner)
        {
            if (id != summoner.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(summoner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SummonerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Summoners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Summoner>> PostSummoner(Summoner summoner)
        {
            if (_context.Summoners == null)
            {
                return Problem("Entity set 'SummonerContext.Summoners'  is null.");
            }
            _context.Summoners.Add(summoner);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSummoner", new { id = summoner.Id }, summoner);
            return CreatedAtAction(nameof(GetSummoner), new { id = summoner.Id }, summoner);
        }

        // DELETE: api/Summoners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSummoner(int id)
        {
            if (_context.Summoners == null)
            {
                return NotFound();
            }
            var summoner = await _context.Summoners.FindAsync(id);
            if (summoner == null)
            {
                return NotFound();
            }

            _context.Summoners.Remove(summoner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SummonerExists(string id)
        {
            return (_context.Summoners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
