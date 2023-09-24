using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class TIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIA**4*O*7**5*5";

		var expected = new TIA_TaxInformationAndAmount()
		{
			TaxFieldIdentification = null,
			MonetaryAmount = 4,
			FixedFormatInformation = "O",
			Quantity = 7,
			CompositeUnitOfMeasure = null,
			PercentageAsDecimal = 5,
			MonetaryAmount2 = 5,
		};

		var actual = Map.MapObject<TIA_TaxInformationAndAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTaxFieldIdentification(string taxFieldIdentification, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		//Test Parameters
		if (taxFieldIdentification != "") 
			subject.TaxFieldIdentification = new C037_TaxFieldIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(5, 5, false)]
	[InlineData(5, 0, true)]
	[InlineData(0, 5, true)]
	public void Validation_OnlyOneOfPercentageAsDecimal(decimal percentageAsDecimal, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		subject.TaxFieldIdentification = new C037_TaxFieldIdentification();
		//Test Parameters
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
