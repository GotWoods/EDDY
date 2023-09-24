using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RTE*2*5*6*4*7*AlAP5z";

		var expected = new RTE_RateInformation()
		{
			InterestRate = 2,
			InterestRate2 = 5,
			InterestRate3 = 6,
			MonetaryAmount = 4,
			MonetaryAmount2 = 7,
			Date = "AlAP5z",
		};

		var actual = Map.MapObject<RTE_RateInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new RTE_RateInformation();
		if (interestRate > 0)
			subject.InterestRate = interestRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
