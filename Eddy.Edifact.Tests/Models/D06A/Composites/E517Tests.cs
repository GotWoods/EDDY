using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "A:B:9:9";

		var expected = new E517_LocationIdentification()
		{
			LocationIdentifier = "A",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "9",
			LocationName = "9",
		};

		var actual = Map.MapComposite<E517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
