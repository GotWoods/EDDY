using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C524Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "S:9:Z:a";

		var expected = new C524_HandlingInstructions()
		{
			HandlingInstructionsCoded = "S",
			CodeListIdentificationCode = "9",
			CodeListResponsibleAgencyCode = "Z",
			HandlingInstructions = "a",
		};

		var actual = Map.MapComposite<C524_HandlingInstructions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
