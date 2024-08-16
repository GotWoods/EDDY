using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E987Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "j:kaXZ:3:xGU3:p";

		var expected = new E987_ProductDateAndTime()
		{
			Date = "j",
			Time = "kaXZ",
			Date2 = "3",
			Time2 = "xGU3",
			DateVariationNumber = "p",
		};

		var actual = Map.MapComposite<E987_ProductDateAndTime>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
