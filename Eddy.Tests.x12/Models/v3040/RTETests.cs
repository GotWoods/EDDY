using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RTE*Q*9*9*9*4";

		var expected = new RTE_RateInformation()
		{
			RateQualifier = "Q",
			InterestRate = 9,
			MonetaryAmount = 9,
			NumberOfDays = 9,
			NumberOfDays2 = 4,
		};

		var actual = Map.MapObject<RTE_RateInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredRateQualifier(string rateQualifier, bool isValidExpected)
	{
		var subject = new RTE_RateInformation();
		subject.InterestRate = 9;
		subject.RateQualifier = rateQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new RTE_RateInformation();
		subject.RateQualifier = "Q";
		if (interestRate > 0)
			subject.InterestRate = interestRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
