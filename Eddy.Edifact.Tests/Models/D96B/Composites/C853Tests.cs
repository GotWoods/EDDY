using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C853Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "a:5:T";

		var expected = new C853_ErrorSegmentPointDetails()
		{
			SegmentTag = "a",
			SequenceNumber = "5",
			SequenceNumberSourceCoded = "T",
		};

		var actual = Map.MapComposite<C853_ErrorSegmentPointDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
