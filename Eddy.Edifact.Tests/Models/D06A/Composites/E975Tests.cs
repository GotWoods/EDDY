using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E975Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "4:1:D:z";

		var expected = new E975_Location()
		{
			LocationIdentifier = "4",
			LocationName = "1",
			CountryIdentifier = "D",
			LocationFunctionCodeQualifier = "z",
		};

		var actual = Map.MapComposite<E975_Location>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
