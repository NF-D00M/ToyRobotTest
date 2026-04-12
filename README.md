# ToyRobotTest

The purpose of this console application is to test the actions of a virtual toy robot.

# Dependencies

* **Runtime:** .NET 9.0 SDK
* **Testing Framwork:** xUnit 2.x   

# Running the Program

1. `git clone https://github.com/NF-D00M/ToyRobotTest.git`
2. dotnet restore
3. dotnet build
3. cd toyrobottest
4. dotnet run

## Toy Robot Controls

This console application requests a user to enter the below controls, moving a robot on the position of a 5 x 5 table. 

### Rules

* The robot cannot be placed on the table if:
  * The co-ordinates exceed the boundary range 0-4.
  * The directions dont exist. The user can only input NORTH, EAST, SOUTH WEST.
* The robot can only process these commands once places on the table. MOVE, LEFT, RIGHT, REPORT.
* The robot can only move if the next move does not exceed the boundary range 0-4.

### Controls

* `PLACE X,Y,F` -- Places robot at co-ordinates at x, y, and facing direction NORTH, EAST, SOUT, WEST
* `MOVE` -- Moves robot one space forward in the facing direction
* `LEFT` -- Rotates the robot left 90 degrees
* `RIGHT` -- Rotates the robot right 90 degrees
* `REPORT` -- Prints co-ordinates and direction to console

## Toy Robot Example

# Tests

# Requirements

Please refer to `Requirements.txt` for a list of the applications technical implementation and business rules.

* [x] Main Menu/Simualtor
* [x] Commands
* [x] Tests

# Key Technical Implementation

# Future Enhancements
