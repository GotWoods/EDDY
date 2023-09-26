using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class ENETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENE*9t*Sr*j*A*Ox";

		var expected = new ENE_ElectronicSystemsEnvironment()
		{
			CommunicationsEnvironmentCode = "9t",
			CommunicationNumberQualifier = "Sr",
			CommunicationNumber = "j",
			IdentificationCodeQualifier = "A",
			IdentificationCode = "Ox",
		};

		var actual = Map.MapObject<ENE_ElectronicSystemsEnvironment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9t", true)]
	public void Validation_RequiredCommunicationsEnvironmentCode(string communicationsEnvironmentCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationNumberQualifier = "Sr";
		subject.CommunicationNumber = "j";
		//Test Parameters
		subject.CommunicationsEnvironmentCode = communicationsEnvironmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sr", true)]
	public void Validation_RequiredCommunicationNumberQualifier(string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "9t";
		subject.CommunicationNumber = "j";
		//Test Parameters
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "Ox", true)]
	[InlineData("A", "", false)]
	[InlineData("", "Ox", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "9t";
		subject.CommunicationNumber = "j";
        subject.CommunicationNumberQualifier = "AB";
        //Test Parameters
        subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "9t";
		subject.CommunicationNumberQualifier = "Sr";
		//Test Parameters
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
