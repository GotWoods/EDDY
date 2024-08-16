using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C234Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "oVL3:s";

		var expected = new C234_UNDGInformation()
		{
			UnitedNationsDangerousGoodsIdentificationCode = "oVL3",
			DangerousGoodsFlashpointValue = "s",
		};

		var actual = Map.MapComposite<C234_UNDGInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
