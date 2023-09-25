using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class XDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XD*9F*w9*J0*Wd*LL*ZY";

		var expected = new XD_PlacementPullData()
		{
			SwitchTypeCode = "9F",
			Zone = "w9",
			Track = "J0",
			Spot = "Wd",
			Spot2 = "LL",
			StandardCarrierAlphaCode = "ZY",
		};

		var actual = Map.MapObject<XD_PlacementPullData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9F", true)]
	public void Validation_RequiredSwitchTypeCode(string switchTypeCode, bool isValidExpected)
	{
		var subject = new XD_PlacementPullData();
		//Required fields
		//Test Parameters
		subject.SwitchTypeCode = switchTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
