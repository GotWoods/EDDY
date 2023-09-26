using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SR*k*R*KPAt*uuAS*j*9*2*UWBIrv*iYob1W*U*g";

		var expected = new SR_RequestedServiceSchedule()
		{
			AssignedIdentification = "k",
			DayRotation = "R",
			Time = "KPAt",
			Time2 = "uuAS",
			FreeFormMessage = "j",
			UnitPrice = 9,
			Quantity = 2,
			Date = "UWBIrv",
			Date2 = "iYob1W",
			ProductServiceID = "U",
			ProductServiceID2 = "g",
		};

		var actual = Map.MapObject<SR_RequestedServiceSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KPAt", "uuAS", true)]
	[InlineData("KPAt", "", false)]
	[InlineData("", "uuAS", true)]
	public void Validation_ARequiresBTime(string time, string time2, bool isValidExpected)
	{
		var subject = new SR_RequestedServiceSchedule();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.Time2 = time2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UWBIrv", "iYob1W", true)]
	[InlineData("UWBIrv", "", false)]
	[InlineData("", "iYob1W", true)]
	public void Validation_ARequiresBDate(string date, string date2, bool isValidExpected)
	{
		var subject = new SR_RequestedServiceSchedule();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
