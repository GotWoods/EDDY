using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class L7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7*8*O*v*6*l*9*Wt*P*lCko*JVhv3EI7*I*f*2*J*up*4f";

		var expected = new L7_TariffReference()
		{
			LadingLineItemNumber = 8,
			TariffAgencyCode = "O",
			TariffNumber = "v",
			TariffSectionNumber = "6",
			TariffItemNumber = "l",
			TariffItemPart = 9,
			FreightClassCode = "Wt",
			TariffSupplementIdentifier = "P",
			ExParte = "lCko",
			Date = "JVhv3EI7",
			RateBasisNumber = "I",
			TariffColumn = "f",
			TariffDistance = 2,
			DistanceQualifier = "J",
			CityName = "up",
			StateOrProvinceCode = "4f",
		};

		var actual = Map.MapObject<L7_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
