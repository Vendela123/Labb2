

namespace Labb2
{
    public class Dice
    {
        private int numberOfDice;
        private int sidesPerDice;
        private int modifier;
        private static Random random = new Random();

        public Dice(int numberOfDice, int sidesPerDice, int modifier)
        {
            this.numberOfDice = numberOfDice;
            this.sidesPerDice = sidesPerDice;
            this.modifier = modifier;
        }

        public int Throw()
        {
            int total = 0;
            for (int i = 0; i < numberOfDice; i++)
            {
                total += random.Next(1, sidesPerDice + 1);
            }
            total += modifier;
            return total;
        }

        public override string ToString()
        {
            string sign = modifier >= 0 ? "+" : "-";
            return $"{numberOfDice}d{sidesPerDice}{sign}{Math.Abs(modifier)}";
        }
    }
}
