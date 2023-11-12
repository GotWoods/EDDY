using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ENETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENE*xf*cK*t*K*QF";

		var expected = new ENE_ElectronicSystemsEnvironment()
		{
			CommunicationsEnvironmentCode = "xf",
			CommunicationNumberQualifier = "cK",
			CommunicationNumber = "t",
			IdentificationCodeQualifier = "K",
			IdentificationCode = "QF",
		};

		var actual = Map.MapObject<ENE_ElectronicSystemsEnvironment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xf", true)]
	public void Validation_RequiredCommunicationsEnvironmentCode(string communicationsEnvironmentCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationNumberQualifier = "cK";
		subject.CommunicationNumber = "t";
		//Test Parameters
		subject.CommunicationsEnvironmentCode = communicationsEnvironmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cK", true)]
	public void Validation_RequiredCommunicationNumberQualifier(string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "xf";
		subject.CommunicationNumber = "t";
		//Test Parameters
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "QF", true)]
	[InlineData("K", "", false)]
	[InlineData("", "QF", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "xf";
		subject.CommunicationNumber = "t";
        subject.CommunicationNumberQualifier = "AB";
        //Test Parameters
        subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new ENE_ElectronicSystemsEnvironment();
		//Required fields
		subject.CommunicationsEnvironmentCode = "xf";
		subject.CommunicationNumberQualifier = "cK";
		//Test Parameters
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
