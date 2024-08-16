using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class SEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEQ+T+";

		var expected = new SEQ_SequenceDetails()
		{
			ActionRequestNotificationDescriptionCode = "T",
			SequenceInformation = null,
		};

		var actual = Map.MapObject<SEQ_SequenceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
