

using Labb2;
using Labb2.Element;


Console.Title = " Dungeon Crawler ";

string lastBattleMessage = "";
string lastMessage = "";


Console.CursorVisible = false;
LevelData level = new LevelData();

level.Load("Level1.txt");

Player player = level.Player;

bool running = true;

while (running)
{
    level.Draw(player);
    Console.SetCursorPosition(0, 20);
    Console.WriteLine($"HP: {player.HP}");

    if (player.HP <= 0)
    {
        ShowGameOver();
        break;
    }

    Console.SetCursorPosition(0, 21);
    Console.WriteLine(new string(' ', Console.WindowWidth)); 
    Console.SetCursorPosition(0, 21);
    Console.WriteLine(lastMessage);


    ConsoleKey key = Console.ReadKey(true).Key;

    int dx = 0, dy = 0;

    switch (key)
    {
        case ConsoleKey.UpArrow: dy = -1; break;
        case ConsoleKey.DownArrow: dy = 1; break;
        case ConsoleKey.LeftArrow: dx = -1; break;
        case ConsoleKey.RightArrow: dx = 1; break;
        case ConsoleKey.Escape: running = false; continue;
        default: continue;
    }

    var newPos = new Position(player.Position.X + dx, player.Position.Y + dy);

    if (level.IsWallAt(newPos))
        continue;

    var enemy = level.GetEnemyAt(newPos);
    if (enemy != null)
    {
        Battle(player, enemy, level);

        if (player.HP <= 0)
        {
            ShowGameOver();
            break;
        }
        continue;
    }

    player.Position = newPos;

    foreach (var e in level.Elements.OfType<Enemy>().ToList())
    {
        e.Update(player, level.Elements.ToList());

        if (e.Position.Equals(player.Position))
        {
            EnemyBattle(e, player, level);

            if (player.HP <= 0)
            {
                ShowGameOver();
                running = false;
                break;
            }
        }
    }
}
void Battle(Player player, Enemy enemy, LevelData level)
{
    Console.SetCursorPosition(0, 22);
    lastMessage = $" {player.GetType().Name} attackerar {enemy.Name}!";

    int playerAttack = player.AttackDice.Throw();
    int enemyDefence = enemy.DefenceDice.Throw();

    int damage = playerAttack - enemyDefence;
    if (damage > 0)
        enemy.HP -= damage;

    lastMessage += $"\n   Du gör {Math.Max(0, damage)} skada! ({enemy.HP} HP kvar)";

    if (enemy.HP <= 0)
    {
        lastMessage += $"\n   {enemy.Name} dog!";
        level.RemoveEnemy(enemy);
        return;
    }

    int enemyAttack = enemy.AttackDice.Throw();
    int playerDefence = player.DefenceDice.Throw();
    int counterDamage = enemyAttack - playerDefence;
    if (counterDamage > 0)
        player.HP -= counterDamage;

    lastMessage += $"\n   {enemy.Name} gör {Math.Max(0, counterDamage)} skada på dig! ({player.HP} HP kvar)";
}


void EnemyBattle(Enemy enemy, Player player, LevelData level)
{
    Console.SetCursorPosition(0, 22);
    Console.WriteLine($" {enemy.Name} attackerar spelaren!");

    int enemyAttack = enemy.AttackDice.Throw();
    int playerDefence = player.DefenceDice.Throw();

    int damage = enemyAttack - playerDefence;
    if (damage > 0)
        player.HP -= damage;

    Console.WriteLine($"   {enemy.Name} gör {Math.Max(0, damage)}");
}


void ShowGameOver()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine();
    Console.WriteLine("=====================================");
    Console.WriteLine("               GAME OVER ");
    Console.WriteLine("=====================================");
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine("Tryck på valfri tangent för att avsluta...");
    Console.ReadKey(true);
}