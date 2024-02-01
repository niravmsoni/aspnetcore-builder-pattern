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

	- Use cases
		- Not for everything - It is actually an overkill for most classes where subclassing, refactoring or abstract interfaces would be better solution
		- To be used where we see Bloated class constructors
		- When we know of finite number of related classes performing similar functions with different representations

	- Implications
		- Lets us vary product internal representation
		- Isolates code for construction and representation
		- Finer control over construction process
		- Shares similarities with Factory pattern. Difference is Builder responsible for creation of a single object whereas Factory responsible for creation of factories of similar objects




	//Concrete class
	public class AuditMessage
	{
		public string OrganizationId{get;set;}
		public string Service{get;set;}
		public string Endpoint{get;set;}
		public string Payload{get;set;}
		public string Timestamp{get;set;}
	}

	//Builder interface
	public interface IAuditMessageBuilder
	{
		IAuditMessageBuilder SetOrg(string org);
		IAuditMessageBuilder SetService(string svc);
		IAuditMessageBuilder SetEndpoint(string endpoint);
		IAuditMessageBuilder SetPayload(string payload);
		AuditMessage Build();
	}

	//Concrete builder
	public class AuditMessageBuilder : IAuditMessageBuilder
	{
		private readonly AuditMessage _auditMessage;
		public AuditMessageBuilder()
		{
			_auditMessage = new();
		}

		public IAuditMessageBuilder SetOrg(string org)
		{
			_auditMessage.OrganizationId = org;
			return this;
		}
		public IAuditMessageBuilder SetService(string svc)
		{
			_auditMessage.Service = svc;
			return this;
		}
		public IAuditMessageBuilder SetEndpoint(string endpoint)
		{
			_auditMessage.Endpoint = endpoint;
			return this;
		}
		public IAuditMessageBuilder SetPayload(string payload)
		{
			_auditMessage.Payload = payload;
			return this;
		}
		public AuditMessage Build()
		{
			_auditMessage.Timestamp = DateTime.UtcNow;
			return _auditMessage;
		}
	}

	//DI-Wireup
	services.AddScoped<IAuditMessageBuilder, AuditMessageBuilder>();

	//Consumer
	public class HomeController : ControllerBase
	{
		private readonly IAuditMessageBuilder _auditMessageBuilder;

		public HomeController(IAuditMessageBuilder auditMessageBuilder)
		{
			_auditMessageBuilder = auditMessageBuilder;
		}

		[HttpGet, Route("/get")]
		public IActionResult Get(CancellationToken cancellationToken)
		{
			//Get audit message
			var auditMessage = _auditMessageBuilder.SetOrg("SetOrg)
			.SetService("Svc")
			.SetEndpoint("endpoint")
			.SetPayload("payload")
			.Build();
		}
	}