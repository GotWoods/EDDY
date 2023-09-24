using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class RTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RTE*R*9*9*4*1";

		var expected = new RTE_RateInformation()
		{
			RateQualifierCode = "R",
			InterestRate = 9,
			MonetaryAmount = 9,
			Number = 4,
			Number2 = 1,
		};

		var actual = Map.MapObject<RTE_RateInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredRateQualifierCode(string rateQualifierCode, bool isValidExpected)
	{
		var subject = new RTE_RateInformation();
		subject.InterestRate = 9;
		subject.RateQualifierCode = rateQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new RTE_RateInformation();
		subject.RateQualifierCode = "R";
		if (interestRate > 0)
			subject.InterestRate = interestRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
