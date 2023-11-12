using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060.Composites;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIA**7*H*3**6*7";

		var expected = new TIA_TaxInformationAndAmount()
		{
			TaxFieldIdentification = null,
			MonetaryAmount = 7,
			FixedFormatInformation = "H",
			Quantity = 3,
			CompositeUnitOfMeasure = null,
			Percent = 6,
			MonetaryAmount2 = 7,
		};

		var actual = Map.MapObject<TIA_TaxInformationAndAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredTaxFieldIdentification(string taxFieldIdentification, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		//Test Parameters
		if (taxFieldIdentification != "") 
			subject.TaxFieldIdentification = new C037_TaxFieldIdentification();
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	
	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 7, false)]
	[InlineData(6, 0, true)]
	[InlineData(0, 7, true)]
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
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
