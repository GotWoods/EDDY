using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RTE*9*7*2*2*3*Y07X3O*3*8";

		var expected = new RTE_RateInformation()
		{
			InterestRate = 9,
			InterestRate2 = 7,
			InterestRate3 = 2,
			MonetaryAmount = 2,
			MonetaryAmount2 = 3,
			Date = "Y07X3O",
			NumberOfDays = 3,
			NumberOfDays2 = 8,
		};

		var actual = Map.MapObject<RTE_RateInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new RTE_RateInformation();
		subject.InterestRate2 = 7;
		if (interestRate > 0)
			subject.InterestRate = interestRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredInterestRate2(decimal interestRate2, bool isValidExpected)
	{
		var subject = new RTE_RateInformation();
		subject.InterestRate = 9;
		if (interestRate2 > 0)
			subject.InterestRate2 = interestRate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
