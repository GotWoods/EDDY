using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LRQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LRQ*6*5*ft*1*Y*B*L*A*Gr*9p*4*3*7*R*B*y*1v*L*9*g";

		var expected = new LRQ_MortgageCharacteristicsRequested()
		{
			MonetaryAmount = 6,
			Percent = 5,
			RateValueQualifier = "ft",
			MonetaryAmount2 = 1,
			TypeOfResidenceCode = "Y",
			ContactMethodCode = "B",
			YesNoConditionOrResponseCode = "L",
			AssumptionTermsCode = "A",
			LoanPurposeCode = "Gr",
			PurposeOfRefinanceCode = "9p",
			MonetaryAmount3 = 4,
			MonetaryAmount4 = 3,
			Description = "7",
			Description2 = "R",
			RealEstateLoanTypeCode = "B",
			Description3 = "y",
			LoanPaymentTypeCode = "1v",
			Description4 = "L",
			Number = 9,
			Description5 = "g",
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
			subject.RateValueQualifier = "ft";
			subject.MonetaryAmount2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ft", 1, true)]
	[InlineData("ft", 0, false)]
	[InlineData("", 1, false)]
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
