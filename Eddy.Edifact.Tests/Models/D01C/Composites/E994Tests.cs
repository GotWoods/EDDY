using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E994Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "G:h";

		var expected = new E994_StopoverInformation()
		{
			LocationNameCode = "G",
			UnitsQuantity = "h",
		};

		var actual = Map.MapComposite<E994_StopoverInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
