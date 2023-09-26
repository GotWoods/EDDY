using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BTATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTA*eJ*LAU13h7E*D*8";

		var expected = new BTA_BeginningTaxAcknowledgment()
		{
			AcknowledgmentTypeCode = "eJ",
			Date = "LAU13h7E",
			AmountQualifierCode = "D",
			MonetaryAmount = 8,
		};

		var actual = Map.MapObject<BTA_BeginningTaxAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eJ", true)]
	public void Validation_RequiredAcknowledgmentTypeCode(string acknowledgmentTypeCode, bool isValidExpected)
	{
		var subject = new BTA_BeginningTaxAcknowledgment();
		//Required fields
		//Test Parameters
		subject.AcknowledgmentTypeCode = acknowledgmentTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 8, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BTA_BeginningTaxAcknowledgment();
		//Required fields
		subject.AcknowledgmentTypeCode = "eJ";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
