using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class PASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAS*E*J*8*6*7*6*u*mm*seUJARi8*x";

		var expected = new PAS_PropertyAppraisalSummary()
		{
			PropertyValueEstimateTypeCode = "E",
			AmountQualifierCode = "J",
			MonetaryAmount = 8,
			MonetaryAmount2 = 6,
			MonetaryAmount3 = 7,
			ImprovementStatusCode = "6",
			YesNoConditionOrResponseCode = "u",
			ConditionIndicator = "mm",
			Date = "seUJARi8",
			YesNoConditionOrResponseCode2 = "x",
		};

		var actual = Map.MapObject<PAS_PropertyAppraisalSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredPropertyValueEstimateTypeCode(string propertyValueEstimateTypeCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.PropertyValueEstimateTypeCode = propertyValueEstimateTypeCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 6;
			subject.MonetaryAmount3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "E";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 6;
			subject.MonetaryAmount3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "E";
		subject.AmountQualifierCode = "J";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 6;
			subject.MonetaryAmount3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 7, true)]
	[InlineData(6, 0, false)]
	[InlineData(0, 7, false)]
	public void Validation_AllAreRequiredMonetaryAmount2(decimal monetaryAmount2, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "E";
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 8;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
