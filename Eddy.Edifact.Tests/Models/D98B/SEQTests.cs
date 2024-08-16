using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class SEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEQ+Z+";

		var expected = new SEQ_SequenceDetails()
		{
			ActionRequestNotificationCoded = "Z",
			SequenceInformation = null,
		};

		var actual = Map.MapObject<SEQ_SequenceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
