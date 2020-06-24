namespace AudenTennisScoring.Strategies
{
    public class WinStrategy : IScoreConversionStrategies
    {

        public bool Accepts(IPlayer player1, IPlayer player2)
        {
            if ((player1.Points == 42 && player2.Points == 40) || (player2.Points == 42 && player1.Points==40) || 
                (player1.Points == 41 && player2.Points < 40) || (player2.Points == 41 && player1.Points < 40))
                return true;
            return false;
        }

        public string GetScore(IPlayer player1, IPlayer player2)
        {
            var score = player1.Points > 40 ? $"{player1.Name} wins" : $"{player2.Name} wins";
            return score;
        }
    }
}
