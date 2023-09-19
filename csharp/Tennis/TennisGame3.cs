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
            if (NotUnusual())
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
            return ((player1Score - player2Score) * (player1Score - player2Score) == 1) ? "Advantage " + scoringText : "Win for " + scoringText;
        }

        private string UsualScores()
        {
            string[] pointName = { "Love", "Fifteen", "Thirty", "Forty" };
            string scoringText = pointName[player1Score];
            return (player1Score == player2Score) ? scoringText + "-All" : scoringText + "-" + pointName[player2Score];
        }

        private bool NotUnusual()
        {
            return (player1Score >= 4 || player2Score >= 4 || !IsNotDeuce());
        }

        private bool IsNotDeuce()
        {
            return player1Score + player2Score < 6;
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