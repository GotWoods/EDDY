using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SMOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMO*0*N*f*o*1*X*U";

		var expected = new SMO_OperationalServices()
		{
			AutomobileRampFacilityCode = "0",
			IntermodalFacilityCode = "N",
			YesNoConditionOrResponseCode = "f",
			YesNoConditionOrResponseCode2 = "o",
			Weight = 1,
			RailCarPlateSizeCode = "X",
			ImportExportCode = "U",
		};

		var actual = Map.MapObject<SMO_OperationalServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
