using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E975Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "1:k:A:f";

		var expected = new E975_Location()
		{
			PlaceLocationIdentification = "1",
			PlaceLocation = "k",
			CountryCoded = "A",
			PlaceLocationQualifier = "f",
		};

		var actual = Map.MapComposite<E975_Location>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
