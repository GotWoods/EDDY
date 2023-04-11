using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DH*0*GCg3*qU5v";

		var expected = new DH_DealerHours()
		{
			ShipDeliveryOrCalendarPatternCode = "0",
			Time = "GCg3",
			Time2 = "qU5v",
		};

		var actual = Map.MapObject<DH_DealerHours>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validatation_RequiredShipDeliveryOrCalendarPatternCode(string shipDeliveryOrCalendarPatternCode, bool isValidExpected)
	{
		var subject = new DH_DealerHours();
		subject.Time = "GCg3";
		subject.Time2 = "qU5v";
		subject.ShipDeliveryOrCalendarPatternCode = shipDeliveryOrCalendarPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GCg3", true)]
	public void Validatation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new DH_DealerHours();
		subject.ShipDeliveryOrCalendarPatternCode = "0";
		subject.Time2 = "qU5v";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qU5v", true)]
	public void Validatation_RequiredTime2(string time2, bool isValidExpected)
	{
		var subject = new DH_DealerHours();
		subject.ShipDeliveryOrCalendarPatternCode = "0";
		subject.Time = "GCg3";
		subject.Time2 = time2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
