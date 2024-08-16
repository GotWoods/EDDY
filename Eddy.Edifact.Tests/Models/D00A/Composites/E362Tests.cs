using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E362Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "vwxK:2nlB:qPRo:l";

		var expected = new E362_RelatedTimeInformation()
		{
			TimeValue = "vwxK",
			TimeValue2 = "2nlB",
			TimeZoneDifference = "qPRo",
			DateVariationNumber = "l",
		};

		var actual = Map.MapComposite<E362_RelatedTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
