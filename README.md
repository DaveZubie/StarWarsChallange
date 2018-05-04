# StarWarsChallange
Read Ships from https://swapi.co/ and calculate number of resupplies needed 

# Basic Usage
Running the Console app will present you with a screen where you can enter the number of MGLT you wish to travel.
Two lists will be returned:
1) List of all ships that can travel the distance and the number of supply stops required.
2) All other ships where some detail is missing and we cannot perform the calculaions.

# Projects
The solution consits of 3 projects
1) StarWarsConsole
	This is the main Console app. 
	It will display the intial welcome and accept your input.
	It will also run the calculaions for resupplys and display the results.
	
2) StarWarsChallange
	This contains the main class for Ships.
	It also contains additional helper classes for ApiHandler, ErrorHandler and Constants.

3) UnitTestProject
	Containt Integration and Unit tests.
	
# Methods
Ship.ResuppliesRequired is the main method to calculate the supply stops required.

ApiHandler.APIReader will read a the url passed in.

ErrorHandler.ReturnErrorDescription will return a custom error description based on the error code.