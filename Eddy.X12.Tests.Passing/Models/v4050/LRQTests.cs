using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class LRQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LRQ*6*1*rF*9*6*3*e*V*1X**4*2*0*b*Y*Q*0H*b*2*F*Ma";

		var expected = new LRQ_MortgageCharacteristicsRequested()
		{
			MonetaryAmount = 6,
			PercentageAsDecimal = 1,
			RateValueQualifier = "rF",
			MonetaryAmount2 = 9,
			TypeOfResidenceCode = "6",
			ContactMethodCode = "3",
			YesNoConditionOrResponseCode = "e",
			AssumptionTermsCode = "V",
			LoanPurposeCode = "1X",
			CompositeUseOfProceeds = null,
			MonetaryAmount3 = 4,
			MonetaryAmount4 = 2,
			Description = "0",
			Description2 = "b",
			RealEstateLoanTypeCode = "Y",
			Description3 = "Q",
			LoanPaymentTypeCode = "0H",
			Description4 = "b",
			Number = 2,
			Description5 = "F",
			CodeCategory = "Ma",
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
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount2 > 0)
		{
			subject.RateValueQualifier = "rF";
			subject.MonetaryAmount2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("rF", 9, true)]
	[InlineData("rF", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new LRQ_MortgageCharacteristicsRequested();
		//Required fields
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
