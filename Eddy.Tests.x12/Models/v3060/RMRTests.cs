using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMR*96*m*wh*8*7*2*oA*5";

		var expected = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference()
		{
			ReferenceIdentificationQualifier = "96",
			ReferenceIdentification = "m",
			PaymentActionCode = "wh",
			MonetaryAmount = 8,
			MonetaryAmount2 = 7,
			MonetaryAmount3 = 2,
			AdjustmentReasonCode = "oA",
			MonetaryAmount4 = 5,
		};

		var actual = Map.MapObject<RMR_RemittanceAdviceAccountsReceivableOpenItemReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("96", "m", true)]
	[InlineData("96", "", false)]
	[InlineData("", "m", false)]
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
			subject.AdjustmentReasonCode = "oA";
			subject.MonetaryAmount4 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("oA", 5, true)]
	[InlineData("oA", 0, false)]
	[InlineData("", 5, false)]
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
			subject.ReferenceIdentificationQualifier = "96";
			subject.ReferenceIdentification = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
