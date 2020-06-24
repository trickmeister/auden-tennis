
namespace AudenTennisScoring
{
    public class Scoreboard
    {
        private readonly IPlayer _player;

        public Scoreboard(IPlayer player)
        {
            _player = player;
        }

        public string Score { get; set; }

        public void Player1Scores()
        {
            _player.Scores();
            Score = _player.Points.ToString();
        }
    }
}
