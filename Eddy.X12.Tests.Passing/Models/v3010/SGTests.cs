using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SG*3*4BH*Q3*IZkTm0*pu0s*Pp";

		var expected = new SG_ShipmentStatus()
		{
			StatusCode = "3",
			StatusReasonCode = "4BH",
			DispositionCode = "Q3",
			Date = "IZkTm0",
			Time = "pu0s",
			TimeCode = "Pp",
		};

		var actual = Map.MapObject<SG_ShipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
