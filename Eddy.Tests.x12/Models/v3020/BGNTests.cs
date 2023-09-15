using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BGNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGN*SZ*G*kw933X*HcML*CK";

		var expected = new BGN_BeginningSegment()
		{
			TransactionSetPurposeCode = "SZ",
			ReferenceNumber = "G",
			Date = "kw933X",
			Time = "HcML",
			TimeCode = "CK",
		};

		var actual = Map.MapObject<BGN_BeginningSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SZ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.ReferenceNumber = "G";
		subject.Date = "kw933X";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "SZ";
		subject.Date = "kw933X";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kw933X", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "SZ";
		subject.ReferenceNumber = "G";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CK", "HcML", true)]
	[InlineData("CK", "", false)]
	[InlineData("", "HcML", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new BGN_BeginningSegment();
		subject.TransactionSetPurposeCode = "SZ";
		subject.ReferenceNumber = "G";
		subject.Date = "kw933X";
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
