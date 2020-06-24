namespace AudenTennisScoring
{
    public interface IPlayer
    {
        void Scores();
        int Points { get; }
        string Name { get; set; }
    }
}