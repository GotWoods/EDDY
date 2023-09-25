using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BAUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAU*r*zOQ*LF*PIm*n*C";

		var expected = new BAU_BeginningSegmentForTheDebitAuthorization()
		{
			ReferenceNumber = "r",
			PaymentMethodCode = "zOQ",
			DFIIDNumberQualifier = "LF",
			DFIIdentificationNumber = "PIm",
			AccountNumber = "n",
			Name = "C",
		};

		var actual = Map.MapObject<BAU_BeginningSegmentForTheDebitAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.PaymentMethodCode = "zOQ";
		subject.DFIIDNumberQualifier = "LF";
		subject.DFIIdentificationNumber = "PIm";
		subject.AccountNumber = "n";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zOQ", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceNumber = "r";
		subject.DFIIDNumberQualifier = "LF";
		subject.DFIIdentificationNumber = "PIm";
		subject.AccountNumber = "n";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LF", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceNumber = "r";
		subject.PaymentMethodCode = "zOQ";
		subject.DFIIdentificationNumber = "PIm";
		subject.AccountNumber = "n";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PIm", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceNumber = "r";
		subject.PaymentMethodCode = "zOQ";
		subject.DFIIDNumberQualifier = "LF";
		subject.AccountNumber = "n";
		//Test Parameters
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceNumber = "r";
		subject.PaymentMethodCode = "zOQ";
		subject.DFIIDNumberQualifier = "LF";
		subject.DFIIdentificationNumber = "PIm";
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
