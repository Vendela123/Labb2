

namespace Labb2.Element
{
    public class Rat : Enemy
    {
        private static Random rng = new Random();

        public Rat(Position position) : base(position)
        {
            Name = "Rat";
            Symbol = 'r';
            Color = ConsoleColor.Blue;

            HP = 10;
            AttackDice = new Dice(1, 6, 2);   
            DefenceDice = new Dice(1, 6, 1);  
        }

        public override void Update(Player player, List<LevelElement> elements)
        {
         
            int[] moves = { -1, 0, 1 };
            int dx = moves[rng.Next(moves.Length)];
            int dy = moves[rng.Next(moves.Length)];

            if (dx == 0 && dy == 0)
                return;

            var newPos = new Position(Position.X + dx, Position.Y + dy);

            
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
