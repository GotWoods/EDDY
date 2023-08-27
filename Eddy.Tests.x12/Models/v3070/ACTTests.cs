using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ACTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACT*O*b*i*2W*c*3*Y*r*4";

		var expected = new ACT_AccountIdentification()
		{
			AccountNumber = "O",
			Name = "b",
			IdentificationCodeQualifier = "i",
			IdentificationCode = "2W",
			AccountNumberQualifier = "c",
			AccountNumber2 = "3",
			Description = "Y",
			PaymentMethodCode = "r",
			BenefitStatusCode = "4",
		};

		var actual = Map.MapObject<ACT_AccountIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "2W", true)]
	[InlineData("i", "", false)]
	[InlineData("", "2W", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "O";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "3", true)]
	[InlineData("c", "", false)]
	[InlineData("", "3", true)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber2, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "O";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber2 = accountNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "c", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "c", true)]
	public void Validation_ARequiresBDescription(string description, string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "O";
		subject.Description = description;
		subject.AccountNumberQualifier = accountNumberQualifier;
		if (accountNumberQualifier != "")
			subject.AccountNumber2 = "3";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
