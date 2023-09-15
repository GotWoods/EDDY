using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class IMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IM*W*GM*WM";

		var expected = new IM_IntermodalMovementInformation()
		{
			WaterMovementCode = "W",
			SpecialHandlingCode = "GM",
			InlandTransportationCode = "WM",
		};

		var actual = Map.MapObject<IM_IntermodalMovementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
