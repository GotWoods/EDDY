using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C514Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:a";

		var expected = new C514_SampleLocationDetails()
		{
			SampleLocationCoded = "H",
			SampleLocation = "a",
		};

		var actual = Map.MapComposite<C514_SampleLocationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
