using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ENETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENE*hb*ev*y*9*Ik";

		var expected = new ENE_ElectronicSystemsEnvironment()
		{
			CommunicationsEnvironmentCode = "hb",
			CommunicationNumberQualifier = "ev",
			CommunicationNumber = "y",
			IdentificationCodeQualifier = "9",
			IdentificationCode = "Ik",
		};

		var actual = Map.MapObject<ENE_ElectronicSystemsEnvironment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hb", true)]
	public void Validation_RequiredCommunicationsEnvironmentCode(string communicationsEnvironmentCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationNumberQualifier = "ev";
		subject.CommunicationNumber = "y";
		//Test Parameters
		subject.CommunicationsEnvironmentCode = communicationsEnvironmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ev", true)]
	public void Validation_RequiredCommunicationNumberQualifier(string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "hb";
		subject.CommunicationNumber = "y";
		//Test Parameters
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "Ik", true)]
	[InlineData("9", "", false)]
	[InlineData("", "Ik", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "hb";
		subject.CommunicationNumber = "y";
        subject.CommunicationNumberQualifier = "AB";
        //Test Parameters
        subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "hb";
		subject.CommunicationNumberQualifier = "ev";
		//Test Parameters
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
