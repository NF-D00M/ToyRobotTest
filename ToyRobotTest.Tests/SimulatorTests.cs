using ToyRobotTest.App;

namespace ToyRobotTest.Tests;

public class SimulatorTests
{
    [Fact]
    public void SimulatorExample1Test()
    {
        //  Arrange
        // Instantiate objects and set expectedReport
        Robot robot = new Robot(5);
        Simulator simulator = new Simulator(robot);

        string filePath = "TestFiles/Example1.txt";
        string expectedReport = "0,1,NORTH";

        // Act
        // Read file line by line
        ReadFile(filePath, simulator);

        // Set actual report string
        string actualReport = robot.Report();

        // Assert
        Assert.Equal(expectedReport, actualReport);
    }

    [Fact]
    public void SimulatorExample2Test()
    {
        //  Arrange
        // Instantiate objects, set file path and expectedReport string
        Robot robot = new Robot(5);
        Simulator simulator = new Simulator(robot);

        string filePath = "TestFiles/Example2.txt";
        string expectedReport = "0,0,WEST";

        // Act
        // Read file line by line
        ReadFile(filePath, simulator);

        // Set actual report string
        string actualReport = robot.Report();

        // Assert
        Assert.Equal(expectedReport, actualReport);
    }

    public void ReadFile(String filePath, Simulator simulator)
    {
        foreach (string line in File.ReadLines(filePath))
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                simulator.Execute(line);
            }
        }
    }
}
