using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PTFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTF*i*4*r**od*mo*T";

		var expected = new PTF_PropertyTransactionFinancials()
		{
			AmountQualifierCode = "i",
			MonetaryAmount = 4,
			FrequencyCode = "r",
			CompositeUnitOfMeasure = null,
			EntityIdentifierCode = "od",
			TaxTypeCode = "mo",
			TaxExemptCode = "T",
		};

		var actual = Map.MapObject<PTF_PropertyTransactionFinancials>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new PTF_PropertyTransactionFinancials();
		subject.MonetaryAmount = 4;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PTF_PropertyTransactionFinancials();
		subject.AmountQualifierCode = "i";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
