using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class L7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7*4*2*o*R*m*3*5G*O*08JL*Dq45fMFS*t*D*3*l*6C*zT";

		var expected = new L7_TariffReference()
		{
			LadingLineItemNumber = 4,
			TariffAgencyCode = "2",
			TariffNumber = "o",
			TariffSection = "R",
			TariffItemNumber = "m",
			TariffItemPart = 3,
			FreightClassCode = "5G",
			TariffSupplementIdentifier = "O",
			ExParte = "08JL",
			Date = "Dq45fMFS",
			RateBasisNumber = "t",
			TariffColumn = "D",
			TariffDistance = 3,
			DistanceQualifier = "l",
			CityName = "6C",
			StateOrProvinceCode = "zT",
		};

		var actual = Map.MapObject<L7_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
