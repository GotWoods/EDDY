using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class C2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C2*I*c*RC*548*262567*E*gnTXAL";

		var expected = new C2_BankID()
		{
			BankClientCode = "I",
			IdentificationCodeQualifier = "c",
			IdentificationCode = "RC",
			ClientBankNumber = 548,
			BankAccountNumber = 262567,
			PaymentMethodCode = "E",
			EffectivePaymentDate = "gnTXAL",
		};

		var actual = Map.MapObject<C2_BankID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredBankClientCode(string bankClientCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.IdentificationCodeQualifier = "c";
		subject.IdentificationCode = "RC";
		subject.BankClientCode = bankClientCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "I";
		subject.IdentificationCode = "RC";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RC", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "I";
		subject.IdentificationCodeQualifier = "c";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
