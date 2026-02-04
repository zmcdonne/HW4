# HW4
## Devlog
In this project, I used the Model View Controller (MVC) pattern to keep the Player code decoupled from the rest of the game systems by separating the Player from the UI and Audio classes and having them subscribed to events through the GameController about the Player. The model layer is less significant in this game, as there isn’t a lot of data stored other than keeping track of points, so I focused mainly on the view and controller aspects to the best of my understanding.

In general the  model acts as a data container, for example, lines of dialogue or game data being stored (often using ScriptableObjects). ScriptableObjects can act as the model because they store game data separately from what the player sees.

In terms of which classes define the controller side of this pattern for this coding project I would say the classes Player, GameController, and Pipe/ScoreZone (which helps the Player increment points). The GameController class manages overall gameplay logic, such as spawning pipes (SpawnPipe) using the pipe prefab, handling game-over (EndGame), and acting as a central coordinator for game systems (implemented as a Singleton).The Player class handles player input and core interaction logic, such as processing input (e.g., spacebar presses).

When the player earns points (by passing through the ScoreZone 2D BoxCollider), the Player class invokes an event, a pointsChanged event that is listened to by the UI and Audio systems. Instead of directly referencing UI, audio, or other systems, the Player simply raises the event. This means the Player does not need to be referenced directly in every class, which keeps it decoupled.

The view side of the MVC pattern is defined by systems responsible for visuals and feedback rather than gameplay logic. These include UI elements (TextMeshPro score text), player and pipe sprites, and audio feedback(   Gamecontroller.Instance.Player.PointsChanged += PlayPointSound;)  For example, the UI and audio systems subscribe to the Player’s pointsChanged event rather than being directly referenced by the Player. This means the view layer reacts to changes in the game state without controlling gameplay logic.

I used both events and a Singleton, with the GameController implemented as a Singleton. It provides global access to the Player, letting other systems subscribe to the Player’s scoring event through the GameController. Some code examples from this system in general: 
GameController.Instance.Player.pointsChanged += HandlePointsChanged;      and         PointsChanged?.Invoke(points); 
This way, the Player does not directly reference UI, audio, or score systems. UI and audio systems only listen for events, and the GameController acts as a mediator rather than tightly coupling systems, at least according to my current understanding. After finishing the project, I think I could have structured it better.
In summary, the Player has its own control logic, and the UI and audio systems exist independently as part of the view layer. New UI elements or audio effects can now be added by subscribing to pointsChanged without modifying the Player class.





## Open-Source Assets

- [200 Free SFX](https://kronbits.itch.io/freesfx) - sound effects
- [Simple Bird Sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites](https://hredbird.itch.io/simple-bird-sprites ) - bird sprites
- [Industrial Pipe Platformer Tileset](https://wwolf-w.itch.io/industrial-pipe-platformer-tileset) - Pip sprites


