namespace AudenTennisScoring.Strategies
{
    public class DefaultStrategy : IScoreConversionStrategies
    {

        public bool Accepts(IPlayer player1, IPlayer player2)
        {
            if ((player1.Points != player2.Points) && (player1.Points <= 40 && player2.Points <= 40))
                return true;
            return false;
        }

        public string GetScore(IPlayer player1, IPlayer player2)
        {
            var score = $"{player1.Points} {player2.Points}";
            return score;
        }
    }
}