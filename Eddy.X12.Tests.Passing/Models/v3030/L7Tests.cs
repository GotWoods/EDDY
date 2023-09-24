using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class L7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7*5*9*j*M*V*3*Eq*y*VHFt*DER7Eq*8*6*2*y*QG*lO";

		var expected = new L7_TariffReference()
		{
			LadingLineItemNumber = 5,
			TariffAgencyCode = "9",
			TariffNumber = "j",
			TariffSection = "M",
			TariffItemNumber = "V",
			TariffItemPart = 3,
			FreightClassCode = "Eq",
			TariffSupplementIdentifier = "y",
			ExParte = "VHFt",
			Date = "DER7Eq",
			RateBasisNumber = "8",
			TariffColumn = "6",
			TariffDistance = 2,
			DistanceQualifier = "y",
			CityName = "QG",
			StateOrProvinceCode = "lO",
		};

		var actual = Map.MapObject<L7_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
