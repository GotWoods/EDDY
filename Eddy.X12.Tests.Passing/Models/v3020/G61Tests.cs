using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G61Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G61*8D*n*Fl*YtjOaIk*n";

		var expected = new G61_Contact()
		{
			ContactFunctionCode = "8D",
			Name = "n",
			CommunicationNumberQualifier = "Fl",
			CommunicationNumber = "YtjOaIk",
			ContactInquiryReference = "n",
		};

		var actual = Map.MapObject<G61_Contact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8D", true)]
	public void Validation_RequiredContactFunctionCode(string contactFunctionCode, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.Name = "n";
		subject.CommunicationNumberQualifier = "Fl";
		subject.CommunicationNumber = "YtjOaIk";
		subject.ContactFunctionCode = contactFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "8D";
		subject.CommunicationNumberQualifier = "Fl";
		subject.CommunicationNumber = "YtjOaIk";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fl", true)]
	public void Validation_RequiredCommunicationNumberQualifier(string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "8D";
		subject.Name = "n";
		subject.CommunicationNumber = "YtjOaIk";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YtjOaIk", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new G61_Contact();
		subject.ContactFunctionCode = "8D";
		subject.Name = "n";
		subject.CommunicationNumberQualifier = "Fl";
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
