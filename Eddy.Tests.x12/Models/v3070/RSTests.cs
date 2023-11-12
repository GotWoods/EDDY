using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RS*3*5*d*o*49YUaZ*XWzoQB*33*52";

		var expected = new RS_RateSubset()
		{
			AssignedNumber = 3,
			Number = 5,
			RateLevelQualifierCode = "d",
			RateLevel = "o",
			Date = "49YUaZ",
			Date2 = "XWzoQB",
			Century = 33,
			Century2 = 52,
		};

		var actual = Map.MapObject<RS_RateSubset>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		//Required fields
		subject.Number = 5;
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		//Required fields
		subject.AssignedNumber = 3;
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "o", true)]
	[InlineData("d", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBRateLevelQualifierCode(string rateLevelQualifierCode, string rateLevel, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		//Required fields
		subject.AssignedNumber = 3;
		subject.Number = 5;
		//Test Parameters
		subject.RateLevelQualifierCode = rateLevelQualifierCode;
		subject.RateLevel = rateLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(33, "49YUaZ", true)]
	[InlineData(33, "", false)]
	[InlineData(0, "49YUaZ", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		//Required fields
		subject.AssignedNumber = 3;
		subject.Number = 5;
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(52, "XWzoQB", true)]
	[InlineData(52, "", false)]
	[InlineData(0, "XWzoQB", true)]
	public void Validation_ARequiresBCentury2(int century2, string date2, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		//Required fields
		subject.AssignedNumber = 3;
		subject.Number = 5;
		//Test Parameters
		if (century2 > 0) 
			subject.Century2 = century2;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
