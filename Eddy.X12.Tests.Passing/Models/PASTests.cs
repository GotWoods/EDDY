using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAS*o*g*6*8*7*Q*B*Zr*dWGx0aoD*a";

		var expected = new PAS_PropertyAppraisalSummary()
		{
			PropertyValueEstimateTypeCode = "o",
			AmountQualifierCode = "g",
			MonetaryAmount = 6,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 7,
			ImprovementStatusCode = "Q",
			YesNoConditionOrResponseCode = "B",
			ConditionIndicatorCode = "Zr",
			Date = "dWGx0aoD",
			YesNoConditionOrResponseCode2 = "a",
		};

		var actual = Map.MapObject<PAS_PropertyAppraisalSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredPropertyValueEstimateTypeCode(string propertyValueEstimateTypeCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		subject.AmountQualifierCode = "g";
		subject.MonetaryAmount = 6;
		subject.PropertyValueEstimateTypeCode = propertyValueEstimateTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		subject.PropertyValueEstimateTypeCode = "o";
		subject.MonetaryAmount = 6;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		subject.PropertyValueEstimateTypeCode = "o";
		subject.AmountQualifierCode = "g";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,0, true)]
	[InlineData(8, 7, true)]
	[InlineData(0, 7, false)]
	[InlineData(8, 0, false)]
	public void Validation_AllAreRequiredMonetaryAmount2(decimal monetaryAmount2, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		subject.PropertyValueEstimateTypeCode = "o";
		subject.AmountQualifierCode = "g";
		subject.MonetaryAmount = 6;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;
		if (monetaryAmount3 > 0)
		subject.MonetaryAmount3 = monetaryAmount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
