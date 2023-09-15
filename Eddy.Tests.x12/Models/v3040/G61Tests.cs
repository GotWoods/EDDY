using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class G61Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G61*9b*N*uw*v*z";

		var expected = new G61_Contact()
		{
			ContactFunctionCode = "9b",
			Name = "N",
			CommunicationNumberQualifier = "uw",
			CommunicationNumber = "v",
			ContactInquiryReference = "z",
		};

		var actual = Map.MapObject<G61_Contact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9b", true)]
	public void Validation_RequiredContactFunctionCode(string contactFunctionCode, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.Name = "N";
		subject.ContactFunctionCode = contactFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "uw";
			subject.CommunicationNumber = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "9b";
		subject.Name = name;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "uw";
			subject.CommunicationNumber = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uw", "v", true)]
	[InlineData("uw", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "9b";
		subject.Name = "N";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
