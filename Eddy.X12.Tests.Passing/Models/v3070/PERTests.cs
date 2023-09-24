using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PER*6w*H*98*a*zs*M*P8*0*n";

		var expected = new PER_AdministrativeCommunicationsContact()
		{
			ContactFunctionCode = "6w",
			Name = "H",
			CommunicationNumberQualifier = "98",
			CommunicationNumber = "a",
			CommunicationNumberQualifier2 = "zs",
			CommunicationNumber2 = "M",
			CommunicationNumberQualifier3 = "P8",
			CommunicationNumber3 = "0",
			ContactInquiryReference = "n",
		};

		var actual = Map.MapObject<PER_AdministrativeCommunicationsContact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6w", true)]
	public void Validation_RequiredContactFunctionCode(string contactFunctionCode, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = contactFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "98";
			subject.CommunicationNumber = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "zs";
			subject.CommunicationNumber2 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "P8";
			subject.CommunicationNumber3 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("98", "a", true)]
	[InlineData("98", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "6w";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "zs";
			subject.CommunicationNumber2 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "P8";
			subject.CommunicationNumber3 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zs", "M", true)]
	[InlineData("zs", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier2(string communicationNumberQualifier2, string communicationNumber2, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "6w";
		subject.CommunicationNumberQualifier2 = communicationNumberQualifier2;
		subject.CommunicationNumber2 = communicationNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "98";
			subject.CommunicationNumber = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier3) || !string.IsNullOrEmpty(subject.CommunicationNumber3))
		{
			subject.CommunicationNumberQualifier3 = "P8";
			subject.CommunicationNumber3 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P8", "0", true)]
	[InlineData("P8", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier3(string communicationNumberQualifier3, string communicationNumber3, bool isValidExpected)
	{
		var subject = new PER_AdministrativeCommunicationsContact();
		subject.ContactFunctionCode = "6w";
		subject.CommunicationNumberQualifier3 = communicationNumberQualifier3;
		subject.CommunicationNumber3 = communicationNumber3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "98";
			subject.CommunicationNumber = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier2) || !string.IsNullOrEmpty(subject.CommunicationNumber2))
		{
			subject.CommunicationNumberQualifier2 = "zs";
			subject.CommunicationNumber2 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
