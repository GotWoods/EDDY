using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class C2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C2*G*e*NA*idQ*g3lian*7*kRxGusr0";

		var expected = new C2_BankID()
		{
			BankClientCode = "G",
			IdentificationCodeQualifier = "e",
			IdentificationCode = "NA",
			ClientBankNumber = "idQ",
			BankAccountNumber = "g3lian",
			PaymentMethodCode = "7",
			Date = "kRxGusr0",
		};

		var actual = Map.MapObject<C2_BankID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredBankClientCode(string bankClientCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.IdentificationCodeQualifier = "e";
		subject.IdentificationCode = "NA";
		subject.BankClientCode = bankClientCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "G";
		subject.IdentificationCode = "NA";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NA", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "G";
		subject.IdentificationCodeQualifier = "e";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
