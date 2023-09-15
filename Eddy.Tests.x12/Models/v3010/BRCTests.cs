using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRC*DH*yFAUX2*8S*l*nkSS";

		var expected = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "DH",
			Date = "yFAUX2",
			ReferenceNumberQualifier = "8S",
			ReferenceNumber = "l",
			Time = "nkSS",
		};

		var actual = Map.MapObject<BRC_BeginningSegmentResponseToProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DH", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment();
		subject.Date = "yFAUX2";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yFAUX2", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentResponseToProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "DH";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
