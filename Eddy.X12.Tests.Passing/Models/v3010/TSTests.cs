using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS*1*V*o*zc*hM*5L*q";

		var expected = new TS_TariffSection()
		{
			TariffSection = "1",
			TariffItemNumber = "V",
			TariffItemSuffix = "o",
			TariffSectionIDCode = "zc",
			RateValueQualifier = "hM",
			EquipmentDescriptionCode = "5L",
			TariffSectionDescription = "q",
		};

		var actual = Map.MapObject<TS_TariffSection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
