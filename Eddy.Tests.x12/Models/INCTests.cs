using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class INCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INC*li**4*2*7*t";

		var expected = new INC_InstallmentInformation()
		{
			TermsTypeCode = "li",
			CompositeUnitOfMeasure = "",
			Quantity = 4,
			Quantity2 = 2,
			MonetaryAmount = 7,
			AmountQualifierCode = "t",
		};

		var actual = Map.MapObject<INC_InstallmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("li", true)]
	public void Validation_RequiredTermsTypeCode(string termsTypeCode, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		subject.CompositeUnitOfMeasure = "";
		subject.Quantity = 4;
		subject.TermsTypeCode = termsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(C001_CompositeUnitOfMeasure compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		subject.TermsTypeCode = "li";
		subject.Quantity = 4;
		subject.CompositeUnitOfMeasure = compositeUnitOfMeasure;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		subject.TermsTypeCode = "li";
		subject.CompositeUnitOfMeasure = "";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "t", true)]
	[InlineData(0, "t", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredMonetaryAmount(decimal monetaryAmount, string amountQualifierCode, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		subject.TermsTypeCode = "li";
		subject.CompositeUnitOfMeasure = "";
		subject.Quantity = 4;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		subject.AmountQualifierCode = amountQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
