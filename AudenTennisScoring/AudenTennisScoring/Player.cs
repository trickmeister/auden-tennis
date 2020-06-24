namespace AudenTennisScoring
{
    public class Player : IPlayer
    {
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
