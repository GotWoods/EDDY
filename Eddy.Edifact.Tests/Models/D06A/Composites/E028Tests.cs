using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E028Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:B:b";

		var expected = new E028_RelatedCause()
		{
			RelatedCauseCode = "S",
			Date = "B",
			CountrySubdivisionIdentifier = "b",
		};

		var actual = Map.MapComposite<E028_RelatedCause>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
