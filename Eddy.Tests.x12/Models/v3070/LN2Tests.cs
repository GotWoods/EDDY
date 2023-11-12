using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LN2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN2*2*W*2*J*0F*e*m*Q**qP*2*6";

		var expected = new LN2_ExistingRealEstateLoanSpecificData()
		{
			LienPriorityCode = "2",
			RealEstateLoanTypeCode = "W",
			Percent = 2,
			FrequencyCode = "J",
			LoanPaymentTypeCode = "0F",
			YesNoConditionOrResponseCode = "e",
			AssumptionTermsCode = "m",
			Name = "Q",
			ReferenceIdentifier = null,
			QuantityQualifier = "qP",
			Quantity = 2,
			Quantity2 = 6,
		};

		var actual = Map.MapObject<LN2_ExistingRealEstateLoanSpecificData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredLienPriorityCode(string lienPriorityCode, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.RealEstateLoanTypeCode = "W";
		//Test Parameters
		subject.LienPriorityCode = lienPriorityCode;
		//If one filled, all required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.FrequencyCode))
		{
			subject.Percent = 2;
			subject.FrequencyCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredRealEstateLoanTypeCode(string realEstateLoanTypeCode, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "2";
		//Test Parameters
		subject.RealEstateLoanTypeCode = realEstateLoanTypeCode;
		//If one filled, all required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.FrequencyCode))
		{
			subject.Percent = 2;
			subject.FrequencyCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "J", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "J", false)]
	public void Validation_AllAreRequiredPercent(decimal percent, string frequencyCode, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "2";
		subject.RealEstateLoanTypeCode = "W";
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "qP", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "qP", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string quantityQualifier, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "2";
		subject.RealEstateLoanTypeCode = "W";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.QuantityQualifier = quantityQualifier;
		//If one filled, all required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.FrequencyCode))
		{
			subject.Percent = 2;
			subject.FrequencyCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "qP", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "qP", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string quantityQualifier, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "2";
		subject.RealEstateLoanTypeCode = "W";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.QuantityQualifier = quantityQualifier;
		//If one filled, all required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.FrequencyCode))
		{
			subject.Percent = 2;
			subject.FrequencyCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
