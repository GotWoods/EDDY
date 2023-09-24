using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LRQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LRQ*3*7*89*1*i*F*u*J*iv**1*6*t*b*m*Z*kh*A*8*0*Ew";

		var expected = new LRQ_MortgageCharacteristicsRequested()
		{
			MonetaryAmount = 3,
			PercentageAsDecimal = 7,
			RateValueQualifier = "89",
			MonetaryAmount2 = 1,
			TypeOfResidenceCode = "i",
			ContactMethodCode = "F",
			YesNoConditionOrResponseCode = "u",
			AssumptionTermsCode = "J",
			LoanPurposeCode = "iv",
			CompositeUseOfProceeds = null,
			MonetaryAmount3 = 1,
			MonetaryAmount4 = 6,
			Description = "t",
			Description2 = "b",
			RealEstateLoanTypeCode = "m",
			Description3 = "Z",
			LoanPaymentTypeCode = "kh",
			Description4 = "A",
			Number = 8,
			Description5 = "0",
			CodeCategory = "Ew",
		};

		var actual = Map.MapObject<LRQ_MortgageCharacteristicsRequested>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LRQ_MortgageCharacteristicsRequested();
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("89", 1, true)]
	[InlineData("", 1, false)]
	[InlineData("89", 0, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new LRQ_MortgageCharacteristicsRequested();
		subject.MonetaryAmount = 3;
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
