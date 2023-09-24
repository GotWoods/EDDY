using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class XDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XD*Yg*Kb*1y*Q8*gn*he*u";

		var expected = new XD_PlacementPullData()
		{
			SwitchTypeCode = "Yg",
			Zone = "Kb",
			Track = "1y",
			Spot = "Q8",
			Spot2 = "gn",
			StandardCarrierAlphaCode = "he",
			LoadEmptyStatusCode = "u",
		};

		var actual = Map.MapObject<XD_PlacementPullData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yg", true)]
	public void Validation_RequiredSwitchTypeCode(string switchTypeCode, bool isValidExpected)
	{
		var subject = new XD_PlacementPullData();
		//Required fields
		//Test Parameters
		subject.SwitchTypeCode = switchTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
