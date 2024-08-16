using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E995Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "J:X:XrmK";

		var expected = new E995_MovementDetails()
		{
			ServiceRequirementCode = "J",
			Date = "X",
			Time = "XrmK",
		};

		var actual = Map.MapComposite<E995_MovementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
