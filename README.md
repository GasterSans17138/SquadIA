# SquadAI

<a href="https://www.isart.fr/"><img width="255" height="255" src = "https://pbs.twimg.com/profile_images/1554747272897990659/vh39_Bj2_400x400.jpg"></a>

## ⭐ About the Project

The SquadAi project was made with [![Static Badge](https://img.shields.io/badge/Unity-2022.3.47f1-%23D3D3D3?logo=Unity)](https://unity.com/). It's a project  where we control the chief of a squad. When we kill enemies they turn into allies and a new wave start a few moment after.

## 🕹️ Controls

The game is played with the keyboard:

|Action         |Key           |
|:-------------:|:------------:|
|Move forward   | W            |
|Move left      | A            |
|Move backward  | S            |
|Move right     | D            |
|Shoot          | Left click   |
|Tactical Shoot | Right click  |
|Protect        | Middle click |

## 📄 Specificities

|Specificity    |information       |
|:-------------:|:----------------:|
|Engine         |Unity 2022.3.47f1 |
|IDE            |Visual Studio 2022|
|Scene To Launch|MainMenu         |

## ☕ Getting Started

- launch the Unity project.
- Open the `Scenes` folder.
- Open the `MainMenu` scene.

## 🔧 AI Technics

- FSM
 
  To manage the AI behavior, we are using a finite state machine. We have four different states in the game: Shoot, Heal, Defend, and TacticalShoot. For each state, we have two decisions and transitions to decide the next state—whether it remains the same as the current one or changes to a different one.

  Example: If an ally is in the current state "Shoot" and wants to change to "Heal," a decision will be made, followed by a transition. If the AI ally wants to change back, the process will be the same: a decision followed by a transition, which will differ from the previous decision and transition made.

  There is an action for each state in the game as well. 
  The "Shoot" action means that all AI allies are constantly shooting at the closest enemy.

  The "Heal" action means that when the player's health is at or below half, one AI ally will break formation, stop shooting, and approach the player at a certain range. Then, the player will be continuously healed until their full health is restored. Afterward, the AI ally will return to shooting.
   
  The "Defend" action means that when the player middle-clicks, one AI ally will stop shooting and position itself between the player and the closest enemy to act as a shield. If the player middle-clicks again, the defending AI will return to shooting.
  
  The "TacticalShoot" action means that when the player holds the right-click, all AI allies that are shooting at an enemy will instead shoot where the player's mouse is pointed. AI allies that are healing or defending will not perform TacticalShoot.

  We use ScriptableObjects to create and manage every action, decision, transition, and state in the game. When in a state, the AI ally will perform the appropriate action corresponding to the current state and will evaluate possible decisions and transitions. Example: An AI ally that is shooting will shoot and check if the next decision should be to Heal, Defend, or TacticalShoot.

- Flocking

  We use an arrow formation to organize the AI allies around the player. The formation is dynamic and adapts to the number of allies present, with units positioned alternately on each side of the player, progressively moving further back.

  This formation follows the player at a predefined distance. Allies in specific roles, such as those healing or defending, are excluded from the formation to avoid interfering with their tasks. We use the NavMeshAgent to manage ally movements, allowing them to smoothly reach their position in the formation.

- Enemy behavior
  The enemy's behavior is quite simple. It does not move and will target the closest ally (including the player) and shoot at them.

## ✒ Authors
- [Mathieu ROBION](https://github.com/Motisma479)
- [Eliot NERRAND](https://github.com/GasterSans17138)
