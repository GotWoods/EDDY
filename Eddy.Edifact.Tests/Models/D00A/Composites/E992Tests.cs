using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E992Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "V:J";

		var expected = new E992_Position()
		{
			FirstRelatedLocationNameCode = "V",
			SecondRelatedLocationNameCode = "J",
		};

		var actual = Map.MapComposite<E992_Position>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
