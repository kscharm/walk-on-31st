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

## Gameplay Instructions
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

## Game Requirements

## Known Bugs
1) As items are combined to create new items, they may be inserted later in the inventory array even if there are available spots earlier in the array. This will cause some items not render in the **regular** inventory view, but they will render in the **expanded** view.

## External Resources

## Project Task Breakdown

## Scenes to Open
1) LaunchGame - Launch the game from this scene only. You can edit the SceneController game object to change the starting scene name & initial starting position to any of the following:
    - LevelZero, Bathroom
    - LevelOne, Kitchen
    - LevelTwo, Graveyard
2) LevelZero - bathroom and living room scene
3) LevelOne - goblin kitchen scene
4) LevelTwo - outdoors graveyard scene