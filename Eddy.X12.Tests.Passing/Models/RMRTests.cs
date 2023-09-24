using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMR*rH*4*D2*9*3*7*gl*8";

		var expected = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference()
		{
			ReferenceIdentificationQualifier = "rH",
			ReferenceIdentification = "4",
			PaymentActionCode = "D2",
			MonetaryAmount = 9,
			MonetaryAmount2 = 3,
			MonetaryAmount3 = 7,
			AdjustmentReasonCode = "gl",
			MonetaryAmount4 = 8,
		};

		var actual = Map.MapObject<RMR_RemittanceAdviceAccountsReceivableOpenItemReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("rH", "4", true)]
	[InlineData("", "4", false)]
	[InlineData("rH", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("gl", 8, true)]
	[InlineData("", 8, false)]
	[InlineData("gl", 0, false)]
	public void Validation_AllAreRequiredAdjustmentReasonCode(string adjustmentReasonCode, decimal monetaryAmount4, bool isValidExpected)
	{
		var subject = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference();
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		if (monetaryAmount4 > 0)
		subject.MonetaryAmount4 = monetaryAmount4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
