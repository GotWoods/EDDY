using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class SEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEQ+S+";

		var expected = new SEQ_SequenceDetails()
		{
			ActionCode = "S",
			SequenceInformation = null,
		};

		var actual = Map.MapObject<SEQ_SequenceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
