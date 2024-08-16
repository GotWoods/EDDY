using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C078Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "B:x:e:4";

		var expected = new C078_AccountHolderIdentification()
		{
			AccountHolderIdentifier = "B",
			AccountHolderName = "x",
			AccountHolderName2 = "e",
			CurrencyIdentificationCode = "4",
		};

		var actual = Map.MapComposite<C078_AccountHolderIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
