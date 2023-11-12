using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class XDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XD*q9*c*A*g*Km";

		var expected = new XD_PlacementPullData()
		{
			SwitchTypeCode = "q9",
			LocationIdentifier = "c",
			LocationIdentifier2 = "A",
			LoadEmptyStatusCode = "g",
			RejectReasonCode = "Km",
		};

		var actual = Map.MapObject<XD_PlacementPullData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
