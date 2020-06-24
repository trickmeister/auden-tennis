namespace AudenTennisScoring
{
    public class Player : IPlayer
    {
        /*
         * I have run out of time so there is no logic in here to handle scoring above deuce when
         * a player might go to advantage and then back to deuce again.  Also, I would probably change
         * points to an enum so it is more obvious and not using a magic number if I had more time. 
         */
        private int _points;
        public string Name { get; set; }
        public int Points => _points;

        public void Scores()
        {
            if (_points < 30)
            {
                _points += 15;
                return;
            }

            switch (_points)
            {
                case 30:
                    _points += 10;
                    return;
                case 40:
                    _points += 1;
                    return;
                case 41:
                    _points += 1;
                    break;
            }
        }
    }
}
