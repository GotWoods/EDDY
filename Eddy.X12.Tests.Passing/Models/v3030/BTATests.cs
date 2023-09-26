using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BTATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTA*wZ*Qh3t1Q*R*7";

		var expected = new BTA_BeginningTaxAcknowledgment()
		{
			AcknowledgmentType = "wZ",
			Date = "Qh3t1Q",
			AmountQualifierCode = "R",
			MonetaryAmount = 7,
		};

		var actual = Map.MapObject<BTA_BeginningTaxAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wZ", true)]
	public void Validation_RequiredAcknowledgmentType(string acknowledgmentType, bool isValidExpected)
	{
		var subject = new BTA_BeginningTaxAcknowledgment();
		//Required fields
		//Test Parameters
		subject.AcknowledgmentType = acknowledgmentType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "R";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("R", 7, true)]
	[InlineData("R", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BTA_BeginningTaxAcknowledgment();
		//Required fields
		subject.AcknowledgmentType = "wZ";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
