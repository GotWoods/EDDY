using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BAUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAU*2*q2i*8X*yDK*m*wC";

		var expected = new BAU_BeginningSegmentForTheDebitAuthorization()
		{
			ReferenceNumber = "2",
			PaymentMethodCode = "q2i",
			DFIIDNumberQualifier = "8X",
			DFIIdentificationNumber = "yDK",
			AccountNumber = "m",
			Name30CharacterFormat = "wC",
		};

		var actual = Map.MapObject<BAU_BeginningSegmentForTheDebitAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.PaymentMethodCode = "q2i";
		subject.DFIIDNumberQualifier = "8X";
		subject.DFIIdentificationNumber = "yDK";
		subject.AccountNumber = "m";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q2i", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceNumber = "2";
		subject.DFIIDNumberQualifier = "8X";
		subject.DFIIdentificationNumber = "yDK";
		subject.AccountNumber = "m";
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8X", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceNumber = "2";
		subject.PaymentMethodCode = "q2i";
		subject.DFIIdentificationNumber = "yDK";
		subject.AccountNumber = "m";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yDK", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceNumber = "2";
		subject.PaymentMethodCode = "q2i";
		subject.DFIIDNumberQualifier = "8X";
		subject.AccountNumber = "m";
		//Test Parameters
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new BAU_BeginningSegmentForTheDebitAuthorization();
		//Required fields
		subject.ReferenceNumber = "2";
		subject.PaymentMethodCode = "q2i";
		subject.DFIIDNumberQualifier = "8X";
		subject.DFIIdentificationNumber = "yDK";
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
