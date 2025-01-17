# Rope Game

Puzzle game where you need to move nodes to untangle ropes between them. When all the ropes are green, the puzzle is solved.

Made using Unity version `2022.3.47f1` 

---

## 🎮 **Gameplay Overview**

In this game:
- There is a board with nodes and ropes.
- Your task is to move the nodes around so that no ropes are intersecting.
- After the puzzle is solved, the player earns 350 points, the game returns to the "map" and can be restarted from there.
- The puzzle can be skipped by pressing the `Skip` button. In this case the player sees a possible solution for the puzzle, but doesn't earn any points.

![Game Screenshot](https://github.com/user-attachments/assets/cf186ffa-276c-42b3-a760-c884fbd41f44)

![Game Skipped](https://github.com/user-attachments/assets/9c335e76-adfa-4348-a0ff-a4b982b47287)

---

## 🔧 **Puzzle Setup**

### 1. **Puzzle Scriptable Object**
- The puzzle is generated based on a `PuzzleNodesRopes` `ScriptableObject` 
- This `ScriptableObject` has two lists, `NodesSettings` and `RopesSettings`
- Each element of `NodesSettings` determines a starting position of a puzzle's node, and some position where that node should be for the puzzle to be solved.
- Each element of `RopesSettings` determines what two nodes are connected by a rope, starting with ID of 1.

![Puzzle setup](https://github.com/user-attachments/assets/acf77689-f1ff-4696-bb52-a175d8f3955c)

### 2. **Bootstrap**
- The `PuzzleNodesRopes` `ScriptableObject` is used by the `Bootstrap` script, which controls the initialization of the game.
  
![Bootstrap](https://github.com/user-attachments/assets/ac2441c0-51c0-4cc9-a931-21968c9ba03a)

---

