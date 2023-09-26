using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ENETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENE*8s*GJ*T4QAyJP*6*qw";

		var expected = new ENE_ElectronicSystemsEnvironment()
		{
			CommunicationsEnvironmentCode = "8s",
			CommunicationNumberQualifier = "GJ",
			CommunicationNumber = "T4QAyJP",
			IdentificationCodeQualifier = "6",
			IdentificationCode = "qw",
		};

		var actual = Map.MapObject<ENE_ElectronicSystemsEnvironment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8s", true)]
	public void Validation_RequiredCommunicationsEnvironmentCode(string communicationsEnvironmentCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationNumberQualifier = "GJ";
		subject.CommunicationNumber = "T4QAyJP";
		//Test Parameters
		subject.CommunicationsEnvironmentCode = communicationsEnvironmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GJ", true)]
	public void Validation_RequiredCommunicationNumberQualifier(string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "8s";
		subject.CommunicationNumber = "T4QAyJP";
		//Test Parameters
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "qw", true)]
	[InlineData("6", "", false)]
	[InlineData("", "qw", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "8s";
		subject.CommunicationNumber = "T4QAyJP";
        subject.CommunicationNumberQualifier = "AB";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T4QAyJP", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "8s";
		subject.CommunicationNumberQualifier = "GJ";
		//Test Parameters
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
