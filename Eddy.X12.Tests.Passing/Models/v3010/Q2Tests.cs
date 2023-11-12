using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*5gJr*gV*ExvYAJ*UqTRdU*r7G0RU*6*2*e*XF*zC*q*2*24";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "5gJr",
			CountryCode = "gV",
			RequiredPierDate = "ExvYAJ",
			SailingDate = "UqTRdU",
			DischargeDate = "r7G0RU",
			LadingQuantity = 6,
			Weight = 2,
			WeightQualifier = "e",
			FlightVoyageNumber = "XF",
			ReferenceNumberQualifier = "zC",
			ReferenceNumber = "q",
			VesselCodeQualifier = "2",
			VesselName = "24",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
