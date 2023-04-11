using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRA*f*2RI7MF6R*74*j*3UUj*nj*L";

		var expected = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate()
		{
			ReferenceIdentification = "f",
			Date = "2RI7MF6R",
			TransactionSetPurposeCode = "74",
			ReceivingAdviceOrAcceptanceCertificateTypeCode = "j",
			Time = "3UUj",
			ReceivingConditionCode = "nj",
			ActionCode = "L",
		};

		var actual = Map.MapObject<BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.Date = "2RI7MF6R";
		subject.TransactionSetPurposeCode = "74";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "j";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2RI7MF6R", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceIdentification = "f";
		subject.TransactionSetPurposeCode = "74";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "j";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("74", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceIdentification = "f";
		subject.Date = "2RI7MF6R";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "j";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredReceivingAdviceOrAcceptanceCertificateTypeCode(string receivingAdviceOrAcceptanceCertificateTypeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceIdentification = "f";
		subject.Date = "2RI7MF6R";
		subject.TransactionSetPurposeCode = "74";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = receivingAdviceOrAcceptanceCertificateTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
