using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class SRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SR*j*v*UW7z*O7DM*C*4*5*Rv7qXHX3*3rid9OAC*l*y";

		var expected = new SR_RequestedServiceSchedule()
		{
			AssignedIdentification = "j",
			DayRotation = "v",
			Time = "UW7z",
			Time2 = "O7DM",
			FreeFormMessage = "C",
			UnitPrice = 4,
			Quantity = 5,
			Date = "Rv7qXHX3",
			Date2 = "3rid9OAC",
			ProductServiceID = "l",
			ProductServiceID2 = "y",
		};

		var actual = Map.MapObject<SR_RequestedServiceSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O7DM", "UW7z", true)]
	[InlineData("O7DM", "", false)]
	[InlineData("", "UW7z", true)]
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
	[InlineData("3rid9OAC", "Rv7qXHX3", true)]
	[InlineData("3rid9OAC", "", false)]
	[InlineData("", "Rv7qXHX3", true)]
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
