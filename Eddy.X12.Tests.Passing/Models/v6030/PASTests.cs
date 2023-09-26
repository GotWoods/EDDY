using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class PASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAS*I*B*2*7*8*x*a*Us*1UGmhyu1*9";

		var expected = new PAS_PropertyAppraisalSummary()
		{
			PropertyValueEstimateTypeCode = "I",
			AmountQualifierCode = "B",
			MonetaryAmount = 2,
			MonetaryAmount2 = 7,
			MonetaryAmount3 = 8,
			ImprovementStatusCode = "x",
			YesNoConditionOrResponseCode = "a",
			ConditionIndicatorCode = "Us",
			Date = "1UGmhyu1",
			YesNoConditionOrResponseCode2 = "9",
		};

		var actual = Map.MapObject<PAS_PropertyAppraisalSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredPropertyValueEstimateTypeCode(string propertyValueEstimateTypeCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.AmountQualifierCode = "B";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.PropertyValueEstimateTypeCode = propertyValueEstimateTypeCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 7;
			subject.MonetaryAmount3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "I";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 7;
			subject.MonetaryAmount3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "I";
		subject.AmountQualifierCode = "B";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 7;
			subject.MonetaryAmount3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(7, 8, true)]
	[InlineData(7, 0, false)]
	[InlineData(0, 8, false)]
	public void Validation_AllAreRequiredMonetaryAmount2(decimal monetaryAmount2, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "I";
		subject.AmountQualifierCode = "B";
		subject.MonetaryAmount = 2;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
