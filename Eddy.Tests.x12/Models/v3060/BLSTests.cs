using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLS*ql*rY*4*V27rOH*vyrN*as";

		var expected = new BLS_BeginningSegmentForAssetSchedule()
		{
			TransactionSetPurposeCode = "ql",
			TransactionTypeCode = "rY",
			ReferenceIdentification = "4",
			Date = "V27rOH",
			Time = "vyrN",
			AcknowledgmentType = "as",
		};

		var actual = Map.MapObject<BLS_BeginningSegmentForAssetSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ql", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionTypeCode = "rY";
		subject.ReferenceIdentification = "4";
		subject.Date = "V27rOH";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rY", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "ql";
		subject.ReferenceIdentification = "4";
		subject.Date = "V27rOH";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "ql";
		subject.TransactionTypeCode = "rY";
		subject.Date = "V27rOH";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V27rOH", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BLS_BeginningSegmentForAssetSchedule();
		//Required fields
		subject.TransactionSetPurposeCode = "ql";
		subject.TransactionTypeCode = "rY";
		subject.ReferenceIdentification = "4";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
