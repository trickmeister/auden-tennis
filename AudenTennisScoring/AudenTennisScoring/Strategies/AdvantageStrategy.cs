namespace AudenTennisScoring.Strategies
{
    public class AdvantageStrategy : IScoreConversionStrategies
    {

        public bool Accepts(IPlayer player1, IPlayer player2)
        {
            if (player1.Points == 41 && player2.Points == 40 || (player2.Points == 41 && player1.Points == 40))
                return true;
            return false;
        }

        public string GetScore(IPlayer player1, IPlayer player2)
        {
            var score = player1.Points == 41 ? $"Advantage {player1.Name}" : $"Advantage {player2.Name}";
            return score;
        }
    }
}