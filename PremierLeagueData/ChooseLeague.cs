﻿using Spectre.Console;
using System;
using System.Threading.Tasks;

namespace PremierLeagueData
{
    public class ChooseLeague
    {
        static bool exit = false;
        static int seasonYear;

        public static async Task PromptForLeagueStandings()
        {
            do
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Which Leagues standings would you like to see?")
                        .AddChoices(new[] {
                            "Premier League (England)", "La Liga (Spain)", "Serie A (Italy)",
                            "Bundesliga (Germany)", "Ligue 1 (France)", "Exit",
                        }));

                if (option != "Exit")
                {
                    seasonYear = AnsiConsole.Prompt(
                        new TextPrompt<int>
                                ("Which season would you like to see standings for? \nEnter the year for when the season started. [grey]e.g. 2022 for the 22/23 season[/]")
                            .PromptStyle("green"));
                }

                switch (option)
                {
                    case "Premier League (England)":
                        await APIRequests.LeagueStandings("Premier League", seasonYear);
                        break;

                    case "La Liga (Spain)":
                        await APIRequests.LeagueStandings("La Liga", seasonYear);
                        break;

                    case "Serie A (Italy)":
                        await APIRequests.LeagueStandings("Serie A", seasonYear);
                        break;

                    case "Bundesliga (Germany)":
                        await APIRequests.LeagueStandings("Bundesliga", seasonYear);
                        break;

                    case "Ligue 1 (France)":
                        await APIRequests.LeagueStandings("Ligue 1", seasonYear);
                        break;

                    case "Exit":
                        exit = true;
                        break;
                }
            }
            while (!exit);

            //Console.WriteLine("Which Leagues standings would you like to see?");
            //Console.WriteLine("1. Premier League (England)");
            //Console.WriteLine("2. La Liga (Spain)");
            //Console.WriteLine("3. Serie A (Italy)");
            //Console.WriteLine("4. Bundesliga (Germany)");
            //Console.WriteLine("5. Ligue 1 (France)");
            //Console.WriteLine();
            //Console.Write("Please enter 1-5: ");
            //int league_ = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine();
            //await APIRequests.LeagueStandings(league_);
        }

        public static async Task PromptForFixtureResults()
        {
            int gameweek = 0;

            do
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Which Leagues Fixture Results would you like to see?")
                        .AddChoices(new[] {
                            "Premier League (England)", "La Liga (Spain)", "Serie A (Italy)",
                            "Bundesliga (Germany)", "Ligue 1 (France)", "Exit",
                        }));

                if (option != "Exit")
                {
                    seasonYear = AnsiConsole.Prompt(
                        new TextPrompt<int>
                                ("Which season would you like to see fixture results for? \nEnter the year for when the season started. [grey]e.g. 2022 for the 22/23 season[/]")
                            .PromptStyle("green"));

                    Console.WriteLine();

                    gameweek = AnsiConsole.Prompt(
                        new TextPrompt<int>
                                ("Which Gameweeks Fixture Results would you like to see? \nGameweek: ")
                            .PromptStyle("blue"));
                }

                switch (option)
                {
                    case "Premier League (England)":
                        await APIRequests.FixtureResults("Premier League", seasonYear, gameweek);
                        break;

                    case "La Liga (Spain)":
                        await APIRequests.FixtureResults("La Liga", seasonYear, gameweek);
                        break;

                    case "Serie A (Italy)":
                        await APIRequests.FixtureResults("Serie A", seasonYear, gameweek);
                        break;

                    case "Bundesliga (Germany)":
                        await APIRequests.FixtureResults("Bundesliga", seasonYear, gameweek);
                        break;

                    case "Ligue 1 (France)":
                        await APIRequests.FixtureResults("Ligue 1", seasonYear, gameweek);
                        break;

                    case "Exit":
                        exit = true;
                        break;
                }
            }
            while (!exit);

            // Console.WriteLine("Which Leagues Fixture Results would you like to see?");
            // Console.WriteLine("1. Premier League (England)");
            // Console.WriteLine("2. La Liga (Spain)");
            // Console.WriteLine("3. Serie A (Italy)");
            // Console.WriteLine("4. Bundesliga (Germany)");
            // Console.WriteLine("5. Ligue 1 (France)");
            // Console.WriteLine();
            // Console.Write("Please enter 1-5: ");
            // int league_ = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine();

            // Console.WriteLine("Which Gameweeks Fixture Results would you like to see?");
            // Console.Write("Gameweek: ");
            // int gameweek = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine();
            // await APIRequests.FixtureResults(league_, gameweek);
        }

        public static async Task PromptForLeagueTopScorers()
        {
            do
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Which Leagues Top Scorers would you like to see?")
                        .AddChoices(new[] {
                            "1. Premier League (England)", "2. La Liga (Spain)", "3. Serie A (Italy)",
                            "4. Bundesliga (Germany)", "5. Ligue 1 (France)", "Exit",
                        }));

                if (option != "Exit")
                {
                    seasonYear = AnsiConsole.Prompt(
                        new TextPrompt<int>
                                ("Which season would you like to see top scorers for? \nEnter the year for when the season started. [grey]e.g. 2022 for the 22/23 season[/]")
                            .PromptStyle("green"));
                }

                switch (option)
                {
                    case "1. Premier League (England)":
                        await APIRequests.TopScorers(39, seasonYear);
                        break;
                    case "2. La Liga (Spain)":
                        await APIRequests.TopScorers(140, seasonYear);
                        break;
                    case "3. Serie A (Italy)":
                        await APIRequests.TopScorers(135, seasonYear);
                        break;
                    case "4. Bundesliga (Germany)":
                        await APIRequests.TopScorers(78, seasonYear);
                        break;
                    case "5. Ligue 1 (France)":
                        await APIRequests.TopScorers(61, seasonYear);
                        break;
                    case "Exit":
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }

        public static async Task PromptForLeagueTopAssistors()
        {
            do
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Which Leagues Top Assistors would you like to see?")
                        .AddChoices(new[]
                        {
                            "1. Premier League (England)", "2. La Liga (Spain)", "3. Serie A (Italy)",
                            "4. Bundesliga (Germany)", "5. Ligue 1 (France)", "Exit",
                        }));

                if (option != "Exit")
                {
                    seasonYear = AnsiConsole.Prompt(
                        new TextPrompt<int>
                                ("Which season would you like to see top assistors for? \nEnter the year for when the season started. [grey]e.g. 2022 for the 22/23 season[/]")
                            .PromptStyle("green"));
                }

                switch (option)
                {
                    case "1. Premier League (England)":
                        await APIRequests.TopAssistors(39, seasonYear);
                        break;
                    case "2. La Liga (Spain)":
                        await APIRequests.TopAssistors(140, seasonYear);
                        break;
                    case "3. Serie A (Italy)":
                        await APIRequests.TopAssistors(135, seasonYear);
                        break;
                    case "4. Bundesliga (Germany)":
                        await APIRequests.TopAssistors(78, seasonYear);
                        break;
                    case "5. Ligue 1 (France)":
                        await APIRequests.TopAssistors(61, seasonYear);
                        break;
                    case "Exit":
                        exit = true;
                        break;
                }
            } while (!exit);
        }
    }
}
