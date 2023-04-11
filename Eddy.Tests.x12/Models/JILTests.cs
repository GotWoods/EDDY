using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class JILTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JIL*qH*E*6*Vv*0*xU0Avd46*e";

		var expected = new JIL_LineItemDetailForTheOperatingExpenseStatement()
		{
			ProductServiceIDQualifier = "qH",
			ProductServiceID = "E",
			MonetaryAmount = 6,
			ReferenceIdentificationQualifier = "Vv",
			ReferenceIdentification = "0",
			Date = "xU0Avd46",
			AmountQualifierCode = "e",
		};

		var actual = Map.MapObject<JIL_LineItemDetailForTheOperatingExpenseStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qH", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceID = "E";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceIDQualifier = "qH";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Vv", "0", true)]
	[InlineData("", "0", false)]
	[InlineData("Vv", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceIDQualifier = "qH";
		subject.ProductServiceID = "E";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 6, true)]
	[InlineData("e", 0, false)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceIDQualifier = "qH";
		subject.ProductServiceID = "E";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
