using System.Collections;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Backend.Models.Matches
{
    public class InfoDto
    {
        public long GameCreation { get; set; }
        public long GameDuration { get; set; }
        public long GameEndTimestamp { get; set; }
        public long GameId { get; set; }
        public string GameMode { get; set; }
        public string GameName { get; set; }
        public long GameStartTimestamp { get; set; }
        public string GameType { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        public List<ParticipantDto> Participants { get; set; }
        public string PlatformId { get; set; }
        public int QueueId { get; set; }
        public List<TeamDto> Teams { get; set; }
        public string TournamentCode { get; set; }


        public InfoDto(
    long gameCreation, long gameDuration, long gameEndTimestamp, long gameId,
    string gameMode, string gameName, long gameStartTimestamp, string gameType,
    string gameVersion, int mapId, List<ParticipantDto> participants,
    string platformId, int queueId, List<TeamDto> teams, string tournamentCode)
        {
            GameCreation = gameCreation;
            GameDuration = gameDuration;
            GameEndTimestamp = gameEndTimestamp;
            GameId = gameId;
            GameMode = gameMode;
            GameName = gameName;
            GameStartTimestamp = gameStartTimestamp;
            GameType = gameType;
            GameVersion = gameVersion;
            MapId = mapId;
            Participants = participants;
            PlatformId = platformId;
            QueueId = queueId;
            Teams = teams;
            TournamentCode = tournamentCode;
        }


    }
}
