using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C078Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:F:S:b";

		var expected = new C078_AccountIdentification()
		{
			AccountHolderNumber = "H",
			AccountHolderName = "F",
			AccountHolderName2 = "S",
			CurrencyCoded = "b",
		};

		var actual = Map.MapComposite<C078_AccountIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
