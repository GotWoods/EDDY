using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAS*5*H*2*8*1*h*N";

		var expected = new PAS_PropertyAppraisalSummary()
		{
			PropertyValueEstimateTypeCode = "5",
			AmountQualifierCode = "H",
			MonetaryAmount = 2,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 1,
			ImprovementStatusCode = "h",
			YesNoConditionOrResponseCode = "N",
		};

		var actual = Map.MapObject<PAS_PropertyAppraisalSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredPropertyValueEstimateTypeCode(string propertyValueEstimateTypeCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.AmountQualifierCode = "H";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.PropertyValueEstimateTypeCode = propertyValueEstimateTypeCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 8;
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "5";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 8;
			subject.MonetaryAmount3 = 1;
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
		subject.PropertyValueEstimateTypeCode = "5";
		subject.AmountQualifierCode = "H";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.MonetaryAmount2 > 0 || subject.MonetaryAmount2 > 0 || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount2 = 8;
			subject.MonetaryAmount3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 1, true)]
	[InlineData(8, 0, false)]
	[InlineData(0, 1, false)]
	public void Validation_AllAreRequiredMonetaryAmount2(decimal monetaryAmount2, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new PAS_PropertyAppraisalSummary();
		//Required fields
		subject.PropertyValueEstimateTypeCode = "5";
		subject.AmountQualifierCode = "H";
		subject.MonetaryAmount = 2;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
