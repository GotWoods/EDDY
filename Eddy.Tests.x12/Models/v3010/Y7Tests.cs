using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Y7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y7*5*2*L*3868*HFPOtF";

		var expected = new Y7_Priority()
		{
			Priority = 5,
			PriorityCode = 2,
			PriorityCodeQualifier = "L",
			PortCallFileNumber = 3868,
			RequiredDeliveryDate = "HFPOtF",
		};

		var actual = Map.MapObject<Y7_Priority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
