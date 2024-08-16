using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S305Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "p:F:I:M";

		var expected = new S305_DialogueIdentification()
		{
			DialogueIdentification = "p",
			DialogueVersionNumber = "F",
			DialogueReleaseNumber = "I",
			ControllingAgencyCoded = "M",
		};

		var actual = Map.MapComposite<S305_DialogueIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredDialogueIdentification(string dialogueIdentification, bool isValidExpected)
	{
		var subject = new S305_DialogueIdentification();
		//Required fields
		//Test Parameters
		subject.DialogueIdentification = dialogueIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
