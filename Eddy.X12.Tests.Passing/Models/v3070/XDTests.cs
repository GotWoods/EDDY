using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class XDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XD*qn*dr*20*1d*G2*0M*j*Fn";

		var expected = new XD_PlacementPullData()
		{
			SwitchTypeCode = "qn",
			Zone = "dr",
			Track = "20",
			Spot = "1d",
			Spot2 = "G2",
			StandardCarrierAlphaCode = "0M",
			LoadEmptyStatusCode = "j",
			RejectReasonCode = "Fn",
		};

		var actual = Map.MapObject<XD_PlacementPullData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qn", true)]
	public void Validation_RequiredSwitchTypeCode(string switchTypeCode, bool isValidExpected)
	{
		var subject = new XD_PlacementPullData();
		//Required fields
		//Test Parameters
		subject.SwitchTypeCode = switchTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
