using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E212Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:D:I:F";

		var expected = new E212_ItemNumberIdentification()
		{
			ItemNumber = "F",
			ItemNumberTypeCoded = "D",
			CodeListQualifier = "I",
			CodeListResponsibleAgencyCoded = "F",
		};

		var actual = Map.MapComposite<E212_ItemNumberIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
