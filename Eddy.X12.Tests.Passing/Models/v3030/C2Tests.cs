using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class C2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C2*2*N*jr*tym*os9Fdg*q*WJGkuz";

		var expected = new C2_BankID()
		{
			BankClientCode = "2",
			IdentificationCodeQualifier = "N",
			IdentificationCode = "jr",
			ClientBankNumber = "tym",
			BankAccountNumber = "os9Fdg",
			PaymentMethodCode = "q",
			Date = "WJGkuz",
		};

		var actual = Map.MapObject<C2_BankID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredBankClientCode(string bankClientCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.IdentificationCodeQualifier = "N";
		subject.IdentificationCode = "jr";
		subject.BankClientCode = bankClientCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "2";
		subject.IdentificationCode = "jr";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jr", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "2";
		subject.IdentificationCodeQualifier = "N";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
