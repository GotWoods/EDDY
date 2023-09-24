using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PER*Lh*R*gZ*7*jD*A*dI*r*Q";

		var expected = new PER_AdministrativeCommunicationsContact()
		{
			ContactFunctionCode = "Lh",
			Name = "R",
			CommunicationNumberQualifier = "gZ",
			CommunicationNumber = "7",
			CommunicationNumberQualifier2 = "jD",
			CommunicationNumber2 = "A",
			CommunicationNumberQualifier3 = "dI",
			CommunicationNumber3 = "r",
			ContactInquiryReference = "Q",
		};

		var actual = Map.MapObject<PER_AdministrativeCommunicationsContact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lh", true)]
	public void Validation_RequiredContactFunctionCode(string contactFunctionCode, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = contactFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "gZ";
			subject.CommunicationNumber = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "jD";
			subject.CommunicationNumber2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "dI";
			subject.CommunicationNumber3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gZ", "7", true)]
	[InlineData("gZ", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "Lh";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "jD";
			subject.CommunicationNumber2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "dI";
			subject.CommunicationNumber3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jD", "A", true)]
	[InlineData("jD", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier2(string communicationNumberQualifier2, string communicationNumber2, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "Lh";
		subject.CommunicationNumberQualifier2 = communicationNumberQualifier2;
		subject.CommunicationNumber2 = communicationNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "gZ";
			subject.CommunicationNumber = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "dI";
			subject.CommunicationNumber3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dI", "r", true)]
	[InlineData("dI", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier3(string communicationNumberQualifier3, string communicationNumber3, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "Lh";
		subject.CommunicationNumberQualifier3 = communicationNumberQualifier3;
		subject.CommunicationNumber3 = communicationNumber3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "gZ";
			subject.CommunicationNumber = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "jD";
			subject.CommunicationNumber2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
