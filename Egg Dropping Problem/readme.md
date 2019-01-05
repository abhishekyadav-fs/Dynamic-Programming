# Egg Dropping Problem
> Egg Dropping Problem 

Suppose a building has n floors. If we have m eggs, how can we find the minimum number of drops needed to determine from which floors
it is safe to drop an egg (in other words, it won’t break)?

Just to clarify the problem, here are the rules:

1. There exactly n floors and m eggs
2. If an egg does not break from a given floor, it will also not break on any lower floor
2. If an egg breaks when dropped from a given floor, it will also break on any higher floor
2. If an egg breaks, it must be discarded


There are several ways to go about this problem. We’ll present a recursive and a bottom-up dynamic programming approach here.
