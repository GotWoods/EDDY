using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class INPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "INP++++4";

		var expected = new INP_PartiesAndInstruction()
		{
			PartiesToInstruction = null,
			Instruction = null,
			StatusOfInstruction = null,
			ActionCode = "4",
		};

		var actual = Map.MapObject<INP_PartiesAndInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
