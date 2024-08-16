using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C234Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "WCne:C";

		var expected = new C234_UNDGInformation()
		{
			UnitedNationsDangerousGoodsUNDGIdentifier = "WCne",
			DangerousGoodsFlashpointDescription = "C",
		};

		var actual = Map.MapComposite<C234_UNDGInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
