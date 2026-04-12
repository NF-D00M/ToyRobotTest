# ToyRobotTest

The purpose of this console application is to test the actions of a virtual toy robot.

# Dependencies

* **Runtime:** .NET 9.0 SDK
* **Testing Framwork:** xUnit 2.x   

# Running the Program

1. `git clone https://github.com/NF-D00M/ToyRobotTest.git`
2. `dotnet restore`
3. `dotnet build`
3. `cd ToyRobotTest.App`
4. `dotnet run`

## Toy Robot Controls

This console application requests a user to enter the below controls, moving a robot on the position of a 5 x 5 table. 

### Rules

* The robot cannot be placed on the table if:
  * The co-ordinates exceed the boundary range 0-4.
  * The directions dont exist. The user can only input NORTH, EAST, SOUTH, WEST.
* The robot can only process these commands once placed on the table. MOVE, LEFT, RIGHT, REPORT.
* The robot can only move a position if the next move position does not exceed the boundary range 0-4.

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
4. `REPORT` { Expected Output: 1,3,EAST }

# Tests

1. `cd ToyRobotTest.Tests`
2. `dotnet restore`
3. `dotnet test`


# Requirements

Please refer to `Requirements.txt` for a list of the applications technical implementation and business rules.

* [x] Main Menu/Simualtor
* [x] Commands
* [x] Tests

# Key Technical Implementation

## Boundary Check - Contast Time Efficiency 

* The time efficiency of verifying if co-ordinate x and y are within the bounds of the tables dimensions are in O(1), constant time. Checking the bounds of x,y always takes the same amount of time no matter the size of the grid due to one operation of inequalities. 

## Rotating Position Left & Right

* The modulo equation is the most scalable and flexible solution, as it avoid chainging if else statements. If the border of a position expands from 4 to 5, then the equations paramaters just needs to adjust match the number oreientations.  

# Future Enhancements

