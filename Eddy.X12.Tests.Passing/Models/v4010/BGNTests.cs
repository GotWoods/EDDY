using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BGNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGN*sz*u*QC4sBlWV*87Yw*P5*U*uh*j*dC";

		var expected = new BGN_BeginningSegment()
		{
			TransactionSetPurposeCode = "sz",
			ReferenceIdentification = "u",
			Date = "QC4sBlWV",
			Time = "87Yw",
			TimeCode = "P5",
			ReferenceIdentification2 = "U",
			TransactionTypeCode = "uh",
			ActionCode = "j",
			SecurityLevelCode = "dC",
		};

		var actual = Map.MapObject<BGN_BeginningSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sz", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.ReferenceIdentification = "u";
		subject.Date = "QC4sBlWV";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "sz";
		subject.Date = "QC4sBlWV";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QC4sBlWV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "sz";
		subject.ReferenceIdentification = "u";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P5", "87Yw", true)]
	[InlineData("P5", "", false)]
	[InlineData("", "87Yw", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "sz";
		subject.ReferenceIdentification = "u";
		subject.Date = "QC4sBlWV";
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
