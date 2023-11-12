using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SMOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMO*J*n*Y*R*8*9*h";

		var expected = new SMO_OperationalServices()
		{
			AutomobileRampFacilityCode = "J",
			IntermodalFacilityCode = "n",
			YesNoConditionOrResponseCode = "Y",
			YesNoConditionOrResponseCode2 = "R",
			Weight = 8,
			RailCarPlateSizeCode = "9",
			ImportExportCode = "h",
		};

		var actual = Map.MapObject<SMO_OperationalServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
