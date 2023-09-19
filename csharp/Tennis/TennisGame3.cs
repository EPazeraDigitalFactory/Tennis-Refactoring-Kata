using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player2Score;
        private int player1Score;
        private string player1Name;
        private string player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if (IsUnusual())
            {
                return UnusualScores();
            }
            return UsualScores();
        }

        private string UnusualScores()
        {
            if (player1Score >= 3 && player1Score == player2Score)
            {
                return "Deuce";
            }
            string scoringText = player1Score > player2Score ? player1Name : player2Name;
            if (System.Math.Abs(player1Score - player2Score) == 1)
            {
                return "Advantage " + scoringText;
            }
            else
            {
                return "Win for " + scoringText;
            }
        }

        private string UsualScores()
        {
            string scoringText = pointNames[player1Score];
            if (PlayersAreTied())
            {
                return ShowTiedScore(scoringText);
            }
            else
            {
                return ShowUntiedScore(scoringText);
            }
        }

        private string ShowUntiedScore(string scoringText)
        {
            return scoringText + "-" + pointNames[player2Score];
        }

        private static string ShowTiedScore(string scoringText)
        {
            return scoringText + "-All";
        }

        private bool PlayersAreTied()
        {
            return (player1Score == player2Score);
        }

        private static IReadOnlyList<string> pointNames = new List<string>  { "Love", "Fifteen", "Thirty", "Forty" };

        private bool IsUnusual()
        {
            return EitherPlayerHas4() || IsDeuce();
        }

        private bool EitherPlayerHas4()
        {
            return player1Score >= 4 || player2Score >= 4;
        }

        private bool IsDeuce()
        {
            return player1Score + player2Score >= 6;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.player1Score += 1;
            else
                this.player2Score += 1;
        }

    }
}