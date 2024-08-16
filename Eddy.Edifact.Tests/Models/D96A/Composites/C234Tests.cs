using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C234Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "UtHx:5";

		var expected = new C234_UndgInformation()
		{
			UNDGNumber = "UtHx",
			DangerousGoodsFlashpoint = "5",
		};

		var actual = Map.MapComposite<C234_UndgInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
