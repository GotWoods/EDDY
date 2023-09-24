using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class TSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS*e*P*T*iw*2O*HN*J";

		var expected = new TS_TariffSection()
		{
			TariffSectionIdentifier = "e",
			TariffItemNumber = "P",
			TariffItemSuffix = "T",
			TariffSectionIDCode = "iw",
			RateValueQualifier = "2O",
			EquipmentDescriptionCode = "HN",
			Description = "J",
		};

		var actual = Map.MapObject<TS_TariffSection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
