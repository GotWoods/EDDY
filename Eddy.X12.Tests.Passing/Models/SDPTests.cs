using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SDPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDP*E*u*1*T*H*z*Q*l";

		var expected = new SDP_ShipDeliveryPattern()
		{
			ShipDeliveryOrCalendarPatternCode = "E",
			ShipDeliveryPatternTimeCode = "u",
			ShipDeliveryOrCalendarPatternCode2 = "1",
			ShipDeliveryPatternTimeCode2 = "T",
			ShipDeliveryOrCalendarPatternCode3 = "H",
			ShipDeliveryPatternTimeCode3 = "z",
			ShipDeliveryOrCalendarPatternCode4 = "Q",
			ShipDeliveryPatternTimeCode4 = "l",
		};

		var actual = Map.MapObject<SDP_ShipDeliveryPattern>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredShipDeliveryOrCalendarPatternCode(string shipDeliveryOrCalendarPatternCode, bool isValidExpected)
	{
		var subject = new SDP_ShipDeliveryPattern();
		subject.ShipDeliveryPatternTimeCode = "u";
		subject.ShipDeliveryOrCalendarPatternCode = shipDeliveryOrCalendarPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredShipDeliveryPatternTimeCode(string shipDeliveryPatternTimeCode, bool isValidExpected)
	{
		var subject = new SDP_ShipDeliveryPattern();
		subject.ShipDeliveryOrCalendarPatternCode = "E";
		subject.ShipDeliveryPatternTimeCode = shipDeliveryPatternTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
