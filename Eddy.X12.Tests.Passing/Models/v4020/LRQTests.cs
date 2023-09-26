using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class LRQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LRQ*6*8*oG*8*c*D*H*n*lQ**2*5*q*4*s*n*FI*z*7*n*OM";

		var expected = new LRQ_MortgageCharacteristicsRequested()
		{
			MonetaryAmount = 6,
			Percent = 8,
			RateValueQualifier = "oG",
			MonetaryAmount2 = 8,
			TypeOfResidenceCode = "c",
			ContactMethodCode = "D",
			YesNoConditionOrResponseCode = "H",
			AssumptionTermsCode = "n",
			LoanPurposeCode = "lQ",
			CompositeUseOfProceeds = null,
			MonetaryAmount3 = 2,
			MonetaryAmount4 = 5,
			Description = "q",
			Description2 = "4",
			RealEstateLoanTypeCode = "s",
			Description3 = "n",
			LoanPaymentTypeCode = "FI",
			Description4 = "z",
			Number = 7,
			Description5 = "n",
			CodeCategory = "OM",
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
			subject.RateValueQualifier = "oG";
			subject.MonetaryAmount2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("oG", 8, true)]
	[InlineData("oG", 0, false)]
	[InlineData("", 8, false)]
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
