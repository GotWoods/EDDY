using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BAUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAU*d*pxP*Im*qvu*l*M";

		var expected = new BAU_BeginningSegmentForTheDebitAuthorization()
		{
			ReferenceIdentification = "d",
			PaymentMethodCode = "pxP",
			DFIIDNumberQualifier = "Im",
			DFIIdentificationNumber = "qvu",
			AccountNumber = "l",
			Name = "M",
		};

		var actual = Map.MapObject<BAU_BeginningSegmentForTheDebitAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		subject.PaymentMethodCode = "pxP";
		subject.DFIIDNumberQualifier = "Im";
		subject.DFIIdentificationNumber = "qvu";
		subject.AccountNumber = "l";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pxP", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		subject.ReferenceIdentification = "d";
		subject.DFIIDNumberQualifier = "Im";
		subject.DFIIdentificationNumber = "qvu";
		subject.AccountNumber = "l";
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Im", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		subject.ReferenceIdentification = "d";
		subject.PaymentMethodCode = "pxP";
		subject.DFIIdentificationNumber = "qvu";
		subject.AccountNumber = "l";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qvu", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		subject.ReferenceIdentification = "d";
		subject.PaymentMethodCode = "pxP";
		subject.DFIIDNumberQualifier = "Im";
		subject.AccountNumber = "l";
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		subject.ReferenceIdentification = "d";
		subject.PaymentMethodCode = "pxP";
		subject.DFIIDNumberQualifier = "Im";
		subject.DFIIdentificationNumber = "qvu";
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
