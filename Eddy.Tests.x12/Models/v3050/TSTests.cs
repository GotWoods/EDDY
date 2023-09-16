using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS*Z*W*q*r2*K1*oC*x";

		var expected = new TS_TariffSection()
		{
			TariffSection = "Z",
			TariffItemNumber = "W",
			TariffItemSuffix = "q",
			TariffSectionIDCode = "r2",
			RateValueQualifier = "K1",
			EquipmentDescriptionCode = "oC",
			Description = "x",
		};

		var actual = Map.MapObject<TS_TariffSection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
