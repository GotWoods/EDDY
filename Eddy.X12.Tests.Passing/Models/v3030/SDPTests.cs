using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SDPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDP*N*V*l*5*M*n*t*x";

		var expected = new SDP_ShipDeliveryPattern()
		{
			ShipDeliveryOrCalendarPatternCode = "N",
			ShipDeliveryPatternTimeCode = "V",
			ShipDeliveryOrCalendarPatternCode2 = "l",
			ShipDeliveryPatternTimeCode2 = "5",
			ShipDeliveryOrCalendarPatternCode3 = "M",
			ShipDeliveryPatternTimeCode3 = "n",
			ShipDeliveryOrCalendarPatternCode4 = "t",
			ShipDeliveryPatternTimeCode4 = "x",
		};

		var actual = Map.MapObject<SDP_ShipDeliveryPattern>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredShipDeliveryOrCalendarPatternCode(string shipDeliveryOrCalendarPatternCode, bool isValidExpected)
	{
		var subject = new SDP_ShipDeliveryPattern();
		subject.ShipDeliveryPatternTimeCode = "V";
		subject.ShipDeliveryOrCalendarPatternCode = shipDeliveryOrCalendarPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredShipDeliveryPatternTimeCode(string shipDeliveryPatternTimeCode, bool isValidExpected)
	{
		var subject = new SDP_ShipDeliveryPattern();
		subject.ShipDeliveryOrCalendarPatternCode = "N";
		subject.ShipDeliveryPatternTimeCode = shipDeliveryPatternTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
