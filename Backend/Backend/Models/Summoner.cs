using Newtonsoft.Json;
using System.Diagnostics;

namespace Backend.Models
{
    public class Summoner
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Puuid { get; set; }
        public string Name { get; set; }
        public int ProfileIconId { get; set; }
        public Int64 RevisionDate { get; set; }
        public int SummonerLevel { get; set; }

        public List<Mastery> Masteries { get; set; }

        public Summoner()
        {

        }
        public Summoner(string id, string name,string puuid, int profileIconId, Int64 revisionDate, int summonerLevel)
        {
            Id = id;
            Name = name; 
            Puuid = puuid;
            ProfileIconId = profileIconId;
            RevisionDate = revisionDate;
            SummonerLevel = summonerLevel;

        }

        public static async Task<Summoner> GetSummonerFromRiot(string name,string API_KEY_RG)
        {
            Debug.WriteLine("Name " + name);
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{name}?api_key={API_KEY_RG}");
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            
            Summoner s = JsonConvert.DeserializeObject<Summoner>(responseBody);
            
            return s;
        }
        

    }
}
