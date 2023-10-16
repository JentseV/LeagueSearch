using Newtonsoft.Json;

namespace Backend.Models
{
    public class Mastery
    {
        public string Puuid { get; set; }
        public string ChampionId { get; set; }
        public string ChampionLevel { get; set; }
        public string ChampionPoints { get; set; }
        public string LastPlayTime { get; set; }
        public string ChampionPointsSinceLastLevel { get; set; }
        public string ChampionPointsUntilNextLevel { get; set; }
        public string ChestGranted { get; set; }
        public string TokensEarned { get; set; }
        public string SummonerId { get; set; }

        public Mastery(string puuid, string championId, string championLevel, string championPoints, string lastPlayTime, string championPointsSinceLastLevel, string championPointsUntilNextLevel, string chestGranted, string tokensEarned, string summonerId)
        {
            Puuid = puuid;
            ChampionId = championId;
            ChampionLevel = championLevel;
            ChampionPoints = championPoints;
            
            LastPlayTime = lastPlayTime;
            ChampionPointsSinceLastLevel = championPointsSinceLastLevel;
            ChampionPointsUntilNextLevel = championPointsUntilNextLevel;
            ChestGranted = chestGranted;
            TokensEarned = tokensEarned;
            SummonerId = summonerId;
        }


        public static async Task<List<Mastery>> GetMasteries(string summonerId, int count, string API_KEY_RG)
        {
            List<Mastery> matches = new List<Mastery>();
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://euw1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{summonerId}/top?count={count}&api_key={API_KEY_RG}");
            string responsebody = await responseMessage.Content.ReadAsStringAsync();
            matches = JsonConvert.DeserializeObject<List<Mastery>>(responsebody);
            Console.WriteLine(matches);
            return matches;
        }

    }
}
