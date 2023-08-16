using System;
using System.Collections.Generic;
using System.Linq;

public class ScoreKeeper
{
    private string gamePlayed;
    private Dictionary<string, int> players = new Dictionary<string, int>();

    public void addName(string playerName)
    {
        players.Add(playerName, 0);
    }

    public string getPlayerName(int playerNumber)
    {
        return players.Keys.ElementAtOrDefault(playerNumber - 1);
    }

    public void setGame(string gameName)
    {
        gamePlayed = gameName;
    }

    public string getGame()
    {
        return gamePlayed;
    }

    public int addScore(string playerName, int points)
    {
        players[playerName] += points;
        return players[playerName];
    }

    public int subScore(string playerName, int points)
    {
        players[playerName] -= points;
        return players[playerName];
    }

    public void listAllScores()
    {
        Console.WriteLine($"Game: {gamePlayed}");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Key}: {player.Value}");
        }
    }

    public ScoreKeeper()
    {
    }

    public ScoreKeeper(string gameName)
    {
        setGame(gameName);
    }
}

public class Baseball : ScoreKeeper
{
    private int fouls;
    private int balls;
    private int strikes;
    private int outs;
    private decimal inning;

    public void advOuts()
    {
        outs++;
        if (outs >= 3)
        {
            balls = 0;
            strikes = 0;
            fouls = 0;
            outs = 0;
            inning += 0.5m;
        }
    }

    public int getOuts()
    {
        return outs;
    }

    public void advStrikes()
    {
        strikes++;
        if (strikes >= 3)
        {
            advOuts();
        }
    }

    public int getStrikes()
    {
        return strikes;
    }

    public void advFouls()
    {
        fouls++;
        if (strikes < 2)
        {
            strikes++;
        }
    }

    public int getFouls()
    {
        return fouls;
    }

    public void advBalls()
    {
        balls++;
        if (balls >= 4)
        {
            balls = 0;
            strikes = 0;
            fouls = 0;
        }
    }

    public int getBalls()
    {
        return balls;
    }

    public decimal getInning()
    {
        return inning;
    }

    public Baseball()
    {
    }

    public Baseball(string homeTeam, string visitingTeam)
    {
        string combinedTeamName = $"{homeTeam} vs {visitingTeam}";
        setGame(combinedTeamName);
        addName(homeTeam);
        addName(visitingTeam);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage of the ScoreKeeper class
        ScoreKeeper genericScoreKeeper = new ScoreKeeper("Generic Game");
        genericScoreKeeper.addName("Player 1");
        genericScoreKeeper.addName("Player 2");
        genericScoreKeeper.addScore("Player 1", 10);
        genericScoreKeeper.addScore("Player 2", 5);
        genericScoreKeeper.listAllScores();

        // Example usage of the Baseball class
        Baseball baseballScoreKeeper = new Baseball("Cubs", "Braves");
        baseballScoreKeeper.addScore("Cubs", 2);
        baseballScoreKeeper.addScore("Braves", 3);
        baseballScoreKeeper.advOuts();
        baseballScoreKeeper.advStrikes();
        baseballScoreKeeper.advFouls();
        baseballScoreKeeper.advBalls();
        Console.WriteLine($"Current inning: {baseballScoreKeeper.getInning()}");

        // Rest of your program logic...
    }
}
