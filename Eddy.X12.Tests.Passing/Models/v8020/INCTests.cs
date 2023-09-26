using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class INCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INC*DC**2*8*1*d";

		var expected = new INC_InstallmentInformation()
		{
			TermsTypeCode = "DC",
			CompositeUnitOfMeasure = null,
			Quantity = 2,
			Quantity2 = 8,
			MonetaryAmount = 1,
			AmountQualifierCode = "d",
		};

		var actual = Map.MapObject<INC_InstallmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DC", true)]
	public void Validation_RequiredTermsTypeCode(string termsTypeCode, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 2;
		//Test Parameters
		subject.TermsTypeCode = termsTypeCode;
		//If one filled, all required
		if(subject.MonetaryAmount > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.AmountQualifierCode))
		{
			subject.MonetaryAmount = 1;
			subject.AmountQualifierCode = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.TermsTypeCode = "DC";
		subject.Quantity = 2;
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.MonetaryAmount > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.AmountQualifierCode))
		{
			subject.MonetaryAmount = 1;
			subject.AmountQualifierCode = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.TermsTypeCode = "DC";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.MonetaryAmount > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.AmountQualifierCode))
		{
			subject.MonetaryAmount = 1;
			subject.AmountQualifierCode = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "d", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "d", false)]
	public void Validation_AllAreRequiredMonetaryAmount(decimal monetaryAmount, string amountQualifierCode, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.TermsTypeCode = "DC";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 2;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
