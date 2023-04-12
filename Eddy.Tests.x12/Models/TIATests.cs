using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIA**3*r*3**9*8";

		var expected = new TIA_TaxInformationAndAmount()
		{
			TaxFieldIdentification = "",
			MonetaryAmount = 3,
			FixedFormatInformation = "r",
			Quantity = 3,
			CompositeUnitOfMeasure = "",
			PercentageAsDecimal = 9,
			MonetaryAmount2 = 8,
		};

		var actual = Map.MapObject<TIA_TaxInformationAndAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredTaxFieldIdentification(C037_TaxFieldIdentification taxFieldIdentification, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		subject.TaxFieldIdentification = taxFieldIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(9, 8, false)]
	[InlineData(0, 8, true)]
	[InlineData(9, 0, true)]
	public void Validation_OnlyOneOfPercentageAsDecimal(decimal percentageAsDecimal, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		subject.TaxFieldIdentification = "";
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
