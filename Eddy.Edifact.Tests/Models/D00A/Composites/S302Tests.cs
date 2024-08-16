using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S302Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:I:a:0";

		var expected = new S302_DialogueReference()
		{
			InitiatorControlReference = "H",
			InitiatorReferenceIdentification = "I",
			ControllingAgencyCoded = "a",
			ResponderControlReference = "0",
		};

		var actual = Map.MapComposite<S302_DialogueReference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredInitiatorControlReference(string initiatorControlReference, bool isValidExpected)
	{
		var subject = new S302_DialogueReference();
		//Required fields
		//Test Parameters
		subject.InitiatorControlReference = initiatorControlReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
