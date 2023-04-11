using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IM*y*rz*8s";

		var expected = new IM_IntermodalMovementInformation()
		{
			WaterMovementCode = "y",
			SpecialHandlingCode = "rz",
			InlandTransportationCode = "8s",
		};

		var actual = Map.MapObject<IM_IntermodalMovementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
