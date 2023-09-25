using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class PASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAS*7*5*3*9*8*u*z*gt*wveMhm28*U";

		var expected = new PAS_PropertyAppraisalSummary()
		{
			PropertyValueEstimateTypeCode = "7",
			AmountQualifierCode = "5",
			MonetaryAmount = 3,
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 8,
			ImprovementStatusCode = "u",
			YesNoConditionOrResponseCode = "z",
			ConditionIndicator = "gt",
			Date = "wveMhm28",
			YesNoConditionOrResponseCode2 = "U",
		};

		var actual = Map.MapObject<PAS_PropertyAppraisalSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredPropertyValueEstimateTypeCode(string propertyValueEstimateTypeCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.AmountQualifierCode = "5";
		subject.MonetaryAmount = 3;
		//Test Parameters
		subject.PropertyValueEstimateTypeCode = propertyValueEstimateTypeCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 9;
			subject.MonetaryAmount3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "7";
		subject.MonetaryAmount = 3;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 9;
			subject.MonetaryAmount3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "7";
		subject.AmountQualifierCode = "5";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 9;
			subject.MonetaryAmount3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(9, 8, true)]
	[InlineData(9, 0, false)]
	[InlineData(0, 8, false)]
	public void Validation_AllAreRequiredMonetaryAmount2(decimal monetaryAmount2, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "7";
		subject.AmountQualifierCode = "5";
		subject.MonetaryAmount = 3;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
