using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C524Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:m:9:k";

		var expected = new C524_HandlingInstructions()
		{
			HandlingInstructionDescriptionCode = "G",
			CodeListIdentificationCode = "m",
			CodeListResponsibleAgencyCode = "9",
			HandlingInstructionDescription = "k",
		};

		var actual = Map.MapComposite<C524_HandlingInstructions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
