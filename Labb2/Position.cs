namespace Labb2.Element
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Position pos)
                return pos.X == X && pos.Y == Y;
            return false;
        }

        public override int GetHashCode() => (X, Y).GetHashCode();
    }
}
