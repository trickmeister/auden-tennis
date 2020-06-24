using System.Collections.Generic;
using System.Linq;
using AudenTennisScoring.Strategies;

namespace AudenTennisScoring
{
    public class Scoreboard
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly IEnumerable<IScoreConversionStrategies> _strategies;
        public string Score { get; set; }

        public Scoreboard(IPlayer player1, IPlayer player2, IEnumerable<IScoreConversionStrategies> strategies)
        {
            _player1 = player1;
            _player2 = player2;
            _strategies = strategies;
        }
        
        public void Player1Scores()
        {
            _player1.Scores();
            var scoreConversion = _strategies.First(x => x.Accepts(_player1, _player2));
            var score = scoreConversion.GetScore(_player1, _player2);

            Score = score;
        }
    }
}
