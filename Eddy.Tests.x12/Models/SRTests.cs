using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SR*T*7*oWRU*ozTZ*b*7*5*NMB6cJWE*l5LGyzC8*h*R";

		var expected = new SR_RequestedServiceSchedule()
		{
			AssignedIdentification = "T",
			DayRotation = "7",
			Time = "oWRU",
			Time2 = "ozTZ",
			FreeFormMessage = "b",
			UnitPrice = 7,
			Quantity = 5,
			Date = "NMB6cJWE",
			Date2 = "l5LGyzC8",
			ProductServiceID = "h",
			ProductServiceID2 = "R",
		};

		var actual = Map.MapObject<SR_RequestedServiceSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "oWRU", true)]
	[InlineData("ozTZ", "", false)]
	public void Validation_ARequiresBTime2(string time2, string time, bool isValidExpected)
	{
		var subject = new SR_RequestedServiceSchedule();
		subject.Time2 = time2;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "NMB6cJWE", true)]
	[InlineData("l5LGyzC8", "", false)]
	public void Validation_ARequiresBDate2(string date2, string date, bool isValidExpected)
	{
		var subject = new SR_RequestedServiceSchedule();
		subject.Date2 = date2;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
