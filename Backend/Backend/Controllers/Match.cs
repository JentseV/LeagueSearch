using Backend.Models;
using Microsoft.CodeAnalysis;
using System.Dynamic;
using System.Xml.Linq;
using Newtonsoft.Json;
using Backend.Models.Matches;
using System.Diagnostics;

namespace Backend.Controllers
{
    public class Match
    {
        public MetadataDto metaData { get; set; }
        public InfoDto info { get; set; }

        public static async Task<List<string>> GetMatchIDs(string puuid, int count, string API_KEY)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage httpResponse = await client.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/{puuid}/ids?start=0&count={count}&api_key={API_KEY}");
                Debug.WriteLine(puuid);
                string responseBody = await httpResponse.Content.ReadAsStringAsync();
                Debug.WriteLine(responseBody);
                var matchIDs = JsonConvert.DeserializeObject<List<string>>(responseBody);
                return matchIDs;
            }
            catch
            {
                Console.WriteLine("fuckup in getMatchIDs");
                throw new Exception("GetMachIDs() error");
            }
        }

        public static async Task<List<Match>> GetMatches(List<string> matchIDs, string API_KEY)
        {
            try
            {
                var matches = new List<Match>();
                HttpClient httpClient = new HttpClient();
                foreach (var match in matchIDs)
                {
                    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/{match}?api_key={API_KEY}");
                    var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                    var matchesDetails = JsonConvert.DeserializeObject<Match>(responseBody);
                    matches.Add(matchesDetails);
                }
                return matches;
            }
            catch
            {
                Console.WriteLine("Fuckup in get matches");
                throw new Exception("GetMaches() error");
                
            }
        }
    }
}
