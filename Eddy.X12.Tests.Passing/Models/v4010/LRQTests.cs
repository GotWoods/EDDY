using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LRQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LRQ*9*3*p8*7*6*O*q*D*7q**7*2*e*7*m*7*sl*G*8*w";

		var expected = new LRQ_MortgageCharacteristicsRequested()
		{
			MonetaryAmount = 9,
			Percent = 3,
			RateValueQualifier = "p8",
			MonetaryAmount2 = 7,
			TypeOfResidenceCode = "6",
			ContactMethodCode = "O",
			YesNoConditionOrResponseCode = "q",
			AssumptionTermsCode = "D",
			LoanPurposeCode = "7q",
			CompositeUseOfProceeds = null,
			MonetaryAmount3 = 7,
			MonetaryAmount4 = 2,
			Description = "e",
			Description2 = "7",
			RealEstateLoanTypeCode = "m",
			Description3 = "7",
			LoanPaymentTypeCode = "sl",
			Description4 = "G",
			Number = 8,
			Description5 = "w",
		};

		var actual = Map.MapObject<LRQ_MortgageCharacteristicsRequested>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LRQ_MortgageCharacteristicsRequested();
		//Required fields
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount2 > 0)
		{
			subject.RateValueQualifier = "p8";
			subject.MonetaryAmount2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("p8", 7, true)]
	[InlineData("p8", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new LRQ_MortgageCharacteristicsRequested();
		//Required fields
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
