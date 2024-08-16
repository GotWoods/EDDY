using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C286Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:1:D:m";

		var expected = new C286_SequenceInformation()
		{
			SequencePositionIdentifier = "r",
			SequenceIdentifierSourceCode = "1",
			CodeListIdentificationCode = "D",
			CodeListResponsibleAgencyCode = "m",
		};

		var actual = Map.MapComposite<C286_SequenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredSequencePositionIdentifier(string sequencePositionIdentifier, bool isValidExpected)
	{
		var subject = new C286_SequenceInformation();
		//Required fields
		//Test Parameters
		subject.SequencePositionIdentifier = sequencePositionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
