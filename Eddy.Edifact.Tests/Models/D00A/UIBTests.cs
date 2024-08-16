using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UIBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UIB+++++++++G+G";

		var expected = new UIB_InteractiveInterchangeHeader()
		{
			SyntaxIdentifier = null,
			DialogueReference = null,
			TransactionReference = null,
			ScenarioIdentification = null,
			DialogueIdentification = null,
			InterchangeSender = null,
			InterchangeRecipient = null,
			DateAndOrTimeOfInitiation = null,
			DuplicateIndicator = "G",
			TestIndicator = "G",
		};

		var actual = Map.MapObject<UIB_InteractiveInterchangeHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSyntaxIdentifier(string syntaxIdentifier, bool isValidExpected)
	{
		var subject = new UIB_InteractiveInterchangeHeader();
		//Required fields
		//Test Parameters
		if (syntaxIdentifier != "") 
			subject.SyntaxIdentifier = new S001_SyntaxIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
