# ToyRobotTest

The purpose of this console application is to test the actions of a virtual toy robot. 

* The `ToyRobotTest.App` project interfaces with manual CLI input. 
* The `ToyRobotTest.Tests` project passes the `commands.txt` requirement in test case: `SimulatorTets.SimulatorCommandsTest` 

# Dependencies

* **Runtime:** .NET 9.0 SDK
* **Testing Framwork:** xUnit 2.x   

# Running the Program

To run the application clone the repository, change directory to ToyRobotTest.App, and build the binaries.

1. `git clone https://github.com/NF-D00M/ToyRobotTest.git`
1. `cd ToyRobotTest.App`
3. `dotnet restore`
4. `dotnet build`
5. `dotnet run`

## Toy Robot Controls

This console application requests a user to enter the below controls, moving a robot on the position of a 5 x 5 table, however the robot has a list of rules which impact it's decisions.

### Rules

* The robot cannot be placed on the table if:
  * The co-ordinates exceed the boundary range 0-4.
  * The directions dont exist. The user can only input NORTH, EAST, SOUTH, WEST.
* The robot can only process these commands once placed on the table. MOVE, LEFT, RIGHT, REPORT.
* The robot can only move a position, if the next move position does not exceed the boundary range 0-4.

### Controls

* `PLACE X,Y,F` -- Places robot at co-ordinates at x, y, and facing direction NORTH, EAST, SOUT, WEST
* `MOVE` -- Moves robot one space forward in the facing direction
* `LEFT` -- Rotates the robot left 90 degrees
* `RIGHT` -- Rotates the robot right 90 degrees
* `REPORT` -- Prints co-ordinates and direction to console

## Toy Robot Example

1. `PLACE 1,1,NORTH`
2. `MOVE`
3. `MOVE`
4. `RIGHT`
5. `REPORT` { Expected Output: 1,3,EAST }

# Tests

To run the tests, change directory to ToyRobotTest.Tests, and build the binaries.

1. `cd ToyRobotTest.Tests`
2. `dotnet restore`
3. `dotnet test`

# Requirements

Please refer to `Requirements.txt` for a list of the applications technical implementation and business rules.

* [x] Main Menu/Simualtor
* [x] Commands
* [x] Tests

# Technical Implementation

## Architecture

This project separates concerns from input, simulation logic and the robots state.

* `Program.cs` provides the runtime.
* `Simulator.cs` parses string from text and controls movements of the robot.
* `Robot.cs` Accepts table dimensions in it's constructor so that the table size can scale, and enforces the rules/constraits for each command.

Design Patterns

* Dependency Injection: THe `IRobot` interfaces allows the application to pass in different implementations of a Robot without introducing any breaking changes. 

## Boundary Check - Contast Time Efficiency 

* The time efficiency of verifying if co-ordinate x and y are within the bounds of the tables dimensions are in O(1), constant time. Checking the bounds of x,y always takes the same amount of time no matter the size of the grid due to one operation of **inequalities**. 

## Rotating Position Left & Right

* The modulo equation is the most scalable and flexible solution, as it avoids chaining if else statements. If the number of keys in the map increase/decrease, then the number of rotations required to create a full rotation adjusts along with the size.