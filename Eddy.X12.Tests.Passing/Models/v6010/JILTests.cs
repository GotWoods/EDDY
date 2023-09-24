using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class JILTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JIL*hk*Y*4*8z*8*P7jJ7lZ4*f";

		var expected = new JIL_LineItemDetailForTheOperatingExpenseStatement()
		{
			ProductServiceIDQualifier = "hk",
			ProductServiceID = "Y",
			MonetaryAmount = 4,
			ReferenceIdentificationQualifier = "8z",
			ReferenceIdentification = "8",
			Date = "P7jJ7lZ4",
			AmountQualifierCode = "f",
		};

		var actual = Map.MapObject<JIL_LineItemDetailForTheOperatingExpenseStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hk", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceID = "Y";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "8z";
			subject.ReferenceIdentification = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceIDQualifier = "hk";
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "8z";
			subject.ReferenceIdentification = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8z", "8", true)]
	[InlineData("8z", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceIDQualifier = "hk";
		subject.ProductServiceID = "Y";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("f", 4, true)]
	[InlineData("f", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceIDQualifier = "hk";
		subject.ProductServiceID = "Y";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "8z";
			subject.ReferenceIdentification = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
