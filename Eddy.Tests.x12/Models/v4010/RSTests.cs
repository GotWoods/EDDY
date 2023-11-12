using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RS*3*8*B*4*nke9tF8R*QkesSwgR";

		var expected = new RS_RateSubset()
		{
			AssignedNumber = 3,
			Number = 8,
			RateLevelQualifierCode = "B",
			RateLevel = "4",
			Date = "nke9tF8R",
			Date2 = "QkesSwgR",
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
		subject.AssignedNumber = 3;
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "4", true)]
	[InlineData("B", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBRateLevelQualifierCode(string rateLevelQualifierCode, string rateLevel, bool isValidExpected)
	{
		var subject = new RS_RateSubset();
		//Required fields
		subject.AssignedNumber = 3;
		subject.Number = 8;
		//Test Parameters
		subject.RateLevelQualifierCode = rateLevelQualifierCode;
		subject.RateLevel = rateLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
