using System;
using System.Collections.Generic;

class Scorekeeper
{
    private string gamePlayed;
    protected Dictionary<string, int> players;

    public Scorekeeper()
    {
        players = new Dictionary<string, int>();
    }

    public void AddName(string playerName)
    {
        players.Add(playerName, 0);
    }

    public string GetPlayerName(int playerNumber)
    {
        if (playerNumber < 1 || playerNumber > players.Count)
        {
            return "Invalid player number";
        }

        return players.Keys.ToArray()[playerNumber - 1];
    }

    public void SetGame(string gameName)
    {
        gamePlayed = gameName;
    }

    public string GetGame()
    {
        return gamePlayed;
    }

    public int AddScore(string playerName, int points)
    {
        if (players.ContainsKey(playerName))
        {
            players[playerName] += points;
            return players[playerName];
        }
        return -1;
    }

    public int SubScore(string playerName, int points)
    {
        if (players.ContainsKey(playerName))
        {
            players[playerName] -= points;
            return players[playerName];
        }
        return -1;
    }

    public void ListAllScores()
    {
        Console.WriteLine($"Game: {gamePlayed}");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Key}: {player.Value} points");
        }
    }
}

class Baseball : Scorekeeper
{
    private int fouls;
    private int balls;
    private int strikes;
    private int outs;
    private decimal inning;

    public void AdvOuts()
    {
        outs++;
        if (outs >= 3)
        {
            fouls = 0;
            strikes = 0;
            balls = 0;
            outs = 0;

            if (inning % 1 == 0)
            {
                inning += 0.5m;
            }
            else
            {
                inning += 0.5m;
            }
        }
    }

    public int GetOuts()
    {
        return outs;
    }

    public void AdvStrikes()
    {
        strikes++;
        if (strikes >= 3)
        {
            AdvOuts();
        }
    }

    public int GetStrikes()
    {
        return strikes;
    }

    public void AdvFouls()
    {
        fouls++;
        if (strikes < 2)
        {
            AdvStrikes();
        }
    }

    public int GetFouls()
    {
        return fouls;
    }

    public void AdvBalls()
    {
        balls++;
        if (balls >= 4)
        {
            balls = 0;
            strikes = 0;
            fouls = 0;
        }
    }

    public int GetBalls()
    {
        return balls;
    }

    public decimal GetInning()
    {
        return inning;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Baseball baseball = new Baseball();
        baseball.AddName("Team A");
        baseball.AddName("Team B");
        baseball.SetGame("Baseball Game");

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Advance Outs");
            Console.WriteLine("2. Advance Strikes");
            Console.WriteLine("3. Advance Fouls");
            Console.WriteLine("4. Advance Balls");
            Console.WriteLine("5. List All Scores");
            Console.WriteLine("6. Get Current Inning");
            Console.WriteLine("7. Exit");
            Console.Write("Enter choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        baseball.AdvOuts();
                        break;
                    case 2:
                        baseball.AdvStrikes();
                        break;
                    case 3:
                        baseball.AdvFouls();
                        break;
                    case 4:
                        baseball.AdvBalls();
                        break;
                    case 5:
                        baseball.ListAllScores();
                        break;
                    case 6:
                        Console.WriteLine($"Current Inning: {baseball.GetInning()}");
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine();
        }
    }
}
