using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class INCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INC*hq**4*7*1*m";

		var expected = new INC_InstallmentInformation()
		{
			TermsTypeCode = "hq",
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			Quantity2 = 7,
			MonetaryAmount = 1,
			AmountQualifierCode = "m",
		};

		var actual = Map.MapObject<INC_InstallmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hq", true)]
	public void Validation_RequiredTermsTypeCode(string termsTypeCode, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		//Test Parameters
		subject.TermsTypeCode = termsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.TermsTypeCode = "hq";
		subject.Quantity = 4;
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.TermsTypeCode = "hq";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "m", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "m", false)]
	public void Validation_AllAreRequiredAmountQualifierCode(decimal monetaryAmount, string amountQualifierCode, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.TermsTypeCode = "hq";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
