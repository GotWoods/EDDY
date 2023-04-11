using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BGNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGN*dD*J*3H87R2zZ*W0Ey*KB*I*fJ*1*Dp";

		var expected = new BGN_BeginningSegment()
		{
			TransactionSetPurposeCode = "dD",
			ReferenceIdentification = "J",
			Date = "3H87R2zZ",
			Time = "W0Ey",
			TimeCode = "KB",
			ReferenceIdentification2 = "I",
			TransactionTypeCode = "fJ",
			ActionCode = "1",
			SecurityLevelCode = "Dp",
		};

		var actual = Map.MapObject<BGN_BeginningSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dD", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.ReferenceIdentification = "J";
		subject.Date = "3H87R2zZ";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "dD";
		subject.Date = "3H87R2zZ";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3H87R2zZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "dD";
		subject.ReferenceIdentification = "J";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "W0Ey", true)]
	[InlineData("KB", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "dD";
		subject.ReferenceIdentification = "J";
		subject.Date = "3H87R2zZ";
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
