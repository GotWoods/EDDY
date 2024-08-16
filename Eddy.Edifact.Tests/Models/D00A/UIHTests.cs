using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UIHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UIH++E++++c";

		var expected = new UIH_InteractiveMessageHeader()
		{
			InteractiveMessageIdentifier = null,
			InteractiveMessageReferenceNumber = "E",
			DialogueReference = null,
			StatusOfTransferInteractive = null,
			DateAndOrTimeOfInitiation = null,
			TestIndicator = "c",
		};

		var actual = Map.MapObject<UIH_InteractiveMessageHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInteractiveMessageIdentifier(string interactiveMessageIdentifier, bool isValidExpected)
	{
		var subject = new UIH_InteractiveMessageHeader();
		//Required fields
		//Test Parameters
		if (interactiveMessageIdentifier != "") 
			subject.InteractiveMessageIdentifier = new S306_InteractiveMessageIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
