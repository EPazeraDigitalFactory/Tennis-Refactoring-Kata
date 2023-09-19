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
            string scoringText;
            if (NotCloseToWinning())
            {
                string[] pointName = { "Love", "Fifteen", "Thirty", "Forty" };
                scoringText = pointName[player1Score];
                return (player1Score == player2Score) ? scoringText + "-All" : scoringText + "-" + pointName[player2Score];
            }
            if (player1Score>=3 && player1Score == player2Score)
            {
                return "Deuce";
            }
            scoringText = player1Score > player2Score ? player1Name : player2Name;
            return ((player1Score - player2Score) * (player1Score - player2Score) == 1) ? "Advantage " + scoringText : "Win for " + scoringText;
        }

        private bool NotCloseToWinning()
        {
            return player1Score < 4
                                    &&
                                player2Score < 4
                                    &&
                                IsNotDeuce();
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