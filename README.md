# HW4
## Devlog

 
In this project, I used the Model–View–Controller pattern to keep the Player code decoupled from the rest of the game systems by seperating player from  Uiclass and audio class and have thems ubscribed to evetns through gamecontroller about player. The model layer is less significant in this game, as there isnt alot of data stored other the keeping track of points so I focus mainly on the view and controller aspects to the best of my understanding. Model: The data container, for example, the lines of dialogue or game data being stored (often ScriptableObjects) ScriptableObjects can act as the model, because they store game data separately from what the player sees.

whcih class defines the control side of this pattern: Player, Gamecontroller, Pipe scorezone ( just helps player increment points) 
view side being UI , Audio and which class defines the view side of this pattern.

View: The UI and visuals, such as dialogue boxes, sprites, and NPC visuals. Unity already shows some separation between components: Views are UI and visual effects. 

Controller: The logic that handles player input, for example, clicking to continue dialogue and controlling how the system progresses.  The controller side of the pattern is primarily defined by the Player and GameController classes controlling pipespawning using OnTriggerEnter2D() to detect when the player interacts with pipes and trigger scoring or game-over conditions. The Player class handles player input and core interaction logic. For example, it processes input (e.g., spacebar presses),  When the player earns points( by going through collider ), the Player class invokes an event, , with a points Changed event called in UI and Audio  Instead of directly referencing UI, audio, or other systems, the Player simply raises the event. This means the Player does not need to be refrenced directily in every class, which keeps it decoupled.

The GameController class manages overall gameplay logic, such as,, Spawning pipes in Awake() using the pipe prefab,  Handling game over states, Acting as a central coordinator for game systems aka my singleton.

The view side of the MVC pattern is defined by systems responsible for visuals and feedback rather than gameplay logic. Which include UI elements (TextMeshPro score text), Player and pipe sprites, Audio feedback (e.g., score sound effects) For example, the UI and audio systems subscribe to the Player.pointsChanged event rather than being directly referenced by the Player. This means the view layer reacts to changes in the game state without controlling gameplay logic.

To further decouple the system, I used both events and a Singleton with The GameController being implemented as a Singleton. , Provides global access to player  letting Other systems can subscribe to the player’s scoring event through the GameController, for example:
GameController.Instance.Player.pointsChanged += HandlePointsChanged;

so The Player does not directly reference UI, audio, or score systems, UI and audio systems only listen for events, and the GameController acts as a mediator rather than tightly coupling systems if I understand it corectly , that atleast the system at my curent understanding, after finishing it i think i could have structured it better.In summary the player has its own control logic, and the UI and audio systems exist independently as part of the view layer. now new UI elements or audio effects can be added by subscribing to pointsChanged without modifying the Player class.


Gamecontroller


    public Player Player { get; private set; }
SpawnPipe
and class EndGame

controll

controlling Pipe, pipe detaects collison

player controll ,         points++;
        PointsChanged?.Invoke(points); 
Player

Audio
   Gamecontroller.Instance.Player.PointsChanged += PlayPointSound;


and UI

more view

ScoreZone, addpoint when collides

UiGamecontroller.Instance.Player.PointsChanged += HandlePointsChanged;




## Open-Source Assets

- [200 Free SFX](https://kronbits.itch.io/freesfx) - sound effects
- [Simple Bird Sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites](https://hredbird.itch.io/simple-bird-sprites ) - bird sprites
- [Industrial Pipe Platformer Tileset](https://wwolf-w.itch.io/industrial-pipe-platformer-tileset) - Pip sprites


