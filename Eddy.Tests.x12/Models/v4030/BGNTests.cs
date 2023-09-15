using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BGNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGN*10*6*CIPZdC8r*i3ch*ry*s*5Q*i*qF";

		var expected = new BGN_BeginningSegment()
		{
			TransactionSetPurposeCode = "10",
			ReferenceIdentification = "6",
			Date = "CIPZdC8r",
			Time = "i3ch",
			TimeCode = "ry",
			ReferenceIdentification2 = "s",
			TransactionTypeCode = "5Q",
			ActionCode = "i",
			SecurityLevelCode = "qF",
		};

		var actual = Map.MapObject<BGN_BeginningSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("10", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.ReferenceIdentification = "6";
		subject.Date = "CIPZdC8r";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "10";
		subject.Date = "CIPZdC8r";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CIPZdC8r", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "10";
		subject.ReferenceIdentification = "6";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ry", "i3ch", true)]
	[InlineData("ry", "", false)]
	[InlineData("", "i3ch", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "10";
		subject.ReferenceIdentification = "6";
		subject.Date = "CIPZdC8r";
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
