using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _3Sports.Sport_Services
{
    public class TeamPerfAnalysisService
    {
        private readonly DataTable _data;

        public TeamPerfAnalysisService(DataTable data)
        {
            _data = data;
        }

        // Updated: Calculates performance stats for a given team based on match data.
        public Dictionary<string, double> GetTeamPerfStats(string teamName)
        {
            var matches = _data.AsEnumerable()
                .Where(row => row["HomeTeam"].ToString() == teamName || row["AwayTeam"].ToString() == teamName)

                // Then converts to list to avoid multiple enumerations
                .ToList();

            int totalMatches = matches.Count;

            // New Updated: Return empty if no matches found
            if (totalMatches == 0) return new Dictionary<string, double>();

            int wins = matches.Count(row => (row["HomeTeam"].ToString() == teamName && Convert.ToInt32(row["FTHG"]) > Convert.ToInt32(row["FTAG"])) ||
                                            (row["AwayTeam"].ToString() == teamName && Convert.ToInt32(row["FTAG"]) > Convert.ToInt32(row["FTHG"])));
            int losses = matches.Count(row => (row["HomeTeam"].ToString() == teamName && Convert.ToInt32(row["FTHG"]) < Convert.ToInt32(row["FTAG"])) ||
                                              (row["AwayTeam"].ToString() == teamName && Convert.ToInt32(row["FTAG"]) < Convert.ToInt32(row["FTHG"])));
            int draws = totalMatches - (wins + losses);

            double winRate = (double)wins / totalMatches * 100;

            return new Dictionary<string, double>
            {
                { "Total Matches", totalMatches },
                { "Wins", wins },
                { "Losses", losses },
                { "Draws", draws },
                { "Win Rate (%)", Math.Round(winRate, 2) }
            };
        }
    }

    // ***************************************************************************************************
    // Match Prediction Service

    public class MatchPredictionService
    {
        private readonly DataTable _matchData;
        private readonly Random _random;

        public MatchPredictionService(DataTable matchData)
        {
            _matchData = matchData;
            _random = new Random();
        }

        // New Updated: Predicts the outcome of a match between two teams based on past wins.
        public string PredictMatchOutcome(string team1, string team2)
        {
            int team1Wins = GetTeamWins(team1);
            int team2Wins = GetTeamWins(team2);

            if (team1Wins > team2Wins)
                return $"{team1} has a strong chance of winning!";
            if (team2Wins > team1Wins)
                return $"{team2} is likely to take the win!";

            return "A Draw might be on the cards!";
        }

        // Minor Updates: Retrieves the number of wins for a given team.
        private int GetTeamWins(string team)
        {
            return _matchData.AsEnumerable().Count(row =>
            {
                string homeTeam = row.Field<string>("HomeTeam");
                int homeGoals = row["FTHG"] is DBNull ? 0 : Convert.ToInt32(row["FTHG"]);
                int awayGoals = row["FTAG"] is DBNull ? 0 : Convert.ToInt32(row["FTAG"]);

                return homeTeam == team && homeGoals > awayGoals;
            });
        }
    }
}
