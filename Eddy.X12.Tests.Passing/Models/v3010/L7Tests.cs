using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7*1*M*1*P*2*3*6u*4*CuGA*AoOrlP*V*Y*8*L*o2*EM";

		var expected = new L7_TariffReference()
		{
			LadingLineItemNumber = 1,
			TariffAgencyCode = "M",
			TariffNumber = "1",
			TariffSection = "P",
			TariffItemNumber = "2",
			TariffItemPart = 3,
			FreightClassCode = "6u",
			TariffSupplementIdentifier = "4",
			ExParte = "CuGA",
			EffectiveDate = "AoOrlP",
			RateBasisNumber = "V",
			TariffColumn = "Y",
			TariffDistance = 8,
			DistanceQualifier = "L",
			CityName = "o2",
			StateOrProvinceCode = "EM",
		};

		var actual = Map.MapObject<L7_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
