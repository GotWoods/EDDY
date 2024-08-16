using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E995Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "R:I:aVnj";

		var expected = new E995_MovementDetails()
		{
			ServiceRequirementCode = "R",
			DateValue = "I",
			Time = "aVnj",
		};

		var actual = Map.MapComposite<E995_MovementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
