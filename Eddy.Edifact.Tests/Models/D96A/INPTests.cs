using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class INPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "INP++++p";

		var expected = new INP_PartiesToInstruction()
		{
			PartiesToInstruction = null,
			Instruction = null,
			StatusOfInstruction = null,
			ActionRequestNotificationCoded = "p",
		};

		var actual = Map.MapObject<INP_PartiesToInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
