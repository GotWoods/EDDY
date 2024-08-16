using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E028Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:K:B";

		var expected = new E028_RelatedCause()
		{
			RelatedCauseCode = "q",
			DateValue = "K",
			CountrySubEntityNameCode = "B",
		};

		var actual = Map.MapComposite<E028_RelatedCause>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
