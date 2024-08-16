using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E990Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:d:G:z:E:Q:u:i:0";

		var expected = new E990_SequenceNumberDetails()
		{
			SequencePositionIdentifier = "P",
			SequencePositionIdentifier2 = "d",
			SequencePositionIdentifier3 = "G",
			SequencePositionIdentifier4 = "z",
			SequencePositionIdentifier5 = "E",
			SequencePositionIdentifier6 = "Q",
			SequencePositionIdentifier7 = "u",
			SequencePositionIdentifier8 = "i",
			SequencePositionIdentifier9 = "0",
		};

		var actual = Map.MapComposite<E990_SequenceNumberDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredSequencePositionIdentifier(string sequencePositionIdentifier, bool isValidExpected)
	{
		var subject = new E990_SequenceNumberDetails();
		//Required fields
		//Test Parameters
		subject.SequencePositionIdentifier = sequencePositionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
