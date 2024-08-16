using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C514Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:o";

		var expected = new C514_SampleLocationDetails()
		{
			SampleLocationDescriptionCode = "M",
			SampleLocationDescription = "o",
		};

		var actual = Map.MapComposite<C514_SampleLocationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
