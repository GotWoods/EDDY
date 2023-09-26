using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class RMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMR*XR*I*Ho*2*2*1*2j*8";

		var expected = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference()
		{
			ReferenceIdentificationQualifier = "XR",
			ReferenceIdentification = "I",
			PaymentActionCode = "Ho",
			MonetaryAmount = 2,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 1,
			AdjustmentReasonCode = "2j",
			MonetaryAmount4 = 8,
		};

		var actual = Map.MapObject<RMR_RemittanceAdviceAccountsReceivableOpenItemReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XR", "I", true)]
	[InlineData("XR", "", false)]
	[InlineData("", "I", false)]
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
			subject.AdjustmentReasonCode = "2j";
			subject.MonetaryAmount4 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2j", 8, true)]
	[InlineData("2j", 0, false)]
	[InlineData("", 8, false)]
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
			subject.ReferenceIdentificationQualifier = "XR";
			subject.ReferenceIdentification = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
