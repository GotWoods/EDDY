using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class L7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7*4*N*r*x*u*7*FX*c*yvJK*RH1q2u*Z*E*1*i*uR*C3";

		var expected = new L7_TariffReference()
		{
			LadingLineItemNumber = 4,
			TariffAgencyCode = "N",
			TariffNumber = "r",
			TariffSection = "x",
			TariffItemNumber = "u",
			TariffItemPart = 7,
			FreightClassCode = "FX",
			TariffSupplementIdentifier = "c",
			ExParte = "yvJK",
			Date = "RH1q2u",
			RateBasisNumber = "Z",
			TariffColumn = "E",
			TariffDistance = 1,
			DistanceQualifier = "i",
			CityName = "uR",
			StateOrProvinceCode = "C3",
		};

		var actual = Map.MapObject<L7_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
