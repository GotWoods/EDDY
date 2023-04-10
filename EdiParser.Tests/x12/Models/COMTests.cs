using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models;

public class COMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COM*h7*u**LE*J";

		var expected = new COM_CommunicationContactInformation()
		{
			CommunicationNumberQualifier = "h7",
			CommunicationNumber = "u",
			CommunicationNumberComponent = new C057_CommunicationNumberComponent() {},
			LanguageCode = "LE",
			AssignedIdentification = "J",
		};

		var actual = Map.MapObject<COM_CommunicationContactInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h7", true)]
	public void Validatation_RequiredCommunicationNumberQualifier(string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new COM_CommunicationContactInformation();
		subject.CommunicationNumber = "u";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validatation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new COM_CommunicationContactInformation();
		subject.CommunicationNumberQualifier = "h7";
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
