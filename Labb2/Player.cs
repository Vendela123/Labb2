
using Labb2.Element;

namespace Labb2
{
    public class Player
    {
        public Position Position { get; set; }
        public int HP { get; set; } = 100;
        public Dice AttackDice { get; } = new Dice(2, 6, 2);
        public Dice DefenceDice { get; } = new Dice(2, 6, 0);
        public ConsoleColor Color { get; set; }
        public char Symbol { get; set; }   

        public Player(Position startPosition)
        {
            Position = startPosition;

     
            Symbol = '@';
            Color = ConsoleColor.Magenta;
        }

        public void Move(int dx, int dy)
        {
            Position = new Position(Position.X + dx, Position.Y + dy);
        }
    }
}

