using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS*a*B*g*YH*wX*Wi*K";

		var expected = new TS_TariffSection()
		{
			TariffSectionIdentifier = "a",
			TariffItemNumber = "B",
			TariffItemSuffix = "g",
			TariffSectionIDCode = "YH",
			RateValueQualifier = "wX",
			EquipmentDescriptionCode = "Wi",
			Description = "K",
		};

		var actual = Map.MapObject<TS_TariffSection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
