using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C524Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:A:H:G";

		var expected = new C524_HandlingInstructions()
		{
			HandlingInstructionDescriptionCode = "7",
			CodeListIdentificationCode = "A",
			CodeListResponsibleAgencyCode = "H",
			HandlingInstructionDescription = "G",
		};

		var actual = Map.MapComposite<C524_HandlingInstructions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
