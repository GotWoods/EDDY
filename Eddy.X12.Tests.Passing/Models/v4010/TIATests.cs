using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010.Composites;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIA**1*v*6**2*6";

		var expected = new TIA_TaxInformationAndAmount()
		{
			TaxFieldIdentification = null,
			MonetaryAmount = 1,
			FixedFormatInformation = "v",
			Quantity = 6,
			CompositeUnitOfMeasure = null,
			Percent = 2,
			MonetaryAmount2 = 6,
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
	[InlineData(2, 6, false)]
	[InlineData(2, 0, true)]
	[InlineData(0, 6, true)]
	public void Validation_OnlyOneOfPercent(decimal percent, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		subject.TaxFieldIdentification = new C037_TaxFieldIdentification();
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
