# Escapade
Year 13 A-Level Computer Science NEA where I created an educational game demo that makes use of multiple algorithms. The premis of the game is to create a randomly generated 2d World displayed in a form, where you control a sprite with 4 directional movement and also shooting functionality. An enemy would then proceed to follow you around as your one obstacle, utilising the A Star algorithm

## Notable Algorithms:
### A* Algorithm 
* The main enemy in this game uses the A* algorithm to quickly and efficiently follow the player around different sections of the map to stop them from

### Custom Path Generation 
* Every Level map is generated using a custom-made algorithm that takes a 4x4 grid to produce a path with a guaranteed exit.

### Custom Section Generation 
* Each map is divided into 16 sections that get procedurally generated according to the corresponding path value.

### Custom Section Fill 
* Each section that has been created is filled with a calculated amount of the different available items to provide balanced gameplay.

### Section Switching 
* Each section on my map is sectioned off according to the generated sizes, these sections get loaded in
according to my players position, to improve frame rate when moving.

### Bullet Movement 
* The player can shoot bullets that damage enemies and travel x amount of spaces, a single movement space per timer tick.
