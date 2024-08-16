using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C853Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:Z:j";

		var expected = new C853_ErrorSegmentPointDetails()
		{
			SegmentTagIdentifier = "5",
			SequencePositionIdentifier = "Z",
			SequenceIdentifierSourceCode = "j",
		};

		var actual = Map.MapComposite<C853_ErrorSegmentPointDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
