using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PER*i3*f*0e*V*G0*Y";

		var expected = new PER_AdministrativeCommunicationsContact()
		{
			ContactFunctionCode = "i3",
			Name = "f",
			CommunicationNumberQualifier = "0e",
			CommunicationNumber = "V",
			CommunicationNumberQualifier2 = "G0",
			CommunicationNumber2 = "Y",
		};

		var actual = Map.MapObject<PER_AdministrativeCommunicationsContact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i3", true)]
	public void Validation_RequiredContactFunctionCode(string contactFunctionCode, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = contactFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "0e";
			subject.CommunicationNumber = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "G0";
			subject.CommunicationNumber2 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0e", "V", true)]
	[InlineData("0e", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "i3";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "G0";
			subject.CommunicationNumber2 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G0", "Y", true)]
	[InlineData("G0", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier2(string communicationNumberQualifier2, string communicationNumber2, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "i3";
		subject.CommunicationNumberQualifier2 = communicationNumberQualifier2;
		subject.CommunicationNumber2 = communicationNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "0e";
			subject.CommunicationNumber = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
