using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BAUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAU*k*Dae*PL*zaR*L*f";

		var expected = new BAU_BeginningSegmentForTheDebitAuthorization()
		{
			ReferenceIdentification = "k",
			PaymentMethodCode = "Dae",
			DFIIDNumberQualifier = "PL",
			DFIIdentificationNumber = "zaR",
			AccountNumber = "L",
			Name = "f",
		};

		var actual = Map.MapObject<BAU_BeginningSegmentForTheDebitAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.PaymentMethodCode = "Dae";
		subject.DFIIDNumberQualifier = "PL";
		subject.DFIIdentificationNumber = "zaR";
		subject.AccountNumber = "L";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dae", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "k";
		subject.DFIIDNumberQualifier = "PL";
		subject.DFIIdentificationNumber = "zaR";
		subject.AccountNumber = "L";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PL", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "k";
		subject.PaymentMethodCode = "Dae";
		subject.DFIIdentificationNumber = "zaR";
		subject.AccountNumber = "L";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zaR", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "k";
		subject.PaymentMethodCode = "Dae";
		subject.DFIIDNumberQualifier = "PL";
		subject.AccountNumber = "L";
		//Test Parameters
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "k";
		subject.PaymentMethodCode = "Dae";
		subject.DFIIDNumberQualifier = "PL";
		subject.DFIIdentificationNumber = "zaR";
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
