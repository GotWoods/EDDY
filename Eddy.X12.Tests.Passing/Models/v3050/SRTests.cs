using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SR*a*R*lTTS*2oHO*Z*4*7*9ob2yz*nIQou6*7*a";

		var expected = new SR_RequestedServiceSchedule()
		{
			AssignedIdentification = "a",
			DayRotation = "R",
			Time = "lTTS",
			Time2 = "2oHO",
			FreeFormMessage = "Z",
			UnitPrice = 4,
			Quantity = 7,
			Date = "9ob2yz",
			Date2 = "nIQou6",
			ProductServiceID = "7",
			ProductServiceID2 = "a",
		};

		var actual = Map.MapObject<SR_RequestedServiceSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lTTS", "2oHO", true)]
	[InlineData("lTTS", "", false)]
	[InlineData("", "2oHO", true)]
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
	[InlineData("9ob2yz", "nIQou6", true)]
	[InlineData("9ob2yz", "", false)]
	[InlineData("", "nIQou6", true)]
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
