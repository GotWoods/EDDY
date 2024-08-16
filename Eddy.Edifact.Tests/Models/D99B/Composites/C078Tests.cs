using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C078Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "s:V:a:R";

		var expected = new C078_AccountHolderIdentification()
		{
			AccountHolderNumber = "s",
			AccountHolderName = "V",
			AccountHolderName2 = "a",
			CurrencyIdentificationCode = "R",
		};

		var actual = Map.MapComposite<C078_AccountHolderIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
