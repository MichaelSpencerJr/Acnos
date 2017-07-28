Feature: ValidState

In order to confirm only valid moves can be applied to various game states
I want to set up sample game states and check if various moves are considered valid.

Background:

Scenario: Can Only Setup From Null State
Given the current game phase is None
And the current game board is the following
    | Row   | A | B | C | D | E | F | G | H |
    | 8     |   |   |   |   |   |   |   |   |
    | 7     |   |   |   |   |   |   |   |   |
    | 6     |   |   |   |   |   |   |   |   |
    | 5     |   |   |   |   |   |   |   |   |
    | 4     |   |   |   |   |   |   |   |   |
    | 3     |   |   |   |   |   |   |   |   |
    | 2     |   |   |   |   |   |   |   |   |
    | 1     |   |   |   |   |   |   |   |   |
And player one's next piece is None
And player two's next piece is None
And player one's piece bag contains:
And player two's piece bag contains:
When I retrieve available actions
Then the available actions are the following
    | Action |
    | Setup  |