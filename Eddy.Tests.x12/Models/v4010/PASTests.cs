using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAS*v*f*9*3*2*W*o";

		var expected = new PAS_PropertyAppraisalSummary()
		{
			PropertyValueEstimateTypeCode = "v",
			AmountQualifierCode = "f",
			MonetaryAmount = 9,
			MonetaryAmount2 = 3,
			MonetaryAmount3 = 2,
			ImprovementStatusCode = "W",
			YesNoConditionOrResponseCode = "o",
		};

		var actual = Map.MapObject<PAS_PropertyAppraisalSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredPropertyValueEstimateTypeCode(string propertyValueEstimateTypeCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.AmountQualifierCode = "f";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.PropertyValueEstimateTypeCode = propertyValueEstimateTypeCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 3;
			subject.MonetaryAmount3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "v";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 3;
			subject.MonetaryAmount3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "v";
		subject.AmountQualifierCode = "f";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 3;
			subject.MonetaryAmount3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(3, 2, true)]
	[InlineData(3, 0, false)]
	[InlineData(0, 2, false)]
	public void Validation_AllAreRequiredMonetaryAmount2(decimal monetaryAmount2, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "v";
		subject.AmountQualifierCode = "f";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
