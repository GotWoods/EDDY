using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ENETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENE*BJ*fi*H*k*ky";

		var expected = new ENE_ElectronicSystemsEnvironment()
		{
			CommunicationsEnvironmentCode = "BJ",
			CommunicationNumberQualifier = "fi",
			CommunicationNumber = "H",
			IdentificationCodeQualifier = "k",
			IdentificationCode = "ky",
		};

		var actual = Map.MapObject<ENE_ElectronicSystemsEnvironment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BJ", true)]
	public void Validatation_RequiredCommunicationsEnvironmentCode(string communicationsEnvironmentCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		subject.CommunicationNumberQualifier = "fi";
		subject.CommunicationNumber = "H";
		subject.CommunicationsEnvironmentCode = communicationsEnvironmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fi", true)]
	public void Validatation_RequiredCommunicationNumberQualifier(string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		subject.CommunicationsEnvironmentCode = "BJ";
		subject.CommunicationNumber = "H";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validatation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		subject.CommunicationsEnvironmentCode = "BJ";
		subject.CommunicationNumberQualifier = "fi";
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("k", "ky", true)]
	[InlineData("", "ky", false)]
	[InlineData("k", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		subject.CommunicationsEnvironmentCode = "BJ";
		subject.CommunicationNumberQualifier = "fi";
		subject.CommunicationNumber = "H";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
