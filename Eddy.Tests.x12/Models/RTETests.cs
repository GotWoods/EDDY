using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RTE*t*8*5*1*7";

		var expected = new RTE_RateInformation()
		{
			RateQualifierCode = "t",
			InterestRate = 8,
			MonetaryAmount = 5,
			Number = 1,
			Number2 = 7,
		};

		var actual = Map.MapObject<RTE_RateInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredRateQualifierCode(string rateQualifierCode, bool isValidExpected)
	{
		var subject = new RTE_RateInformation();
		subject.InterestRate = 8;
		subject.RateQualifierCode = rateQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new RTE_RateInformation();
		subject.RateQualifierCode = "t";
		if (interestRate > 0)
		subject.InterestRate = interestRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
