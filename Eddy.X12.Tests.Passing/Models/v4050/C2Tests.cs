using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class C2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C2*t*9*2o*Kg7*bZ2Vj7*b*pd8Lmmzc";

		var expected = new C2_BankID()
		{
			BankClientCode = "t",
			IdentificationCodeQualifier = "9",
			IdentificationCode = "2o",
			ClientBankNumber = "Kg7",
			BankAccountNumber = "bZ2Vj7",
			PaymentMethodTypeCode = "b",
			Date = "pd8Lmmzc",
		};

		var actual = Map.MapObject<C2_BankID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredBankClientCode(string bankClientCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.IdentificationCodeQualifier = "9";
		subject.IdentificationCode = "2o";
		subject.BankClientCode = bankClientCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "t";
		subject.IdentificationCode = "2o";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2o", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new C2_BankID();
		subject.BankClientCode = "t";
		subject.IdentificationCodeQualifier = "9";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
