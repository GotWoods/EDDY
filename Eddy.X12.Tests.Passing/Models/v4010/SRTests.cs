using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SR*2*s*3XQW*vsWR*y*5*9*ZHyqSC5S*VZEGcH3Y*4*z";

		var expected = new SR_RequestedServiceSchedule()
		{
			AssignedIdentification = "2",
			DayRotation = "s",
			Time = "3XQW",
			Time2 = "vsWR",
			FreeFormMessage = "y",
			UnitPrice = 5,
			Quantity = 9,
			Date = "ZHyqSC5S",
			Date2 = "VZEGcH3Y",
			ProductServiceID = "4",
			ProductServiceID2 = "z",
		};

		var actual = Map.MapObject<SR_RequestedServiceSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vsWR", "3XQW", true)]
	[InlineData("vsWR", "", false)]
	[InlineData("", "3XQW", true)]
	public void Validation_ARequiresBTime2(string time2, string time, bool isValidExpected)
	{
		var subject = new SR_RequestedServiceSchedule();
		//Required fields
		//Test Parameters
		subject.Time2 = time2;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VZEGcH3Y", "ZHyqSC5S", true)]
	[InlineData("VZEGcH3Y", "", false)]
	[InlineData("", "ZHyqSC5S", true)]
	public void Validation_ARequiresBDate2(string date2, string date, bool isValidExpected)
	{
		var subject = new SR_RequestedServiceSchedule();
		//Required fields
		//Test Parameters
		subject.Date2 = date2;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
