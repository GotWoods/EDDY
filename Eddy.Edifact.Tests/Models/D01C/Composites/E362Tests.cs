using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E362Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "aDBm:Fjpm:r:6";

		var expected = new E362_RelatedTimeInformation()
		{
			Time = "aDBm",
			Time2 = "Fjpm",
			TimeZoneDifferenceQuantity = "r",
			DateVariationNumber = "6",
		};

		var actual = Map.MapComposite<E362_RelatedTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
