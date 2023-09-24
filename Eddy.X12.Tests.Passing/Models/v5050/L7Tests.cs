using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class L7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7*5*K*O*9*2*9*gy*O*x8sS*MpxZoSk7*A*u*4*n*on*t3";

		var expected = new L7_TariffReference()
		{
			LadingLineItemNumber = 5,
			TariffAgencyCode = "K",
			TariffNumber = "O",
			TariffSectionNumber = "9",
			TariffItemNumber = "2",
			TariffItemPart = 9,
			FreightClassCode = "gy",
			TariffSupplementIdentifier = "O",
			ExParte = "x8sS",
			Date = "MpxZoSk7",
			RateBasisNumber = "A",
			TariffColumn = "u",
			TariffDistance = 4,
			DistanceQualifier = "n",
			CityName = "on",
			StateOrProvinceCode = "t3",
		};

		var actual = Map.MapObject<L7_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
