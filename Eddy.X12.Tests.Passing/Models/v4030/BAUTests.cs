using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BAUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAU*x*eoj*n5*zq1*N*Q";

		var expected = new BAU_BeginningSegmentForTheDebitAuthorization()
		{
			ReferenceIdentification = "x",
			PaymentMethodCode = "eoj",
			DFIIDNumberQualifier = "n5",
			DFIIdentificationNumber = "zq1",
			AccountNumber = "N",
			Name = "Q",
		};

		var actual = Map.MapObject<BAU_BeginningSegmentForTheDebitAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.PaymentMethodCode = "eoj";
		subject.DFIIDNumberQualifier = "n5";
		subject.DFIIdentificationNumber = "zq1";
		subject.AccountNumber = "N";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eoj", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "x";
		subject.DFIIDNumberQualifier = "n5";
		subject.DFIIdentificationNumber = "zq1";
		subject.AccountNumber = "N";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n5", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "x";
		subject.PaymentMethodCode = "eoj";
		subject.DFIIdentificationNumber = "zq1";
		subject.AccountNumber = "N";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zq1", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "x";
		subject.PaymentMethodCode = "eoj";
		subject.DFIIDNumberQualifier = "n5";
		subject.AccountNumber = "N";
		//Test Parameters
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "x";
		subject.PaymentMethodCode = "eoj";
		subject.DFIIDNumberQualifier = "n5";
		subject.DFIIdentificationNumber = "zq1";
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
