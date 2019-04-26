# A Walk on 31st
You are on a walk with your dog. All of a sudden, a man dressed in all black knocks you out and you wake up in an unknown bathroom. Escape each of our three levels (bathroom/living room, kitchen, graveyard) to save your dog from danger!

## Team Nothing BASIC Contact Information
|    Name      |    ID    |        Email        |
|:------------:|:--------:|:-------------------:|
| Kenny Scharm | kscharm3 | kscharm3@gatech.edu |
| Ryan Power | jpower30 | jpower30@gatech.edu |
| Sammi Hudock | shudock3 | shudock3@gatech.edu |
| Nandan Gouri | ngouri3 | ngouri3@gatech.edu |
| Brian Kalish | bkalish3 | bkalish3@gatech.edu |
| Erik Sampayo | esampayo3 | eriksampayo@gatech.edu |

## Installation
Clone this repository using ```git clone https://github.gatech.edu/kscharm3/nothing_BASIC.git``` and open the project with the Unity 3D editor (Note: it may take a while to import assets and compile scripts).

## Run the Game
To run the game, navigate to ```nothing_BASIC/Builds``` and run ```Walk_on_31st.exe```. 

## Gameplay Instructions
*Note: for optimal gameplay experience, be sure to use a mouse!*
### Game Objective
Escape each level by finding the correct items and solving puzzles! A timer is displayed in the upper left corner of the screen. Completing a level will add more time to the timer. If the timer hits zero, you lose! 

### Player Movement
Use the **WASD** keys to control the character. To run, hold the **left shift** key.

### Item Interactions
The "hand" cursor will indicate if an item in the game is interactable. To interact with an item, click the **left mouse** button.

### Inventory
There are two views for player inventory: **regular** and **expanded**. In the regular inventory view, the first four item slots are displayed on the righthand side of the screen. To open the expanded view, click the '<' icon to the left of the regular inventory view. To close the expanded view, click the '>' icon.

### Camera Control
To control the camera, click and hold the **right mouse** button. This allows the player to check out the scenery of the level!

### Hints
To get a hint for the level, press the **h** key. The dog will sniff out the next item you need to find.

### Pause/Exit
To bring up the pause menu, press the **esc** key. To exit, click the **exit game** button within the pause menu.

## Game Requirements
### Game Feel
- Achievable goal: escape each room by solving puzzles
- Player fails if they run out of time (displayed in the upper left corner)
- Player is set back by getting caught by traps
- Communicate level completion success with auditory and visual feedback
- Communicate level failure by displaying “Game Over”, with the option to restart the game
- Informed decisions (both immediate and long-term) through interactable items

### Fun
- Main goal: you are trapped and need to escape 
    - A countdown timer creates a sense of urgency
    - A spooky atmosphere also creates apprehension 
- Sub-goal: Exploration
    - An unknown environment encourages the player to explore
- Sub-goal: Level-specific puzzles
    - Level 0: Unlocking the bathroom door, knocking out the drunk guy
    - Level 1: Understanding the goblins, using the correct recipes to feed them
    - Level 2: Building the shovel, finding a key, turning off the generator

### 3D Real-Time Character Control
- Full WASD movement
- Fluid animations for walking, running, and turning
    - Walking: move forward or backward
    - Running: hold SHIFT and move forward or backward
    - Turning: move left or right without moving forward or backward
- Full camera panning by holding down right click and dragging the mouse in the desired direction
- Animations played when interacting with (clicking on) certain interactables
- Auditory feedback when clicking on interactable items and other in-game events
- Player becomes ragdoll that utilizes rigidbody physics when attacked by an enemy

### Physics Simulation
- Plenty of interactive scripted objects such as opening doors, throwing a bottle, and lowering a fence
- Simulated Newtonian physics on ragdolls that can be pushed around
- Plenty of animated objects such as moving doors, opening a refrigerator, opening an oven, opening a coffin, and digging and filling in graves
- State changing objects can be observed when draining the bathtub or lowering the electric fence
- Multiple AI states of behavior can be seen in both the dog (following player vs walking towards objects that need to be interacted with) and the gravedigger (patrolling the graveyard vs chasing the player)
- The AI has sensory feedback, such as the goblins cheering when given the correct food combination and getting angry and attacking the player when given the wrong combination. Feedback can also be seen in the Gravedigger AI, where he starts with a slow patrol using his lantern until he sees the player and angrily chases her with a sword

### Artificial Intelligence (AI)
- Gravedigger AI
    - Patrols graveyard using a lantern and chases the player if they are seen
    - FSM states: patrol, chase, attack
    - Different animations for each of the states
    - Path planning: navigate through 13 waypoints
    - Lantern sways back and forth
    - Auditory feedback when the player is first seen
- Dog AI
    - Interacts with environment by sniffing out interactable items
    - Navigates to the items if the player takes too long, or the player presses the hint key
    - Follows the player around (as a dog should)
- Drunk guy AI
    - Stands still until approached by the player
    - Chases the player until knocked out by the bottle

### Polish
- Start menu and in-game pause menu with ability to restart or exit the game
- Styled game over, win, and credit scenes
- Transitions between levels with a short fade out, fade in cut scene
- Getting knocked out by an enemy triggers player ragdoll followed by a fade out, fade in cut scene 
- Player interaction animations with interactable objects
- Scripted interactable object animations: flopping fish, standing drunk guy, hungry goblins, gravekeeper with lantern
- Proximity-based events: drunk guy knocks you out if he gets to close, gravekeeper chases you after being alerted and knocks you out if you get caught
- Physics event-based feedback: throwing bottle at drunk guy
- Particle effects: water in tub, lighting, electricity on fence
- Audio effects: drunk man grumbling
- Unified aesthetic: consistent spooky theme throughout game, flickering/dim lighting


## Known Bugs
1) As items are combined to create new items, they may be inserted later in the inventory array even if there are available spots earlier in the array. This will cause some items not render in the **regular** inventory view, but they will render in the **expanded** view.

## Gameplay Walkthrough

### Level Zero
- Turn left, and crank the nozzle to drain the water
- Pick up the key from the tub and the green fish from the toilet
- Unlock the door, turn to the left, and pick up the bottle
- Turn around and pick up the dictionary on the table
- Walk towards the drunk guy and throw the bottle at the guy by clicking on him
- Pick up the key that he drops and unlock the exit door

### Level One
- Turn to the right and pick up the ladle
- Navigate to the orange potion in the middle of the room and click on it
- Navigate to the cauldron sitting on top of the stove and click on it to mix the green fish with the orange sauce 
- Click on the goblin closest to the purple fish to feed him
- Now, open the refrigerator to find the yellow fish
- Click on the green sauce in the middle of the room
- Click on the cauldron to mix the green sauce and yellow fish
- Feed the remaining goblin to complete the room
- You can now exit the room

### Level Two
- Turn to the right and click on the small tree to get a branch
-Turn around and navigate to the open grave (with no coffin) to find a shovel head; these two items will create a shovel
- Go to the third row of graves and dig the grave that is third from the left (facing the electric fence)
- Click on the coffin to open it
- Click on the gold key
- Close the coffin and click on the bottom of the grave to fill it back in
- Fill in the remaining graves by clicking on them
- Navigate to the dirt pile and observe a generator sticking out of the ground
- Click on the generator, which kills the electricity
- Click on the red fence and walk through to finish the game

## External Resources
### Level Zero Assets
- [Realistic Furniture And Interior Props Pack](https://assetstore.unity.com/packages/3d/props/furniture/realistic-furniture-and-interior-props-pack-120379) by Sevastian Marevoy
    - Bathroom Scenery, Couches Chairs

- Unity Adventure Game tutorial/Assets
    - Player
    - Fish Sprites

- [House On The Lake](https://assetstore.unity.com/packages/3d/environments/house-on-the-lake-95020) by Sevastian Marevoy
    - Water

- [Worn Bookshelf](https://assetstore.unity.com/packages/3d/props/interior/worn-bookshelf-8458) by Jason Wong
    - Bookshelf, Dictionary 1, 2, library books in the cases in level 1

### Level One Assets
- [Magic Mirror Lite - Reflection for Unity](https://assetstore.unity.com/packages/tools/particles-effects/magic-mirror-lite-reflection-for-unity-34824) by  Digital Ruby (Jeff Johnson)

- [PBR Ladle](https://assetstore.unity.com/packages/3d/props/interior/pbr-ladle-129004) by 3D.BJ:

- [Troll Сannibal](https://assetstore.unity.com/packages/3d/characters/humanoids/troll-annibal-110766) by Kazimir

- [Small Town America - Streets - FREE](https://assetstore.unity.com/packages/3d/small-town-america-streets-free-59759) by MultiFlagStudios
Floor Texture

- [Human bone 3D Model](https://sketchfab.com/3d-models/human-bone-0c92f04640ba420dbb3a7d35a744a398
) by Luar.Larep

- [Fishbones Rigged 3D Model](https://sketchfab.com/3d-models/fishbones-rigged-81247232321c4203a3b3ea85a71d2311) by NTSC

### Level Two Assets
- [Bandit & Pirate Pack](https://assetstore.unity.com/packages/3d/characters/humanoids/bandit-pirate-pack-124445) by Rain Entertainment
    - Gravekeeper with Lantern

- [FREE Cartoon Halloween Pack](https://assetstore.unity.com/packages/3d/free-cartoon-halloween-pack-45896) by Lumo-Art 3D
    - Cauldron, Graves, Lamps

- [PBR Ground Materials #2 [Dirt, Grass & Rocky]](https://assetstore.unity.com/packages/2d/textures-materials/floors/pbr-ground-materials-2-dirt-grass-rocky-89369) by John's Junkyard Assets
    - Ground 

- Lightning Bolt Effect for Unity by Jeff Johnson
- [PBR Sci-Fi Exterior Props: Generator](https://assetstore.unity.com/packages/3d/props/pbr-sci-fi-exterior-props-generator-120019) by CaptainCatSparrow:

- [Coffin Royale](https://assetstore.unity.com/packages/3d/props/coffin-royale-76412) by @pauloscreations

- [Stylized Trees (Low Poly)](https://assetstore.unity.com/packages/3d/vegetation/trees/stylized-trees-low-poly-49916) by Tom Poon
    - Trees with no leaves
- [Rusty Black Shovel](https://assetstore.unity.com/packages/3d/props/tools/rusty-black-shovel-73088) by Sergi Nicolás

- [Church 3D](https://assetstore.unity.com/packages/3d/environments/fantasy/church-3d-68143) by Andreicg
- [Medieval Fantasy House](https://assetstore.unity.com/packages/3d/environments/fantasy/medieval-fantasy-house-31856) by Robin Tucker

- [Medieval Stone Keep](https://assetstore.unity.com/packages/3d/environments/medieval-stone-keep-56596) by Lylek Games

### Miscellaneous Assets
- [Low Poly Animated Dog](https://assetstore.unity.com/packages/3d/characters/animals/low-poly-animated-dog-66214) by Nitacawo
- [Sculpted Fish 3D Model](https://sketchfab.com/3d-models/sculpted-fish-fa644b7d5ad2447a8d21517908cd0343) by thatguyjay

## Project Task Breakdown
- **Kenny**: inventory system, interaction system, condition checking system, player running movement, scene persistence with data savers, various object animations (fridge, stove, coffins, graves)
- **Ryan**: kitchen level interaction logic, implemented general player movement with arrow keys, player footstep audio for walking/running, goblin animations
- **Sammi**: cursor change on mouse hover over interactable, lighting scripts, global timer variables, audio design, level scenery design, scene menu (start, end, win, credits) design, inventory sprites
- **Nandan**: graveyard digger AI, recipe making interactions, level 1/2 interactions, general room design and implementation
- **Brian**: dog AI pathplanning & navmesh generation, hint interaction system, general room design and implementation
- **Erik**: level 0 drunk guy AI, bottle throwing interaction, camera control movement with mouse click, ragdoll animations, general lighting effects

## Scenes to Open
1) LaunchGame - Launch the game from this scene only. You can edit the SceneController game object to change the starting scene name & initial starting position to any of the following:
    - LevelZero, Bathroom
    - LevelOne, Kitchen
    - LevelTwo, Graveyard
2) LevelZero - bathroom and living room scene
3) LevelOne - goblin kitchen scene
4) LevelTwo - outdoors graveyard scene