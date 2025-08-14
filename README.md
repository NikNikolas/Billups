### Game API Exam
	
# Description 

- This project is REST API with methods that supports playing game "Rock Paper Scissors Lizard Spock"
- Here are the rules for "RPSLS" game: http://www.samkass.com/theories/RPSSL.html

- This project is used for technical skills demonstration, it is not Production ready.

# Prerequisites

- .NET CORE 8

- Ensure you have the correct dotnet-core SDK installed for your system: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

# Usage

- Clone this repository
- Set the project GameAPI as Startup Project
- Run the project
- Swagger UI will be up, every method could be invoked via Swagger 'Try it out' option

# Architecture

- This template uses something like the Onion Architecture.
- It has few common layers:
	* Domain
		- Data.Abstraction (repository abstraction)
		- DTO (contains DTO classes)
	* Infrastructure
		- Data (Repository implementation)
		- Utilities (Common - shared library)
	* Services (Application)
		- Service.Abstraction
		- Service (implementation)
	*API Project
	*Test project
	
- The main idea with this architecture is that higher layer may access only the abstraction of lower layer:
	- API can access only Service abstraction layer
	- Service abstraction layer can only access Repository abstraction layer
	- Service abstraction is not dependent on service implementation
	- Repository abstraction is not dependent of repository implementation
	
	
# Components 

#Dependency injection

- Dependency injection is performed via Autofac.
- Every layer has it's own Module class used for registration of components
- In abstraction layers (services and repository) there is configuration for reading their implementation layers.
	Reading those dll files is also perfomed in Module classes, while location for those dll implementation is configured
	in appSettings.json file (AppSettings part)
	
#Database

- There is no concrete implementation of database
- All data are stored in LocalDb.cs of project Infrastructure.Data. That is in memory data with initialy populated codebooks

#Logger

- Logging is performed via nLog nuget
- All loggin configuration is in nlog.config file
	- directory where log files will be created
	- log level configuraton