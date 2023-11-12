using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class LN2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN2*6*I*7*0*JN*5*Y*I**TM*4*4";

		var expected = new LN2_ExistingRealEstateLoanSpecificData()
		{
			LienPriorityCode = "6",
			RealEstateLoanTypeCode = "I",
			PercentageAsDecimal = 7,
			FrequencyCode = "0",
			LoanPaymentTypeCode = "JN",
			YesNoConditionOrResponseCode = "5",
			AssumptionTermsCode = "Y",
			Name = "I",
			ReferenceIdentifier = null,
			QuantityQualifier = "TM",
			Quantity = 4,
			Quantity2 = 4,
		};

		var actual = Map.MapObject<LN2_ExistingRealEstateLoanSpecificData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredLienPriorityCode(string lienPriorityCode, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.RealEstateLoanTypeCode = "I";
		//Test Parameters
		subject.LienPriorityCode = lienPriorityCode;
		//If one filled, all required
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || !string.IsNullOrEmpty(subject.FrequencyCode))
		{
			subject.PercentageAsDecimal = 7;
			subject.FrequencyCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredRealEstateLoanTypeCode(string realEstateLoanTypeCode, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "6";
		//Test Parameters
		subject.RealEstateLoanTypeCode = realEstateLoanTypeCode;
		//If one filled, all required
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || !string.IsNullOrEmpty(subject.FrequencyCode))
		{
			subject.PercentageAsDecimal = 7;
			subject.FrequencyCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "0", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "0", false)]
	public void Validation_AllAreRequiredPercentageAsDecimal(decimal percentageAsDecimal, string frequencyCode, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "6";
		subject.RealEstateLoanTypeCode = "I";
		//Test Parameters
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "TM", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "TM", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string quantityQualifier, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "6";
		subject.RealEstateLoanTypeCode = "I";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.QuantityQualifier = quantityQualifier;
		//If one filled, all required
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || !string.IsNullOrEmpty(subject.FrequencyCode))
		{
			subject.PercentageAsDecimal = 7;
			subject.FrequencyCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "TM", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "TM", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string quantityQualifier, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		//Required fields
		subject.LienPriorityCode = "6";
		subject.RealEstateLoanTypeCode = "I";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.QuantityQualifier = quantityQualifier;
		//If one filled, all required
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || !string.IsNullOrEmpty(subject.FrequencyCode))
		{
			subject.PercentageAsDecimal = 7;
			subject.FrequencyCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
