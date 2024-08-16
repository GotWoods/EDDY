using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C076Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:a";

		var expected = new C076_CommunicationContact()
		{
			CommunicationAddressIdentifier = "a",
			CommunicationAddressCodeQualifier = "a",
		};

		var actual = Map.MapComposite<C076_CommunicationContact>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredCommunicationAddressIdentifier(string communicationAddressIdentifier, bool isValidExpected)
	{
		var subject = new C076_CommunicationContact();
		//Required fields
		subject.CommunicationAddressCodeQualifier = "a";
		//Test Parameters
		subject.CommunicationAddressIdentifier = communicationAddressIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredCommunicationAddressCodeQualifier(string communicationAddressCodeQualifier, bool isValidExpected)
	{
		var subject = new C076_CommunicationContact();
		//Required fields
		subject.CommunicationAddressIdentifier = "a";
		//Test Parameters
		subject.CommunicationAddressCodeQualifier = communicationAddressCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
