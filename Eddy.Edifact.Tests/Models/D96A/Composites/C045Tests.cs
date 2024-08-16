using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C045Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "3:Y:l:4:9:6";

		var expected = new C045_BillLevelIdentification()
		{
			LevelOneId = "3",
			LevelTwoId = "Y",
			LevelThreeId = "l",
			LevelFourId = "4",
			LevelFiveId = "9",
			LevelSixId = "6",
		};

		var actual = Map.MapComposite<C045_BillLevelIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
