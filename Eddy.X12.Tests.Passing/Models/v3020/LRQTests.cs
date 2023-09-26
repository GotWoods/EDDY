using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LRQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LRQ*6*5*TG*1*5*6*Y*Z*qi*hP*6*3*3*Q";

		var expected = new LRQ_MortgageCharacteristicsRequested()
		{
			MonetaryAmount = 6,
			Percent = 5,
			RateValueQualifier = "TG",
			MonetaryAmount2 = 1,
			TypeOfResidenceCode = "5",
			ContactMethodCode = "6",
			YesNoConditionOrResponseCode = "Y",
			AssumptionTermsCode = "Z",
			LoanPurposeCode = "qi",
			PurposeOfRefinanceCode = "hP",
			MonetaryAmount3 = 6,
			MonetaryAmount4 = 3,
			Description = "3",
			Description2 = "Q",
		};

		var actual = Map.MapObject<LRQ_MortgageCharacteristicsRequested>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LRQ_MortgageCharacteristicsRequested();
		//Required fields
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "TG", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "TG", true)]
	public void Validation_ARequiresBMonetaryAmount2(decimal monetaryAmount2, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new LRQ_MortgageCharacteristicsRequested();
		//Required fields
		subject.MonetaryAmount = 6;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
