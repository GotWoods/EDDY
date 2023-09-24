using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class PERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PER*mD*v*Gn*c*vV*5*0m*G*v";

		var expected = new PER_AdministrativeCommunicationsContact()
		{
			ContactFunctionCode = "mD",
			Name = "v",
			CommunicationNumberQualifier = "Gn",
			CommunicationNumber = "c",
			CommunicationNumberQualifier2 = "vV",
			CommunicationNumber2 = "5",
			CommunicationNumberQualifier3 = "0m",
			CommunicationNumber3 = "G",
			ContactInquiryReference = "v",
		};

		var actual = Map.MapObject<PER_AdministrativeCommunicationsContact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mD", true)]
	public void Validation_RequiredContactFunctionCode(string contactFunctionCode, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = contactFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "Gn";
			subject.CommunicationNumber = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "vV";
			subject.CommunicationNumber2 = "5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "0m";
			subject.CommunicationNumber3 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Gn", "c", true)]
	[InlineData("Gn", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "mD";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "vV";
			subject.CommunicationNumber2 = "5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "0m";
			subject.CommunicationNumber3 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vV", "5", true)]
	[InlineData("vV", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier2(string communicationNumberQualifier2, string communicationNumber2, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "mD";
		subject.CommunicationNumberQualifier2 = communicationNumberQualifier2;
		subject.CommunicationNumber2 = communicationNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "Gn";
			subject.CommunicationNumber = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "0m";
			subject.CommunicationNumber3 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0m", "G", true)]
	[InlineData("0m", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier3(string communicationNumberQualifier3, string communicationNumber3, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "mD";
		subject.CommunicationNumberQualifier3 = communicationNumberQualifier3;
		subject.CommunicationNumber3 = communicationNumber3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "Gn";
			subject.CommunicationNumber = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "vV";
			subject.CommunicationNumber2 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
