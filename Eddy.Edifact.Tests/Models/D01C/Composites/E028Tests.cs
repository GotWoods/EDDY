using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E028Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "s:w:A";

		var expected = new E028_RelatedCause()
		{
			RelatedCauseCode = "s",
			Date = "w",
			CountrySubEntityNameCode = "A",
		};

		var actual = Map.MapComposite<E028_RelatedCause>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
