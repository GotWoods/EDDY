using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DH*F*XBdF*gAfw";

		var expected = new DH_DealerHours()
		{
			ShipDeliveryOrCalendarPatternCode = "F",
			Time = "XBdF",
			Time2 = "gAfw",
		};

		var actual = Map.MapObject<DH_DealerHours>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredShipDeliveryOrCalendarPatternCode(string shipDeliveryOrCalendarPatternCode, bool isValidExpected)
	{
		var subject = new DH_DealerHours();
		//Required fields
		subject.Time = "XBdF";
		subject.Time2 = "gAfw";
		//Test Parameters
		subject.ShipDeliveryOrCalendarPatternCode = shipDeliveryOrCalendarPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XBdF", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new DH_DealerHours();
		//Required fields
		subject.ShipDeliveryOrCalendarPatternCode = "F";
		subject.Time2 = "gAfw";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gAfw", true)]
	public void Validation_RequiredTime2(string time2, bool isValidExpected)
	{
		var subject = new DH_DealerHours();
		//Required fields
		subject.ShipDeliveryOrCalendarPatternCode = "F";
		subject.Time = "XBdF";
		//Test Parameters
		subject.Time2 = time2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
