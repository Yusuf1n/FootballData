using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleTables;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace PremierLeagueData
{
    internal class APIRequests
    {
        public static async Task<RestResponse> LeagueStandings()
        {
            var client = new RestClient(Constants.baseURL);

            var request = new RestRequest("standings", Method.Get)
                .AddHeader(Constants.apiKey, Constants.apiValue)
                //.AddParameter("league", 39) // Premier League
                .AddParameter("league", 140) // La Liga
                .AddParameter("season", 2021); // 21/22 Season

            RestResponse response = await client.GetAsync(request);
            JObject obj = JObject.Parse(response.Content);

            string league = (string)obj["response"][0]["league"]["name"];
            string season = (string)obj["parameters"]["season"];
            Console.WriteLine(league + " " + season);

            //Console.WriteLine("Team \t \t | Points \t | MP \t | W \t | D \t | L");
            var table = new ConsoleTable("Rank", "Team", "Points", "Form", "MP", "W", "D", "L", "GF", "GA", "GD");
            
            for (int i = 0; i < 20; i++)
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
    }
}
