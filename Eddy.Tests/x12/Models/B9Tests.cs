using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class B9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B9*w*8z*eA";

		var expected = new B9_BeginningSegmentForLogisticsServices()
		{
			ReferenceIdentification = "w",
			TransactionSetPurposeCode = "8z",
			ShipmentMethodOfPaymentCode = "eA",
		};

		var actual = Map.MapObject<B9_BeginningSegmentForLogisticsServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForLogisticsServices();
		subject.TransactionSetPurposeCode = "8z";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8z", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForLogisticsServices();
		subject.ReferenceIdentification = "w";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
