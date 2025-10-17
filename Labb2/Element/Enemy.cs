

namespace Labb2.Element
{
    public abstract class Enemy : LevelElement
    {
        public string Name { get; protected set; }
        public int HP { get; set; }
        public Dice AttackDice { get; protected set; }
        public Dice DefenceDice { get; protected set; }
        public ConsoleColor Color { get; protected set; }

        public Enemy(Position position) : base(position)
        {
        }

        public abstract void Update(Player player, List<LevelElement> elements);
    }
}
