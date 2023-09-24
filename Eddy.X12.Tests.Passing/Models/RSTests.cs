using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RS*7*9*L*v*0qVIHD5X*7JgjU5b3";

		var expected = new RS_RateSubset()
		{
			AssignedNumber = 7,
			Number = 9,
			RateLevelQualifierCode = "L",
			RateLevel = "v",
			Date = "0qVIHD5X",
			Date2 = "7JgjU5b3",
		};

		var actual = Map.MapObject<RS_RateSubset>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		subject.Number = 9;
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		subject.AssignedNumber = 7;
		if (number > 0)
		subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "v", true)]
	[InlineData("L", "", false)]
	public void Validation_ARequiresBRateLevelQualifierCode(string rateLevelQualifierCode, string rateLevel, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		subject.AssignedNumber = 7;
		subject.Number = 9;
		subject.RateLevelQualifierCode = rateLevelQualifierCode;
		subject.RateLevel = rateLevel;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
