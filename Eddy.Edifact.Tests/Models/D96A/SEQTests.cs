using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class SEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEQ+O+";

		var expected = new SEQ_SequenceDetails()
		{
			StatusIndicatorCoded = "O",
			SequenceInformation = null,
		};

		var actual = Map.MapObject<SEQ_SequenceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
