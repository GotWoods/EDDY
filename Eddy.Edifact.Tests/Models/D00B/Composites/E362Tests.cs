using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E362Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "jgrG:robY:y:9";

		var expected = new E362_RelatedTimeInformation()
		{
			TimeValue = "jgrG",
			TimeValue2 = "robY",
			TimeZoneDifferenceValue = "y",
			DateVariationNumber = "9",
		};

		var actual = Map.MapComposite<E362_RelatedTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
