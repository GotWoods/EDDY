using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PEXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PEX*05*yM*4*Wn*S*6Z*A*";

		var expected = new PEX_PropertyOrHousingExpense()
		{
			GeneralExpenseQualifier = "05",
			RateValueQualifier = "yM",
			MonetaryAmount = 4,
			TaxTypeCode = "Wn",
			YesNoConditionOrResponseCode = "S",
			EntityIdentifierCode = "6Z",
			TaxExemptCode = "A",
			CompositeUnitOfMeasure = "",
		};

		var actual = Map.MapObject<PEX_PropertyOrHousingExpense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("05", true)]
	public void Validation_RequiredGeneralExpenseQualifier(string generalExpenseQualifier, bool isValidExpected)
	{
		var subject = new PEX_PropertyOrHousingExpense();
		subject.GeneralExpenseQualifier = generalExpenseQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("yM", 4, true)]
	[InlineData("", 4, false)]
	[InlineData("yM", 0, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PEX_PropertyOrHousingExpense();
		subject.GeneralExpenseQualifier = "05";
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
