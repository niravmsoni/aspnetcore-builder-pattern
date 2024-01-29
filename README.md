# Builder Pattern
	- Part of Creational design pattern since it deals with creation of objects
	- Useful for creating complex objects
		- When object creation needs to be separate from its assembly
		- When different representations neeeds to be created with finer control

	- For this example
		- InventoryReport 
			- Complex object we want to build
				- Contains Properties
					- TitleSection
					- DimensionsSection;
					- LogisticsSection;
		- IFurnitureInventoryBuilder
			- Builder interface that has method that would help concrete implementation build the actual object
				- Contains methods
					- AddTitle()
					- AddLogistics()
					- AddDimensions()
					- Build()
		- DailyReportBuilder
			- Concrete builder responsible for building InventoryReportObject
				- Contains field that stores the instance of InventoryReport
		- InventoryBuildDirector
			- Class responsible for executing whatever concrete builder is requested for execution
		

	- Approach#1 - Using Director class
		- From Program.cs, 
			- Create instance of Concrete Builder (DailyReportBuilder)
			- Create instance of director class and pass in reference of concrete builder that will be used by the director class to build object
			- Call Build method responsible for building actual object

		- Less practically used since it has a lot of abstractions
	- Approach#2 - Fluent Builder approach
		- From Program.cs
			- Create instance of Concrete Builder (DailyReportBuilder)
			- Start Building the object directly