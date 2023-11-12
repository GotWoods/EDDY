using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class V1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V1*rU2n*JA*0j*rQ*Ri*t*2L*U";

		var expected = new V1_VesselIdentification()
		{
			VesselCode = "rU2n",
			VesselName = "JA",
			CountryCode = "0j",
			FlightVoyageNumber = "rQ",
			StandardCarrierAlphaCode = "Ri",
			VesselRequirementCode = "t",
			VesselTypeCode = "2L",
			VesselCodeQualifier = "U",
		};

		var actual = Map.MapObject<V1_VesselIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
