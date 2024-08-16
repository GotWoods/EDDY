using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E987Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "9:X4xO:c:Q9Pb:S";

		var expected = new E987_ProductDateAndTime()
		{
			DateValue = "9",
			TimeValue = "X4xO",
			DateValue2 = "c",
			TimeValue2 = "Q9Pb",
			DateVariationNumber = "S",
		};

		var actual = Map.MapComposite<E987_ProductDateAndTime>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
