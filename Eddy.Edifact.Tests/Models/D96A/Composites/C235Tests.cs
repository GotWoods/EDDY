using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C235Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "O:kT00";

		var expected = new C235_HazardIdentification()
		{
			HazardIdentificationNumberUpperPart = "O",
			SubstanceIdentificationNumberLowerPart = "kT00",
		};

		var actual = Map.MapComposite<C235_HazardIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
