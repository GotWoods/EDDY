using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class INPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "INP++++m";

		var expected = new INP_PartiesAndInstruction()
		{
			PartiesToInstruction = null,
			Instruction = null,
			StatusOfInstruction = null,
			ActionRequestNotificationDescriptionCode = "m",
		};

		var actual = Map.MapObject<INP_PartiesAndInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
