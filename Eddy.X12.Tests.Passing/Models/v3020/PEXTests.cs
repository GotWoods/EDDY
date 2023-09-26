using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PEXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PEX*qk*RW*7*0k*z";

		var expected = new PEX_PropertyOrHousingExpense()
		{
			GeneralExpenseQualifier = "qk",
			RateValueQualifier = "RW",
			MonetaryAmount = 7,
			TaxTypeCode = "0k",
			YesNoConditionOrResponseCode = "z",
		};

		var actual = Map.MapObject<PEX_PropertyOrHousingExpense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qk", true)]
	public void Validation_RequiredGeneralExpenseQualifier(string generalExpenseQualifier, bool isValidExpected)
	{
		var subject = new PEX_PropertyOrHousingExpense();
		//Required fields
		//Test Parameters
		subject.GeneralExpenseQualifier = generalExpenseQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier = "RW";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("RW", 7, true)]
	[InlineData("RW", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PEX_PropertyOrHousingExpense();
		//Required fields
		subject.GeneralExpenseQualifier = "qk";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
