using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class ACTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACT*r*Y*G*8c*D*G*g*W*X";

		var expected = new ACT_AccountIdentification()
		{
			AccountNumber = "r",
			Name = "Y",
			IdentificationCodeQualifier = "G",
			IdentificationCode = "8c",
			AccountNumberQualifier = "D",
			AccountNumber2 = "G",
			Description = "g",
			PaymentMethodTypeCode = "W",
			BenefitStatusCode = "X",
		};

		var actual = Map.MapObject<ACT_AccountIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "8c", true)]
	[InlineData("G", "", false)]
	[InlineData("", "8c", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "r";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "G", true)]
	[InlineData("D", "", false)]
	[InlineData("", "G", true)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber2, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "r";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber2 = accountNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "D", true)]
	[InlineData("g", "", false)]
	[InlineData("", "D", true)]
	public void Validation_ARequiresBDescription(string description, string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "r";
		subject.Description = description;
		subject.AccountNumberQualifier = accountNumberQualifier;
		if (accountNumberQualifier != "")
			subject.AccountNumber2 = "G";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
