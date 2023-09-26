using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class RMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMR*2w*X*5Z*6*1*6*TC*2";

		var expected = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference()
		{
			ReferenceIdentificationQualifier = "2w",
			ReferenceIdentification = "X",
			PaymentActionCode = "5Z",
			MonetaryAmount = 6,
			MonetaryAmount2 = 1,
			MonetaryAmount3 = 6,
			AdjustmentReasonCode = "TC",
			MonetaryAmount4 = 2,
		};

		var actual = Map.MapObject<RMR_RemittanceAdviceAccountsReceivableOpenItemReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2w", "X", true)]
	[InlineData("2w", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AdjustmentReasonCode) || !string.IsNullOrEmpty(subject.AdjustmentReasonCode) || subject.MonetaryAmount4 > 0)
		{
			subject.AdjustmentReasonCode = "TC";
			subject.MonetaryAmount4 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("TC", 2, true)]
	[InlineData("TC", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredAdjustmentReasonCode(string adjustmentReasonCode, decimal monetaryAmount4, bool isValidExpected)
	{
		var subject = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference();
		//Required fields
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "2w";
			subject.ReferenceIdentification = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
