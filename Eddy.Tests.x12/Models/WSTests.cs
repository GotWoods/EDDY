using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class WSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "WS*6*d9Uf*ljEE";

		var expected = new WS_WorkSchedule()
		{
			ShipDeliveryOrCalendarPatternCode = "6",
			Time = "d9Uf",
			Time2 = "ljEE",
		};

		var actual = Map.MapObject<WS_WorkSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredShipDeliveryOrCalendarPatternCode(string shipDeliveryOrCalendarPatternCode, bool isValidExpected)
	{
		var subject = new WS_WorkSchedule();
		subject.ShipDeliveryOrCalendarPatternCode = shipDeliveryOrCalendarPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
