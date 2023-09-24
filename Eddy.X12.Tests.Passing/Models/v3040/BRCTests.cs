using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRC*K6*4RLTQT*cB*f*coOo";

		var expected = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "K6",
			Date = "4RLTQT",
			ReferenceNumberQualifier = "cB",
			ReferenceNumber = "f",
			Time = "coOo",
		};

		var actual = Map.MapObject<BRC_BeginningSegmentResponseToProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K6", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment();
		subject.Date = "4RLTQT";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cB";
			subject.ReferenceNumber = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4RLTQT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "K6";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cB";
			subject.ReferenceNumber = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cB", "f", true)]
	[InlineData("cB", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "K6";
		subject.Date = "4RLTQT";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
