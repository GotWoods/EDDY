using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C524Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:Z:r:l";

		var expected = new C524_HandlingInstructions()
		{
			HandlingInstructionsCoded = "4",
			CodeListQualifier = "Z",
			CodeListResponsibleAgencyCoded = "r",
			HandlingInstructions = "l",
		};

		var actual = Map.MapComposite<C524_HandlingInstructions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
