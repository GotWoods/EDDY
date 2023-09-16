using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SDPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDP*y*J*5*r*9*2*R*e";

		var expected = new SDP_ShipDeliveryPattern()
		{
			ShipDeliveryPatternCode = "y",
			ShipDeliveryPatternTimeCode = "J",
			ShipDeliveryPatternCode2 = "5",
			ShipDeliveryPatternTimeCode2 = "r",
			ShipDeliveryPatternCode3 = "9",
			ShipDeliveryPatternTimeCode3 = "2",
			ShipDeliveryPatternCode4 = "R",
			ShipDeliveryPatternTimeCode4 = "e",
		};

		var actual = Map.MapObject<SDP_ShipDeliveryPattern>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredShipDeliveryPatternCode(string shipDeliveryPatternCode, bool isValidExpected)
	{
		var subject = new SDP_ShipDeliveryPattern();
		subject.ShipDeliveryPatternTimeCode = "J";
		subject.ShipDeliveryPatternCode = shipDeliveryPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredShipDeliveryPatternTimeCode(string shipDeliveryPatternTimeCode, bool isValidExpected)
	{
		var subject = new SDP_ShipDeliveryPattern();
		subject.ShipDeliveryPatternCode = "y";
		subject.ShipDeliveryPatternTimeCode = shipDeliveryPatternTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
