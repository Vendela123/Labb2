

namespace Labb2.Element
{
    public abstract class LevelElement
    {
        public Position Position { get; set; }          
        public char Symbol { get; set; }               
        public ConsoleColor Color { get; set; }         

        protected LevelElement(Position position)       
        {
            Position = position;
        }
    }
}
