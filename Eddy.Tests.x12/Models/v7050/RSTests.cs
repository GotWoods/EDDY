using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class RSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RS*6*8*q*F*xqATkM6s*bd9HFW2X";

		var expected = new RS_RateSubset()
		{
			AssignedNumber = 6,
			Number = 8,
			RateLevelQualifierCode = "q",
			RateLevel = "F",
			Date = "xqATkM6s",
			Date2 = "bd9HFW2X",
		};

		var actual = Map.MapObject<RS_RateSubset>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		//Required fields
		subject.Number = 8;
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		//Required fields
		subject.AssignedNumber = 6;
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "F", true)]
	[InlineData("q", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBRateLevelQualifierCode(string rateLevelQualifierCode, string rateLevel, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		//Required fields
		subject.AssignedNumber = 6;
		subject.Number = 8;
		//Test Parameters
		subject.RateLevelQualifierCode = rateLevelQualifierCode;
		subject.RateLevel = rateLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
