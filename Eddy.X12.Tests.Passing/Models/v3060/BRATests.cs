using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRA*v*ACEgZ3*Kh*l*j8j9*P5*Q";

		var expected = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate()
		{
			ReferenceIdentification = "v",
			Date = "ACEgZ3",
			TransactionSetPurposeCode = "Kh",
			ReceivingAdviceOrAcceptanceCertificateTypeCode = "l",
			Time = "j8j9",
			ReceivingConditionCode = "P5",
			ActionCode = "Q",
		};

		var actual = Map.MapObject<BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.Date = "ACEgZ3";
		subject.TransactionSetPurposeCode = "Kh";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "l";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ACEgZ3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceIdentification = "v";
		subject.TransactionSetPurposeCode = "Kh";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "l";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kh", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceIdentification = "v";
		subject.Date = "ACEgZ3";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = "l";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReceivingAdviceOrAcceptanceCertificateTypeCode(string receivingAdviceOrAcceptanceCertificateTypeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate();
		subject.ReferenceIdentification = "v";
		subject.Date = "ACEgZ3";
		subject.TransactionSetPurposeCode = "Kh";
		subject.ReceivingAdviceOrAcceptanceCertificateTypeCode = receivingAdviceOrAcceptanceCertificateTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
