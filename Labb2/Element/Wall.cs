
namespace Labb2.Element
{
    public class Wall : LevelElement
    {
        public Wall(Position position) : base(position)
        {
            Symbol = '#';
            Color = ConsoleColor.DarkYellow;
        }
    }
}
