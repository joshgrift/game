# Game idea

| A way to have players play vs "agents" controlled by an API. For fun.

Some goals:

- Rounds should be less then 30 min when played with players to facilitate training and iteration
- Should be fairly enjoyable for the player
- Easy to save game states into a file for testing and training purposes
- Open ended strategy, not something like chess which is more finite.

## Game

A turn based strategy game based on civ/aoe/catan. Last one standing is the win condition.

### Map

- A hex map
- 2 different types of tiles, passible and not (ground & water)
- Fog of war
- Hand made maps because I don't want a random generator yet

### Turns & Units

Turn based gameplay. In a specific order. Each player (human or AI) get's their turn to move and buy units.

There a couple classifications of units, but they will have a few attributes. Each class will have different starter/max values. Attributes marked with a star can be depleted during a turn or on an ongoing basis.

- Sight (how many tiles can you see)
- Cost (How much you cost)
- Armor Type (How you resist damage)
- Attack Type (What type of damage you deal)
- Damage Amount (How much damage you do)
- Movement\* (how many tiles can you move)
- Health\* (how close to death)
- Abilities (What abilities can you do)

There's a table that shows us what type of attack does more damage to what type of armour. For example, "sword" attack has a 50% reduction in attack damage to a "horseback" armour unit. Maybe "spear" attack has 50% increase vs "horseback" armour.

### Cities

You start with one city. Cities produce 1 gold per turn. You can place a new city by a unit with that ability. You buy a unit from a city. When another player lands on a city, your city is gone. Money is local to a city.

## Technical

- C# because I want to learn more about C#.
- C# python library to interact with the API
- JS webview to interact with game

## Some future ideas

- Types of resources instead of just gold
- Terrain modifiers for damage & speed
- More terrain types
- City upgrades
- random maps
