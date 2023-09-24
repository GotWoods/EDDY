using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class XDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XD*yA*u*I*U*9S";

		var expected = new XD_PlacementPullData()
		{
			SwitchTypeCode = "yA",
			LocationIdentifier = "u",
			LocationIdentifier2 = "I",
			LoadEmptyStatusCode = "U",
			RejectReasonCode = "9S",
		};

		var actual = Map.MapObject<XD_PlacementPullData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
