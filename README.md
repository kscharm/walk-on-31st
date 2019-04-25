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
1)
2)
3)
4)
### Fun
1)
2)
3)
4)
### 3D Real-Time Character Control
1)
2)
3)
4)
### Physics Simulation
1)
2)
3)
4)
### Artificial Intelligence (AI)

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

## External Resources
Nandan cite all assets here!
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