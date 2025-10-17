

using Labb2.Element;

namespace Labb2
{
    public class LevelData
    {
        private List<LevelElement> elements = new List<LevelElement>();
        private HashSet<Position> discoveredWalls = new HashSet<Position>();

        public IReadOnlyList<LevelElement> Elements => elements.AsReadOnly();
        public Player Player { get; private set; }

        public void Load(string filename)
        {
            elements.Clear();
            string[] lines = File.ReadAllLines(filename);

            for (int y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    char c = line[x];
                    var pos = new Position(x, y);

                    switch (c)
                    {
                        case '#':
                            elements.Add(new Wall(pos));
                            break;
                        case 'r':
                            elements.Add(new Rat(pos));
                            break;
                        case 's':
                            elements.Add(new Snake(pos));
                            break;
                        case '@':
                            Player = new Player(pos);
                            break;
                    }
                }
            }
        }

        public void Draw(Player player)
        {
            Console.Clear();

            foreach (var e in elements)
            {
                double dx = e.Position.X - player.Position.X;
                double dy = e.Position.Y - player.Position.Y;
                double distance = Math.Sqrt(dx * dx + dy * dy);

                bool isVisible = distance <= 5;

                if (e is Wall && isVisible)
                    discoveredWalls.Add(e.Position);

                if (e is Wall && discoveredWalls.Contains(e.Position))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(e.Position.X, e.Position.Y);
                    Console.Write('#');
                    continue;
                }

                if (e is Enemy enemy && isVisible)
                {
                    Console.ForegroundColor = enemy.Color;
                    Console.SetCursorPosition(e.Position.X, e.Position.Y);
                    Console.Write(enemy.Symbol);
                    continue;
                }
            }

            Console.ForegroundColor = player.Color;
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            Console.Write(player.Symbol);

            Console.ResetColor();
        }

        public bool IsWallAt(Position position)
        {
            return elements.Any(e => e.Position.Equals(position) && e is Wall);
        }

        public Enemy GetEnemyAt(Position position)
        {
            return elements.OfType<Enemy>().FirstOrDefault(e => e.Position.Equals(position));
        }

        public void RemoveEnemy(Enemy enemy)
        {
            elements.Remove(enemy);
        }
    }
}