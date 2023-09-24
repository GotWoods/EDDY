using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G61Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G61*5Y*5*6z*N*s";

		var expected = new G61_Contact()
		{
			ContactFunctionCode = "5Y",
			Name = "5",
			CommunicationNumberQualifier = "6z",
			CommunicationNumber = "N",
			ContactInquiryReference = "s",
		};

		var actual = Map.MapObject<G61_Contact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5Y", true)]
	public void Validation_RequiredContactFunctionCode(string contactFunctionCode, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.Name = "5";
		subject.ContactFunctionCode = contactFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "6z";
			subject.CommunicationNumber = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "5Y";
		subject.Name = name;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "6z";
			subject.CommunicationNumber = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6z", "N", true)]
	[InlineData("6z", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "5Y";
		subject.Name = "5";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
