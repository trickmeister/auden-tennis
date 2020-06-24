namespace AudenTennisScoring.Strategies
{
    public interface IScoreConversionStrategies
    {
        bool Accepts(IPlayer player1, IPlayer player2);
        string GetScore(IPlayer player1, IPlayer player2);
    }
}
