namespace AudenTennisScoring
{
    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public void Scores()
        {
            if (Points < 30)
            {
                Points += 15;
                return;
            }

            switch (Points)
            {
                case 30:
                    Points += 10;
                    return;
                case 40:
                    Points += 1;
                    return;
                case 41:
                    Points += 1;
                    break;
            }
        }
    }
}
