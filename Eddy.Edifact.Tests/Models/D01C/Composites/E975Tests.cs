using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E975Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "4:u:5:4";

		var expected = new E975_Location()
		{
			LocationNameCode = "4",
			LocationName = "u",
			CountryNameCode = "5",
			LocationFunctionCodeQualifier = "4",
		};

		var actual = Map.MapComposite<E975_Location>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
