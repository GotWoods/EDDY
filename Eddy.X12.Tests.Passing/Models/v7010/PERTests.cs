using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.Tests.Models.v7010;

public class PERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PER*eh*2*0P*d*6c*f*cr*C*x";

		var expected = new PER_AdministrativeCommunicationsContact()
		{
			ContactFunctionCode = "eh",
			Name = "2",
			CommunicationNumberQualifier = "0P",
			CommunicationNumber = "d",
			CommunicationNumberQualifier2 = "6c",
			CommunicationNumber2 = "f",
			CommunicationNumberQualifier3 = "cr",
			CommunicationNumber3 = "C",
			ContactInquiryReference = "x",
		};

		var actual = Map.MapObject<PER_AdministrativeCommunicationsContact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eh", true)]
	public void Validation_RequiredContactFunctionCode(string contactFunctionCode, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = contactFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "0P";
			subject.CommunicationNumber = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "6c";
			subject.CommunicationNumber2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "cr";
			subject.CommunicationNumber3 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0P", "d", true)]
	[InlineData("0P", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "eh";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "6c";
			subject.CommunicationNumber2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "cr";
			subject.CommunicationNumber3 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6c", "f", true)]
	[InlineData("6c", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier2(string communicationNumberQualifier2, string communicationNumber2, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "eh";
		subject.CommunicationNumberQualifier2 = communicationNumberQualifier2;
		subject.CommunicationNumber2 = communicationNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "0P";
			subject.CommunicationNumber = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "cr";
			subject.CommunicationNumber3 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cr", "C", true)]
	[InlineData("cr", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier3(string communicationNumberQualifier3, string communicationNumber3, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "eh";
		subject.CommunicationNumberQualifier3 = communicationNumberQualifier3;
		subject.CommunicationNumber3 = communicationNumber3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "0P";
			subject.CommunicationNumber = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "6c";
			subject.CommunicationNumber2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
