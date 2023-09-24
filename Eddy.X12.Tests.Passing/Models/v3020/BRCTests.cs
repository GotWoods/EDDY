using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRC*kv*rUGoJN*RT*x*kWFw";

		var expected = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "kv",
			Date = "rUGoJN",
			ReferenceNumberQualifier = "RT",
			ReferenceNumber = "x",
			Time = "kWFw",
		};

		var actual = Map.MapObject<BRC_BeginningSegmentResponseToProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kv", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment();
		subject.Date = "rUGoJN";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RT";
			subject.ReferenceNumber = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rUGoJN", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "kv";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RT";
			subject.ReferenceNumber = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RT", "x", true)]
	[InlineData("RT", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "kv";
		subject.Date = "rUGoJN";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
