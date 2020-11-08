This game is a 2D platformer focusing on tilemaps.
This game uses PennyPixel assets that are unity recommended start point when learning about tilemaps.

Game Features
- RuleTilemap made for stone/jungle tiles.
- Auto generated terrain using various procedural algorithms:
     - Cellular Automata
     - Directional Tunnel
     - Perlin Noise
     - Random Walk - Current one implemented
- Gem Spawner - in a random X-axis range

Game Problems:
- Auto generated algorithm has few seeds -> generated terrains pattern repeats itself. (this only affects runtime, an increase number of seeds can be set before running).
- Gems that have collision cannot be picked up.
- Gems that don't have collision fall through map.