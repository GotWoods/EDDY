using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C045Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "f:1:6:F:V:Y";

		var expected = new C045_BillLevelIdentification()
		{
			LevelOneIdentifier = "f",
			LevelTwoIdentifier = "1",
			LevelThreeIdentifier = "6",
			LevelFourIdentifier = "F",
			LevelFiveIdentifier = "V",
			LevelSixIdentifier = "Y",
		};

		var actual = Map.MapComposite<C045_BillLevelIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
