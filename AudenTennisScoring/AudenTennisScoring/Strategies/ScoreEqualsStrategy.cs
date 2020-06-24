using System;
using System.Collections.Generic;
using System.Text;

namespace AudenTennisScoring.Strategies
{
    public class ScoreEqualsStrategy : IScoreConversionStrategies
    {
        public bool Accepts(IPlayer player1, IPlayer player2)
        {
            if (player1.Points == player2.Points)
                return true;

            return false;
        }

        public string GetScore(IPlayer player1, IPlayer player2)
        {
            if (player1.Points == 0 && player2.Points == 0)
                return $"{player1.Name} {player1.Points}  {player2.Name} {player2.Points}";

            if (player1.Points < 40 && player2.Points < 40)
                return $"{player1.Points} All";


            return "Deuce";
        }
        
    }
}
