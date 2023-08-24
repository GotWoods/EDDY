using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ACTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACT*0*0*d*lJ*g*3*N";

		var expected = new ACT_AccountIdentification()
		{
			AccountNumber = "0",
			Name = "0",
			IdentificationCodeQualifier = "d",
			IdentificationCode = "lJ",
			AccountNumberQualifier = "g",
			AccountNumber2 = "3",
			FreeFormMessage = "N",
		};

		var actual = Map.MapObject<ACT_AccountIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("d", "lJ", true)]
	[InlineData("", "lJ", false)]
	[InlineData("d", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "0";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "3", true)]
	[InlineData("g", "", false)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber2, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "0";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber2 = accountNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "g", true)]
	[InlineData("N", "", false)]
	public void Validation_ARequiresBFreeFormMessage(string freeFormMessage, string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "0";
		subject.FreeFormMessage = freeFormMessage;
		subject.AccountNumberQualifier = accountNumberQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
