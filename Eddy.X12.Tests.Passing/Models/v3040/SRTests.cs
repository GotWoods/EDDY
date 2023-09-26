using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SR*H*y*A5G5*Gnrs*s*7*5*vG58pu*aiCWqp*v*M";

		var expected = new SR_AdvertisingScheduleRequested()
		{
			AssignedIdentification = "H",
			DayRotation = "y",
			Time = "A5G5",
			Time2 = "Gnrs",
			FreeFormMessage = "s",
			UnitPrice = 7,
			Quantity = 5,
			Date = "vG58pu",
			Date2 = "aiCWqp",
			ProductServiceID = "v",
			ProductServiceID2 = "M",
		};

		var actual = Map.MapObject<SR_AdvertisingScheduleRequested>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A5G5", "Gnrs", true)]
	[InlineData("A5G5", "", false)]
	[InlineData("", "Gnrs", true)]
	public void Validation_ARequiresBTime(string time, string time2, bool isValidExpected)
	{
		var subject = new SR_AdvertisingScheduleRequested();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.Time2 = time2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vG58pu", "aiCWqp", true)]
	[InlineData("vG58pu", "", false)]
	[InlineData("", "aiCWqp", true)]
	public void Validation_ARequiresBDate(string date, string date2, bool isValidExpected)
	{
		var subject = new SR_AdvertisingScheduleRequested();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
