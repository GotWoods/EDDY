using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D05B;
using Eddy.Edifact.Models.D05B.Composites;

namespace Eddy.Edifact.Tests.Models.D05B.Composites;

public class C524Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "2:G:E:A";

		var expected = new C524_HandlingInstructions()
		{
			HandlingInstructionDescriptionCode = "2",
			CodeListIdentificationCode = "G",
			CodeListResponsibleAgencyCode = "E",
			HandlingInstructionDescription = "A",
		};

		var actual = Map.MapComposite<C524_HandlingInstructions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
