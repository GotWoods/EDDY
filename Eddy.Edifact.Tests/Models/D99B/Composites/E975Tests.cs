using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E975Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "4:8:V:f";

		var expected = new E975_Location()
		{
			LocationNameCode = "4",
			LocationName = "8",
			CountryNameCode = "V",
			LocationFunctionCodeQualifier = "f",
		};

		var actual = Map.MapComposite<E975_Location>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
