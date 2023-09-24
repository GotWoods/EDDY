using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRA*G*yaqr4YPB*fw*1*WfGw*RW*W";

		var expected = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate()
		{
			ReferenceIdentification = "G",
			Date = "yaqr4YPB",
			TransactionSetPurposeCode = "fw",
			ReceivingAdviceOrAcceptanceCertificateTypeCode = "1",
			Time = "WfGw",
			ReceivingConditionCode = "RW",
			ActionCode = "W",
		};

		var actual = Map.MapObject<BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.Date = "yaqr4YPB";
		subject.TransactionSetPurposeCode = "fw";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "1";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yaqr4YPB", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceIdentification = "G";
		subject.TransactionSetPurposeCode = "fw";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "1";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fw", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceIdentification = "G";
		subject.Date = "yaqr4YPB";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "1";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReceivingAdviceOrAcceptanceCertificateTypeCode(string receivingAdviceOrAcceptanceCertificateTypeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceIdentification = "G";
		subject.Date = "yaqr4YPB";
		subject.TransactionSetPurposeCode = "fw";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = receivingAdviceOrAcceptanceCertificateTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
