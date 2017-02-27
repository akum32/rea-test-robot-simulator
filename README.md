### Toy Robot Simulation [![Build Status](https://travis-ci.org/akum32/robot-simulator.svg?branch=master)](https://travis-ci.org/akum32/robot-simulator)


#### Prerequisites:

- .NET Framework 4
- NUnit 2.6.4

#### Running the app

`Run /bin/ToyRobot.App.exe`

#### Running tests

`nunit-console /src/ToyRobot.Lib.Tests/bin/Release/ToyRobot.Lib.Tests.dll`
`nunit-console /src/ToyRobot.App.Tests/bin/Release/ToyRobot.App.Tests.dll` 

#### Project Structure

/src/ToyRobot.Lib - Core library  
/src/ToyRobot.App - Console App  
/src/ToyRobot.Lib.Tests - Unit Tests for core library	  
/src/ToyRobot.App.Tests - End-to-end acceptance tests   	
