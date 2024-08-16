using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C286Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "w:0:Z:d";

		var expected = new C286_SequenceInformation()
		{
			SequencePositionIdentifier = "w",
			SequenceIdentifierSourceCode = "0",
			CodeListIdentificationCode = "Z",
			CodeListResponsibleAgencyCode = "d",
		};

		var actual = Map.MapComposite<C286_SequenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredSequencePositionIdentifier(string sequencePositionIdentifier, bool isValidExpected)
	{
		var subject = new C286_SequenceInformation();
		//Required fields
		//Test Parameters
		subject.SequencePositionIdentifier = sequencePositionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
