# Coin-FLip

A simple betting mini-game where the player wagers on Heads or Tails before flipping a coin.

At the start of each round, a betting panel is displayed allowing the player to choose a side. Once a bet is placed, the coin performs a flip animation with a random number of rotations before landing on a randomly selected result.

When the flip ends, the game compares the result with the player’s bet:

If the player wins, they receive +100 money

If the player loses, they lose 10 sanity

After the result is shown, a Retry button appears, allowing the player to place another bet. The UI updates automatically to reflect changes in the player’s statistics.

The system prevents multiple flips at the same time and ensures the result is only processed once the animation has finished.
