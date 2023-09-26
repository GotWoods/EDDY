using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PEXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PEX*lB*z0*3*SH*0*M6*E*";

		var expected = new PEX_PropertyOrHousingExpense()
		{
			GeneralExpenseQualifier = "lB",
			RateValueQualifier = "z0",
			MonetaryAmount = 3,
			TaxTypeCode = "SH",
			YesNoConditionOrResponseCode = "0",
			EntityIdentifierCode = "M6",
			TaxExemptCode = "E",
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<PEX_PropertyOrHousingExpense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lB", true)]
	public void Validation_RequiredGeneralExpenseQualifier(string generalExpenseQualifier, bool isValidExpected)
	{
		var subject = new PEX_PropertyOrHousingExpense();
		//Required fields
		//Test Parameters
		subject.GeneralExpenseQualifier = generalExpenseQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier = "z0";
			subject.MonetaryAmount = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("z0", 3, true)]
	[InlineData("z0", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PEX_PropertyOrHousingExpense();
		//Required fields
		subject.GeneralExpenseQualifier = "lB";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
