
namespace Labb2.Element
{
    public class Snake : Enemy
    {
        private static Random rng = new Random();

        public Snake(Position position) : base(position)
        {
            Name = "Snake";
            Symbol = 's';
            Color = ConsoleColor.Green;

            HP = 25;
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 8, 5);
        }

        public override void Update(Player player, List<LevelElement> elements)
        {
            int dx = player.Position.X - Position.X;
            int dy = player.Position.Y - Position.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance > 2)
                return;

            int moveX = Math.Sign(Position.X - player.Position.X);
            int moveY = Math.Sign(Position.Y - player.Position.Y);

            var newPos = new Position(Position.X + moveX, Position.Y + moveY);

            bool blocked = false;
            foreach (var e in elements)
            {
                if (e.Position.Equals(newPos) && (e is Wall || e is Enemy))
                {
                    blocked = true;
                    break;
                }
            }
            if (!blocked)
                Position = newPos;
        }
    }
}
