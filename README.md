# Basic scheduling using Quartz.Net nuget library 
This project demo how the Quartz.Net library can be used to schedule function executions. The schedules are kept in process memory.

- Using basic schedule of 30 seconds repeated
- Using cron expression to schedule every minute
- List all schedules
- Remove all schedules

# How to run
- Clone the repo and run using Visual Studio,VS Code or `dotnet` command
- It will show the menu. Try different options

# Specifications

- .Net version - .Net 8
- Nugets referenced
	- DotNet.Helpers
	- easyconsolestd
	- [Quartz](https://www.nuget.org/packages/Quartz)

# Dependency injection

- Supported. Refer the [Program.cs](/src/Program.cs) file for more details
- The options are injected as dependency to the [MenuService](/src/MenuService.cs then those are invoked based on selection. 

# Points to note
- This is not tested to production quality.
