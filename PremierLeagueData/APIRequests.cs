﻿using ConsoleTables;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeagueData
{
    internal class APIRequests
    {
        public static async Task<RestResponse> LeagueStandings(string option, int seasonYear)
        {
            var client = new RestClient(Constants.baseURL);

            var request = new RestRequest("standings", Method.Get)
                .AddHeader(Constants.apiKey, Constants.apiValue)
                .AddParameter("season", seasonYear);

            switch (option)
            {
                case "Premier League":
                    request.AddParameter("league", 39);
                    break;
                case "La Liga":
                    request.AddParameter("league", 140);
                    break;
                case "Serie A":
                    request.AddParameter("league", 135);
                    break;
                case "Bundesliga":
                    request.AddParameter("league", 78);
                    break;
                case "Ligue 1":
                    request.AddParameter("league", 61);
                    break;
            }

            RestResponse response = await client.GetAsync(request);
            JObject obj = JObject.Parse(response.Content);

            string league = (string)obj["response"][0]["league"]["name"];
            string season = (string)obj["parameters"]["season"];
            int results = (int)obj["response"][0]["league"]["standings"][0].Count();
            int season2 = Int32.Parse(season) % 100;
            Console.WriteLine($"\n{league} {season2}/{season2 + 1} standings\n");

            //Console.WriteLine("Team \t \t | Points \t | MP \t | W \t | D \t | L");
            var table =
                new ConsoleTable(new ConsoleTableOptions
                {
                    Columns = new[] { "Rank", "Team", "Points", "Form", "MP", "W", "D", "L", "GF", "GA", "GD" },
                    EnableCount = false
                });

            for (int i = 0; i < results; i++)
            {
                int rank = (int)obj["response"][0]["league"]["standings"][0][i]["rank"];
                string team = (string)obj["response"][0]["league"]["standings"][0][i]["team"]["name"];
                int points = (int)obj["response"][0]["league"]["standings"][0][i]["points"];
                string form = (string)obj["response"][0]["league"]["standings"][0][i]["form"];
                int matchesPlayed = (int)obj["response"][0]["league"]["standings"][0][i]["all"]["played"];
                int wins = (int)obj["response"][0]["league"]["standings"][0][i]["all"]["win"];
                int drawn = (int)obj["response"][0]["league"]["standings"][0][i]["all"]["draw"];
                int lost = (int)obj["response"][0]["league"]["standings"][0][i]["all"]["lose"];
                int goalsFor = (int)obj["response"][0]["league"]["standings"][0][i]["all"]["goals"]["for"];
                int goalAgainst = (int)obj["response"][0]["league"]["standings"][0][i]["all"]["goals"]["against"];
                int goalDifference = (int)obj["response"][0]["league"]["standings"][0][i]["goalsDiff"];
                //Console.WriteLine($"{team} \t \t | {points} \t | {mp} \t  | {wins} \t | {drawn} \t | {lost}");
                table.AddRow(rank, team, points, form, matchesPlayed, wins, drawn, lost, goalsFor, goalAgainst, goalDifference);
                //Console.WriteLine(response.Content);
            }

            table.Write();
            return response;
        }


        public static async Task<RestResponse> FixtureResults(string option, int seasonYear, int gameweek)
        {
            var client = new RestClient(Constants.baseURL);

            var request = new RestRequest("fixtures", Method.Get)
                .AddHeader(Constants.apiKey, Constants.apiValue)
                .AddParameter("season", seasonYear)
                .AddParameter("round", $"Regular Season - {gameweek}");

            switch (option)
            {
                case "Premier League":
                    request.AddParameter("league", 39); // Premier League
                    break;
                case "La Liga":
                    request.AddParameter("league", 140); // La Liga
                    break;
                case "Serie A":
                    request.AddParameter("league", 135); // Serie A
                    break;
                case "Bundesliga":
                    request.AddParameter("league", 78); // Bundesliga
                    break;
                case "Ligue 1":
                    request.AddParameter("league", 61); // Ligue 1
                    break;
            }

            RestResponse response = await client.GetAsync(request);
            JObject obj = JObject.Parse(response.Content);

            string league = (string)obj["response"][0]["league"]["name"];
            string season = (string)obj["response"][0]["league"]["season"];
            int results = (int)obj["results"];
            int season2 = Int32.Parse(season) % 100;
            Console.WriteLine($"\n{league} {season2}/{season2 + 1} - Gameweek {gameweek} Fixture Results\n");

            var table =
                new ConsoleTable(new ConsoleTableOptions
                {
                    Columns = new[] { "Home Team", "Score", "Away Team" },
                    EnableCount = false
                });

            for (int i = 0; i < results; i++)
            {
                string homeTeam = (string)obj["response"][i]["teams"]["home"]["name"];
                string awayTeam = (string)obj["response"][i]["teams"]["away"]["name"];
                string homeGoals = (string)obj["response"][i]["goals"]["home"];
                string awayGoals = (string)obj["response"][i]["goals"]["away"];
                string score = $"{homeGoals} - {awayGoals}";
                string status = (string)obj["response"][i]["fixture"]["status"]["long"];
                if (status == "Not Started" || status == "Match Postponed")
                    score = " N/A";

                table.AddRow(homeTeam, score, awayTeam);
                //Console.WriteLine(response.Content);
            }

            table.Write();
            Console.WriteLine("N/A = Match Postponed");
            Console.WriteLine();

            return response;
        }


        public static async Task<RestResponse> TopScorers(int league_, int seasonYear)
        {
            var client = new RestClient(Constants.baseURL);

            var request = new RestRequest("players/topscorers", Method.Get)
                .AddHeader(Constants.apiKey, Constants.apiValue)
                .AddParameter("season", seasonYear);

            switch (league_)
            {
                case 39:
                    request.AddParameter("league", 39); // Premier League
                    break;
                case 140:
                    request.AddParameter("league", 140); // La Liga
                    break;
                case 135:
                    request.AddParameter("league", 135); // Serie A
                    break;
                case 78:
                    request.AddParameter("league", 78); // Bundesliga
                    break;
                case 61:
                    request.AddParameter("league", 61); // Ligue 1
                    break;
            }

            RestResponse response = await client.GetAsync(request);
            JObject obj = JObject.Parse(response.Content);


            string league = (string)obj["response"][0]["statistics"][0]["league"]["name"];
            string season = (string)obj["parameters"]["season"];
            int season2 = Int32.Parse(season) % 100;
            Console.WriteLine($"\n{league} {season2}/{season2 + 1} Top Scorers\n");

            var table =
                new ConsoleTable(new ConsoleTableOptions
                {
                    Columns = new[] { "Rank", "Player", "Goals", "Appearences", "Team", "Nationality" },
                    EnableCount = false
                });

            int rank = 0;

            for (int i = 0; i < 10; i++)
            {
                rank++;
                string player = (string)obj["response"][i]["player"]["name"];
                string goals = (string)obj["response"][i]["statistics"][0]["goals"]["total"];
                string appearences = (string)obj["response"][i]["statistics"][0]["games"]["appearences"];
                string team = (string)obj["response"][i]["statistics"][0]["team"]["name"];
                string nationality = (string)obj["response"][i]["player"]["nationality"];

                table.AddRow(rank, player, goals, appearences, team, nationality);
                //Console.WriteLine(response.Content);
            }

            table.Write();
            return response;
        }


        public static async Task<RestResponse> TopAssistors(int league_, int seasonYear)
        {
            var client = new RestClient(Constants.baseURL);

            var request = new RestRequest("players/topassists", Method.Get)
                .AddHeader(Constants.apiKey, Constants.apiValue)
                .AddParameter("season", seasonYear);

            switch (league_)
            {
                case 39:
                    request.AddParameter("league", 39); // Premier League
                    break;
                case 140:
                    request.AddParameter("league", 140); // La Liga
                    break;
                case 135:
                    request.AddParameter("league", 135); // Serie A
                    break;
                case 78:
                    request.AddParameter("league", 78); // Bundesliga
                    break;
                case 61:
                    request.AddParameter("league", 61); // Ligue 1
                    break;
            }

            RestResponse response = await client.GetAsync(request);
            JObject obj = JObject.Parse(response.Content);

            string league = (string)obj["response"][0]["statistics"][0]["league"]["name"];
            string season = (string)obj["parameters"]["season"];
            int season2 = Int32.Parse(season) % 100;
            Console.WriteLine($"\n{league} {season}/{season2 + 1} Top Assistors\n");

            var table =
                new ConsoleTable(new ConsoleTableOptions
                {
                    Columns = new[] { "Rank", "Player", "Assists", "Appearences", "Team", "Nationality" },
                    EnableCount = false
                });

            int rank = 0;

            for (int i = 0; i < 10; i++)
            {
                rank++;
                string player = (string)obj["response"][i]["player"]["name"];
                string assists = (string)obj["response"][i]["statistics"][0]["goals"]["assists"];
                string appearences = (string)obj["response"][i]["statistics"][0]["games"]["appearences"];
                string team = (string)obj["response"][i]["statistics"][0]["team"]["name"];
                string nationality = (string)obj["response"][i]["player"]["nationality"];

                table.AddRow(rank, player, assists, appearences, team, nationality);
                //Console.WriteLine(response.Content);
            }

            table.Write();
            return response;
        }
    }
}
