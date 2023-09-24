using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G61Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G61*MV*U*aW*tAj49BU*U";

		var expected = new G61_Contact()
		{
			ContactFunctionCode = "MV",
			Name = "U",
			CommunicationNumberQualifier = "aW",
			CommunicationNumber = "tAj49BU",
			ContactInquiryReference = "U",
		};

		var actual = Map.MapObject<G61_Contact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MV", true)]
	public void Validation_RequiredContactFunctionCode(string contactFunctionCode, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.Name = "U";
		subject.CommunicationNumberQualifier = "aW";
		subject.CommunicationNumber = "tAj49BU";
		subject.ContactFunctionCode = contactFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "MV";
		subject.CommunicationNumberQualifier = "aW";
		subject.CommunicationNumber = "tAj49BU";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aW", true)]
	public void Validation_RequiredCommunicationNumberQualifier(string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "MV";
		subject.Name = "U";
		subject.CommunicationNumber = "tAj49BU";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tAj49BU", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "MV";
		subject.Name = "U";
		subject.CommunicationNumberQualifier = "aW";
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
