using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E975Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "R:L";

		var expected = new E975_Location()
		{
			PlaceLocationIdentification = "R",
			PlaceLocation = "L",
		};

		var actual = Map.MapComposite<E975_Location>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
