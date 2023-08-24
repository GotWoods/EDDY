using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ACTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACT*p*1*w*iw*N*8*r*e*y";

		var expected = new ACT_AccountIdentification()
		{
			AccountNumber = "p",
			Name = "1",
			IdentificationCodeQualifier = "w",
			IdentificationCode = "iw",
			AccountNumberQualifier = "N",
			AccountNumber2 = "8",
			Description = "r",
			PaymentMethodCode = "e",
			BenefitStatusCode = "y",
		};

		var actual = Map.MapObject<ACT_AccountIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("w", "iw", true)]
	[InlineData("", "iw", false)]
	[InlineData("w", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "p";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "8", true)]
	[InlineData("N", "", false)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber2, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "p";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber2 = accountNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "N", true)]
	[InlineData("r", "", false)]
	public void Validation_ARequiresBDescription(string description, string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new ACT_AccountIdentification();
		subject.AccountNumber = "p";
		subject.Description = description;
		subject.AccountNumberQualifier = accountNumberQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
