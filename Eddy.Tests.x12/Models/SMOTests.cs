using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SMOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMO*E*8*W*M*7*I*m";

		var expected = new SMO_OperationalServices()
		{
			AutomobileRampFacilityCode = "E",
			IntermodalFacilityCode = "8",
			YesNoConditionOrResponseCode = "W",
			YesNoConditionOrResponseCode2 = "M",
			Weight = 7,
			RailCarPlateSizeCode = "I",
			ImportExportCode = "m",
		};

		var actual = Map.MapObject<SMO_OperationalServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
