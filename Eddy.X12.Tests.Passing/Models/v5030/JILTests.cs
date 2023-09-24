using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class JILTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JIL*IL*Z*4*57*T*NmjeEkbx*O";

		var expected = new JIL_LineItemDetailForTheOperatingExpenseStatement()
		{
			ProductServiceIDQualifier = "IL",
			ProductServiceID = "Z",
			MonetaryAmount = 4,
			ReferenceIdentificationQualifier = "57",
			ReferenceIdentification = "T",
			Date = "NmjeEkbx",
			AmountQualifierCode = "O",
		};

		var actual = Map.MapObject<JIL_LineItemDetailForTheOperatingExpenseStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IL", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceID = "Z";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "57";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceIDQualifier = "IL";
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "57";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("57", "T", true)]
	[InlineData("57", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceIDQualifier = "IL";
		subject.ProductServiceID = "Z";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("O", 4, true)]
	[InlineData("O", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new JIL_LineItemDetailForTheOperatingExpenseStatement();
		subject.ProductServiceIDQualifier = "IL";
		subject.ProductServiceID = "Z";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "57";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
