using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E992Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "L:e";

		var expected = new E992_Position()
		{
			FirstRelatedLocationIdentifier = "L",
			SecondRelatedLocationIdentifier = "e",
		};

		var actual = Map.MapComposite<E992_Position>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
