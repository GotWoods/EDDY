using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LN2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LN2*j*N*3*e*qJ*g*e*4**Gc*4*3";

		var expected = new LN2_ExistingRealEstateLoanSpecificData()
		{
			LienPriorityCode = "j",
			RealEstateLoanTypeCode = "N",
			PercentageAsDecimal = 3,
			FrequencyCode = "e",
			LoanPaymentTypeCode = "qJ",
			YesNoConditionOrResponseCode = "g",
			AssumptionTermsCode = "e",
			Name = "4",
			ReferenceIdentifier = null,
			QuantityQualifier = "Gc",
			Quantity = 4,
			Quantity2 = 3,
		};

		var actual = Map.MapObject<LN2_ExistingRealEstateLoanSpecificData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredLienPriorityCode(string lienPriorityCode, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		subject.RealEstateLoanTypeCode = "N";
		subject.LienPriorityCode = lienPriorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredRealEstateLoanTypeCode(string realEstateLoanTypeCode, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		subject.LienPriorityCode = "j";
		subject.RealEstateLoanTypeCode = realEstateLoanTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "e", true)]
	[InlineData(0, "e", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredPercentageAsDecimal(decimal percentageAsDecimal, string frequencyCode, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		subject.LienPriorityCode = "j";
		subject.RealEstateLoanTypeCode = "N";
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;
		subject.FrequencyCode = frequencyCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Gc", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string quantityQualifier, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		subject.LienPriorityCode = "j";
		subject.RealEstateLoanTypeCode = "N";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.QuantityQualifier = quantityQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Gc", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string quantityQualifier, bool isValidExpected)
	{
		var subject = new LN2_ExistingRealEstateLoanSpecificData();
		subject.LienPriorityCode = "j";
		subject.RealEstateLoanTypeCode = "N";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.QuantityQualifier = quantityQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
