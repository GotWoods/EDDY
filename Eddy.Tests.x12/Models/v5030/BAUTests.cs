using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BAUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAU*i*MMH*av*Tub*p*c";

		var expected = new BAU_BeginningSegmentForTheDebitAuthorization()
		{
			ReferenceIdentification = "i",
			PaymentMethodCode = "MMH",
			DFIIDNumberQualifier = "av",
			DFIIdentificationNumber = "Tub",
			AccountNumber = "p",
			Name = "c",
		};

		var actual = Map.MapObject<BAU_BeginningSegmentForTheDebitAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.PaymentMethodCode = "MMH";
		subject.DFIIDNumberQualifier = "av";
		subject.DFIIdentificationNumber = "Tub";
		subject.AccountNumber = "p";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MMH", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "i";
		subject.DFIIDNumberQualifier = "av";
		subject.DFIIdentificationNumber = "Tub";
		subject.AccountNumber = "p";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("av", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "i";
		subject.PaymentMethodCode = "MMH";
		subject.DFIIdentificationNumber = "Tub";
		subject.AccountNumber = "p";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tub", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "i";
		subject.PaymentMethodCode = "MMH";
		subject.DFIIDNumberQualifier = "av";
		subject.AccountNumber = "p";
		//Test Parameters
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceIdentification = "i";
		subject.PaymentMethodCode = "MMH";
		subject.DFIIDNumberQualifier = "av";
		subject.DFIIdentificationNumber = "Tub";
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
