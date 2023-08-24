using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ACTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACT*A*y*I*a4*g*j*X*Y";

		var expected = new ACT_AccountIdentification()
		{
			AccountNumber = "A",
			Name = "y",
			IdentificationCodeQualifier = "I",
			IdentificationCode = "a4",
			AccountNumberQualifier = "g",
			AccountNumber2 = "j",
			FreeFormMessage = "X",
			PaymentMethodCode = "Y",
		};

		var actual = Map.MapObject<ACT_AccountIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("I", "a4", true)]
	[InlineData("", "a4", false)]
	[InlineData("I", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "A";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "j", true)]
	[InlineData("g", "", false)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber2, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "A";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber2 = accountNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "g", true)]
	[InlineData("X", "", false)]
	public void Validation_ARequiresBFreeFormMessage(string freeFormMessage, string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "A";
		subject.FreeFormMessage = freeFormMessage;
		subject.AccountNumberQualifier = accountNumberQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
