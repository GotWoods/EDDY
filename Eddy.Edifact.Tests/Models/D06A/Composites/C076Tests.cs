using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class C076Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:D";

		var expected = new C076_CommunicationContact()
		{
			CommunicationAddressIdentifier = "b",
			CommunicationMeansTypeCode = "D",
		};

		var actual = Map.MapComposite<C076_CommunicationContact>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredCommunicationAddressIdentifier(string communicationAddressIdentifier, bool isValidExpected)
	{
		var subject = new C076_CommunicationContact();
		//Required fields
		subject.CommunicationMeansTypeCode = "D";
		//Test Parameters
		subject.CommunicationAddressIdentifier = communicationAddressIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredCommunicationMeansTypeCode(string communicationMeansTypeCode, bool isValidExpected)
	{
		var subject = new C076_CommunicationContact();
		//Required fields
		subject.CommunicationAddressIdentifier = "b";
		//Test Parameters
		subject.CommunicationMeansTypeCode = communicationMeansTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
