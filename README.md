# 🕹️ Dungeon Crawler - Lab 2 (C# Console Game)

This is a simple**dungeon crawler** console game built in **C#** for the *Lab 2 assignment*.  
The player explores a dungeon, fights enemies (Rats 🐀 and Snakes 🐍), and tries to survive as long as possible.

---

## 🎯 Features

- Procedural-style level loading from `Level1.txt`
- Player movement (⬆️⬇️⬅️➡️)
- Turn-based combat using dice rolls 🎲
- Two enemy types:
  - **Rat** – moves randomly
  - **Snake** – flees from the player if within 2 tiles
- Vision system (fog of war):  
  The player can only see within a 5-tile radius.
- Persistent discovered walls 🧱
- HP system with **Game Over** screen on death 💀
- Color-coded elements for better readability

---

## 🧩 Class Structure

### Core Classes
| Class | Description |
|-------|--------------|
| `LevelElement` | Abstract base class for all map elements (walls, player, enemies). |
| `Wall` | Inherits from `LevelElement`. Represents static walls (`#`). |
| `Enemy` | Abstract base class for all enemies. |
| `Rat` | Moves in random directions each turn. |
| `Snake` | Moves away from the player if nearby. |
| `Player` | Controlled by the user, can attack enemies and explore the map. |
| `Dice` | Simulates dice rolls used for attacks and defense. |
| `LevelData` | Handles reading from file, drawing the level, and tracking discovered walls. |

---

## ⚔️ Combat System

Combat is resolved through **dice rolls**:

- **Attack**: Attacker rolls their attack dice.
- **Defense**: Defender rolls their defense dice.
- Damage = Attack - Defense (minimum 0).
- If HP ≤ 0 → character dies.

Each entity has unique stats:

| Entity | HP | Attack Dice | Defence Dice |
|---------|----|--------------|---------------|
| Player | 100 | 2d6+2 | 2d6+0 |
| Rat | 10 | 1d6+3 | 1d6+1 |
| Snake | 25 | 3d4+2 | 1d8+5 |

---

## 🚶‍♂️ Movement Rules

- Player moves one tile per turn.
- Cannot move through walls or enemies.
- Rats move randomly each turn.
- Snakes only move when the player is close.

---

## 🧱 Level File Format

The level is loaded from a text file (e.g. `Level1.txt`) 



---

## 🖥️ How to Run

1. Open the project in **Visual Studio** or **VS Code**.


3. Run the program (`Ctrl + F5`).
4. Move the player using arrow keys.
5. Press **Esc** to quit.

---

## 🧑‍💻 Author

Developed by *Vendela Magnusson* as part of the **ITHS C# Lab 2 – Object Oriented Programming** assignment.




