using System;

namespace Backend.Models.Matches
{
    public class ParticipantDto
    {
        
        public int Assists { get; set; }
        public int BaronKills { get; set; }
        public int BountyLevel { get; set; }
        public int ChampExperience { get; set; }
        public int ChampLevel { get; set; }
        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public int ChampionTransform { get; set; }
        public int ConsumablesPurchased { get; set; }
        public int DamageDealtToBuildings { get; set; }
        public int DamageDealtToObjectives { get; set; }
        public int DamageDealtToTurrets { get; set; }
        public int DamageSelfMitigated { get; set; }
        public int Deaths { get; set; }
        public int DetectorWardsPlaced { get; set; }
        public int DoubleKills { get; set; }
        public int DragonKills { get; set; }
        public bool FirstBloodAssist { get; set; }
        public bool FirstBloodKill { get; set; }
        public bool FirstTowerAssist { get; set; }
        public bool FirstTowerKill { get; set; }
        public bool GameEndedInEarlySurrender { get; set; }
        public bool GameEndedInSurrender { get; set; }
        public int GoldEarned { get; set; }
        public int GoldSpent { get; set; }
        public string IndividualPosition { get; set; }
        public int InhibitorKills { get; set; }
        public int InhibitorTakedowns { get; set; }
        public int inhibitorsLost { get; set; }
        public int Item0 { get; set; }
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public int Item3 { get; set; }
        public int Item4 { get; set; }
        public int Item5 { get; set; }
        public int Item6 { get; set; }
        public int ItemsPurchased { get; set; }
        public int KillingSprees { get; set; }
        public int Kills { get; set; }
        public string Lane { get; set; }
        public int LargestCriticalStrike { get; set; }
        public int LargestKillingSpree { get; set; }
        public int LargestMultiKill { get; set; }
        public int LongestTimeSpentLiving { get; set; }
        public int MagicDamageDealt { get; set; }
        public int MagicDamageDealtToChampions { get; set; }
        public int MagicDamageTaken { get; set; }
        public int NeutralMinionsKilled { get; set; }
        public int NexusKills { get; set; }
        public int NexusTakedowns { get; set; }
        public int NexusLost { get; set; }
        public int ObjectivesStolen { get; set; }
        public int ObjectivesStolenAssists { get; set; }
        public int ParticipantId { get; set; }
        public int PentaKills { get; set; }
        public PerksDto Perks { get; set; }
        public int PhysicalDamageDealt { get; set; }
        public int PhysicalDamageDealtToChampions { get; set; }
        public int PhysicalDamageTaken { get; set; }
        public int ProfileIcon { get; set; }
        public string Puuid { get; set; }
        public int QuadraKills { get; set; }
        public string RiotIdName { get; set; }
        public string RiotIdTagline { get; set; }
        public string Role { get; set; }
        public int SightWardsBoughtInGame { get; set; }
        public int Spell1Casts { get; set; }
        public int Spell2Casts { get; set; }
        public int Spell3Casts { get; set; }
        public int Spell4Casts { get; set; }
        public int Summoner1Casts { get; set; }
        public int Summoner1Id { get; set; }
        public int Summoner2Casts { get; set; }
        public int Summoner2Id { get; set; }
        public string SummonerId { get; set; }
        public int SummonerLevel { get; set; }
        public string SummonerName { get; set; }
        public bool TeamEarlySurrendered { get; set; }
        public int TeamId { get; set; }
        public string TeamPosition { get; set; }
        public int TimeCCingOthers { get; set; }
        public int TimePlayed { get; set; }
        public int TotalDamageDealt { get; set; }
        public int TotalDamageDealtToChampions { get; set; }
        public int TotalDamageShieldedOnTeammates { get; set; }
        public int TotalDamageTaken { get; set; }
        public int TotalHeal { get; set; }
        public int TotalHealsOnTeammates { get; set; }
        public int TotalMinionsKilled { get; set; }
        public int TotalTimeCCDealt { get; set; }
        public int TotalTimeSpentDead { get; set; }
        public int TotalUnitsHealed { get; set; }
        public int TripleKills { get; set; }
        public int TrueDamageDealt { get; set; }
        public int TrueDamageDealtToChampions { get; set; }
        public int TrueDamageTaken { get; set; }
        public int TurretKills { get; set; }
        public int TurretTakedowns { get; set; }
        public int TurretsLost { get; set; }
        public int UnrealKills { get; set; }
        public int VisionScore { get; set; }
        public int VisionWardsBoughtInGame { get; set; }
        public int WardsKilled { get; set; }
        public int WardsPlaced { get; set; }
        public bool Win { get; set; }


        public ParticipantDto(
            int assists, int baronKills, int bountyLevel, int champExperience, int champLevel,
            int championId, string championName, int championTransform, int consumablesPurchased,
            int damageDealtToBuildings, int damageDealtToObjectives,
            int damageDealtToTurrets, int damageSelfMitigated, int deaths, int detectorWardsPlaced, int doubleKills, int dragonKills,
            bool firstBloodAssist, bool firstBloodKill, bool firstTowerAssist, bool firstTowerKill,
            bool gameEndedInEarlySurrender, bool gameEndedInSurrender, int goldEarned, int goldSpent,
            string individualPosition, int inhibitorKills, int inhibitorTakedowns, int inhibitorsLost,
            int item0, int item1, int item2, int item3, int item4, int item5, int item6, int itemsPurchased,
            int killingSprees, int kills, string lane, int largestCriticalStrike, int largestKillingSpree,
            int largestMultiKill, int longestTimeSpentLiving, int magicDamageDealt, int magicDamageDealtToChampions,
            int magicDamageTaken, int neutralMinionsKilled, int nexusKills, int nexusTakedowns, int nexusLost,
            int objectivesStolen, int objectivesStolenAssists, int participantId, int pentaKills, PerksDto perks,
            int physicalDamageDealt, int physicalDamageDealtToChampions, int physicalDamageTaken, int profileIcon,
            string puuid, int quadraKills, string riotIdName, string riotIdTagline, string role, int sightWardsBoughtInGame,
            int spell1Casts, int spell2Casts, int spell3Casts, int spell4Casts, int summoner1Casts, int summoner1Id,
            int summoner2Casts, int summoner2Id, string summonerId, int summonerLevel, string summonerName,
            bool teamEarlySurrendered, int teamId, string teamPosition, int timeCCingOthers,
            int timePlayed, int totalDamageDealt, int totalDamageDealtToChampions
            , int totalDamageShieldedOnTeammates, int totalDamageTaken,
            int totalHeal, int totalHealsOnTeammates, int totalMinionsKilled, int totalTimeCCDealt,
            int totalTimeSpentDead, int totalUnitsHealed, int tripleKills, int trueDamageDealt,
            int trueDamageDealtToChampions, int trueDamageTaken, int turretKills, int turretTakedowns,
            int turretsLost, int unrealKills, int visionScore, int visionWardsBoughtInGame, int wardsKilled, int wardsPlaced,
            bool win)
        {
            Assists = assists;
            BaronKills = baronKills;
            BountyLevel = bountyLevel;
            ChampExperience = champExperience;
            ChampLevel = champLevel;
            ChampionId = championId;
            ChampionName = championName;
            ChampionTransform = championTransform;
            ConsumablesPurchased = consumablesPurchased;
            DamageDealtToBuildings = damageDealtToBuildings;
            DamageDealtToObjectives = damageDealtToObjectives;
            DamageDealtToTurrets = damageDealtToTurrets;
            DamageSelfMitigated = damageSelfMitigated;
            Deaths = deaths;
            DetectorWardsPlaced = detectorWardsPlaced;
            DoubleKills = doubleKills;
            DragonKills = dragonKills;
            FirstBloodAssist = firstBloodAssist;
            FirstBloodKill = firstBloodKill;
            FirstTowerAssist = firstTowerAssist;
            FirstTowerKill = firstTowerKill;
            GameEndedInEarlySurrender = gameEndedInEarlySurrender;
            GameEndedInSurrender = gameEndedInSurrender;
            GoldEarned = goldEarned;
            GoldSpent = goldSpent;
            IndividualPosition = individualPosition;
            InhibitorKills = inhibitorKills;
            InhibitorTakedowns = inhibitorTakedowns;
            this.inhibitorsLost = inhibitorsLost;
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
            Item6 = item6;
            ItemsPurchased = itemsPurchased;
            KillingSprees = killingSprees;
            Kills = kills;
            Lane = lane;
            LargestCriticalStrike = largestCriticalStrike;
            LargestKillingSpree = largestKillingSpree;
            LargestMultiKill = largestMultiKill;
            LongestTimeSpentLiving = longestTimeSpentLiving;
            MagicDamageDealt = magicDamageDealt;
            MagicDamageDealtToChampions = magicDamageDealtToChampions;
            MagicDamageTaken = magicDamageTaken;
            NeutralMinionsKilled = neutralMinionsKilled;
            NexusKills = nexusKills;
            NexusTakedowns = nexusTakedowns;
            NexusLost = nexusLost;
            ObjectivesStolen = objectivesStolen;
            ObjectivesStolenAssists = objectivesStolenAssists;
            ParticipantId = participantId;
            PentaKills = pentaKills;
            Perks = perks;
            PhysicalDamageDealt = physicalDamageDealt;
            PhysicalDamageDealtToChampions = physicalDamageDealtToChampions;
            PhysicalDamageTaken = physicalDamageTaken;
            ProfileIcon = profileIcon;
            Puuid = puuid;
            QuadraKills = quadraKills;
            RiotIdName = riotIdName;
            RiotIdTagline = riotIdTagline;
            Role = role;
            SightWardsBoughtInGame = sightWardsBoughtInGame;
            Spell1Casts = spell1Casts;
            Spell2Casts = spell2Casts;
            Spell3Casts = spell3Casts;
            Spell4Casts = spell4Casts;
            Summoner1Casts = summoner1Casts;
            Summoner1Id = summoner1Id;
            Summoner2Casts = summoner2Casts;
            Summoner2Id = summoner2Id;
            SummonerId = summonerId;
            SummonerLevel = summonerLevel;
            SummonerName = summonerName;
            TeamEarlySurrendered = teamEarlySurrendered;
            TeamId = teamId;
            TeamPosition = teamPosition;
            TimeCCingOthers = timeCCingOthers;
            TimePlayed = timePlayed;
            TotalDamageDealt = totalDamageDealt;
            TotalDamageDealtToChampions = totalDamageDealtToChampions;
            TotalDamageShieldedOnTeammates = totalDamageShieldedOnTeammates;
            TotalDamageTaken = totalDamageTaken;
            TotalHeal = totalHeal;
            TotalHealsOnTeammates = totalHealsOnTeammates;
            TotalMinionsKilled = totalMinionsKilled;
            TotalTimeCCDealt = totalTimeCCDealt;
            TotalTimeSpentDead = totalTimeSpentDead;
            TotalUnitsHealed = totalUnitsHealed;
            TripleKills = tripleKills;
            TrueDamageDealt = trueDamageDealt;
            TrueDamageDealtToChampions = trueDamageDealtToChampions;
            TrueDamageTaken = trueDamageTaken;
            TurretKills = turretKills;
            TurretTakedowns = turretTakedowns;
            TurretsLost = turretsLost;
            UnrealKills = unrealKills;
            VisionScore = visionScore;
            VisionWardsBoughtInGame = visionWardsBoughtInGame;
            WardsKilled = wardsKilled;
            WardsPlaced = wardsPlaced;
            Win = win;
        }

    }
}
