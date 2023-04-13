using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class UDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UD*rc*1I*M*LICRjB4D*y*eS*7*nO*9*o*6*W*4*nO*Iv*YK*XX";

		var expected = new UD_UnderwritingStatus()
		{
			StatusCode = "rc",
			StatusCode2 = "1I",
			UnderwritingDecisionCode = "M",
			Date = "LICRjB4D",
			Description = "y",
			OfferBasisCode = "eS",
			AssignedNumber = 7,
			OfferBasisCode2 = "nO",
			AssignedNumber2 = 9,
			Description2 = "o",
			PercentageAsDecimal = 6,
			Amount = "W",
			Number = 4,
			StateOrProvinceCode = "nO",
			CountryCode = "Iv",
			StateOrProvinceCode2 = "YK",
			CountryCode2 = "XX",
		};

		var actual = Map.MapObject<UD_UnderwritingStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rc", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new UD_UnderwritingStatus();
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, "", true)]
	[InlineData("o", 6, "", true)]
	[InlineData("", 6, "", true)]
	[InlineData("o", 0, "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Description2(string description2, decimal percentageAsDecimal, string amount, bool isValidExpected)
	{
		var subject = new UD_UnderwritingStatus();
		subject.StatusCode = "rc";
		subject.Description2 = description2;
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;
		subject.Amount = amount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
