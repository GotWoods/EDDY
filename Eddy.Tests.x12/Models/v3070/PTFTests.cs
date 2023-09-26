using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PTFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTF*m*6*g**h5*DK*t";

		var expected = new PTF_PropertyTransactionFinancials()
		{
			AmountQualifierCode = "m",
			MonetaryAmount = 6,
			FrequencyCode = "g",
			CompositeUnitOfMeasure = null,
			EntityIdentifierCode = "h5",
			TaxTypeCode = "DK",
			TaxExemptCode = "t",
		};

		var actual = Map.MapObject<PTF_PropertyTransactionFinancials>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new PTF_PropertyTransactionFinancials();
		//Required fields
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PTF_PropertyTransactionFinancials();
		//Required fields
		subject.AmountQualifierCode = "m";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
