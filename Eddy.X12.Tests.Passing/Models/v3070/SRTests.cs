using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SR*R*S*zJnb*poKQ*E*3*5*HnV9uN*BeeUBv*Q*b";

		var expected = new SR_RequestedServiceSchedule()
		{
			AssignedIdentification = "R",
			DayRotation = "S",
			Time = "zJnb",
			Time2 = "poKQ",
			FreeFormMessage = "E",
			UnitPrice = 3,
			Quantity = 5,
			Date = "HnV9uN",
			Date2 = "BeeUBv",
			ProductServiceID = "Q",
			ProductServiceID2 = "b",
		};

		var actual = Map.MapObject<SR_RequestedServiceSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("poKQ", "zJnb", true)]
	[InlineData("poKQ", "", false)]
	[InlineData("", "zJnb", true)]
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
	[InlineData("BeeUBv", "HnV9uN", true)]
	[InlineData("BeeUBv", "", false)]
	[InlineData("", "HnV9uN", true)]
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
