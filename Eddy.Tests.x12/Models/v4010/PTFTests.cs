using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PTFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTF*W*7*P**iw*0d*T";

		var expected = new PTF_PropertyTransactionFinancials()
		{
			AmountQualifierCode = "W",
			MonetaryAmount = 7,
			FrequencyCode = "P",
			CompositeUnitOfMeasure = null,
			EntityIdentifierCode = "iw",
			TaxTypeCode = "0d",
			TaxExemptCode = "T",
		};

		var actual = Map.MapObject<PTF_PropertyTransactionFinancials>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new PTF_PropertyTransactionFinancials();
		//Required fields
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PTF_PropertyTransactionFinancials();
		//Required fields
		subject.AmountQualifierCode = "W";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
