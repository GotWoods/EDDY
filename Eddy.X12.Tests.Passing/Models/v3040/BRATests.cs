using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRA*M*ZHabWU*3V*j*Uvu3*DC*4";

		var expected = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate()
		{
			ReferenceNumber = "M",
			Date = "ZHabWU",
			TransactionSetPurposeCode = "3V",
			ReceivingAdviceOrAcceptanceCertificateTypeCode = "j",
			Time = "Uvu3",
			ReceivingConditionCode = "DC",
			ActionCode = "4",
		};

		var actual = Map.MapObject<BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.Date = "ZHabWU";
		subject.TransactionSetPurposeCode = "3V";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "j";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZHabWU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceNumber = "M";
		subject.TransactionSetPurposeCode = "3V";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "j";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3V", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceNumber = "M";
		subject.Date = "ZHabWU";
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
		subject.ReferenceNumber = "M";
		subject.Date = "ZHabWU";
		subject.TransactionSetPurposeCode = "3V";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = receivingAdviceOrAcceptanceCertificateTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
