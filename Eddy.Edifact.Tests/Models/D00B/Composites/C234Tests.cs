using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C234Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "OEWR:M";

		var expected = new C234_UNDGInformation()
		{
			UnitedNationsDangerousGoodsUNDGIdentifier = "OEWR",
			DangerousGoodsFlashpointValue = "M",
		};

		var actual = Map.MapComposite<C234_UNDGInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
