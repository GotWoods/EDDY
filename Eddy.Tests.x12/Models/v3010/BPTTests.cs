using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPT*cB*Z*r4Dbda*qZ*uN2*5";

		var expected = new BPT_BeginningSegmentForProductTransferAndResale()
		{
			TransactionSetPurposeCode = "cB",
			ReferenceNumber = "Z",
			Date = "r4Dbda",
			ReportTypeCode = "qZ",
			PriceMultiplierQualifier = "uN2",
			Multiplier = 5,
		};

		var actual = Map.MapObject<BPT_BeginningSegmentForProductTransferAndResale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cB", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.ReferenceNumber = "Z";
		subject.Date = "r4Dbda";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "cB";
		subject.Date = "r4Dbda";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r4Dbda", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "cB";
		subject.ReferenceNumber = "Z";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
