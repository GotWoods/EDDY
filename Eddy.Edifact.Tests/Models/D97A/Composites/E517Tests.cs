using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "K:m:d:r";

		var expected = new E517_LocationIdentification()
		{
			PlaceLocationIdentification = "K",
			CodeListQualifier = "m",
			CodeListResponsibleAgencyCoded = "d",
			PlaceLocation = "r",
		};

		var actual = Map.MapComposite<E517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
