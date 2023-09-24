using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class C2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C2*p*u*Ly*447*291826*8*2JKcw9";

		var expected = new C2_BankID()
		{
			BankClientCode = "p",
			IdentificationCodeQualifier = "u",
			IdentificationCode = "Ly",
			ClientBankNumber = 447,
			BankAccountNumber = 291826,
			PaymentMethodCode = "8",
			Date = "2JKcw9",
		};

		var actual = Map.MapObject<C2_BankID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredBankClientCode(string bankClientCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.IdentificationCodeQualifier = "u";
		subject.IdentificationCode = "Ly";
		subject.BankClientCode = bankClientCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "p";
		subject.IdentificationCode = "Ly";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ly", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "p";
		subject.IdentificationCodeQualifier = "u";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
