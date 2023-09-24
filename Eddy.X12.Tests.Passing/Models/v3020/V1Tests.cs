using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class V1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V1*JAlK*zi*e2*10*jl*A*tq*l*d";

		var expected = new V1_VesselIdentification()
		{
			VesselCode = "JAlK",
			VesselName = "zi",
			CountryCode = "e2",
			FlightVoyageNumber = "10",
			StandardCarrierAlphaCode = "jl",
			VesselRequirementCode = "A",
			VesselTypeCode = "tq",
			VesselCodeQualifier = "l",
			TransportationMethodTypeCode = "d",
		};

		var actual = Map.MapObject<V1_VesselIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("JAlK", "zi", true)]
	[InlineData("JAlK", "", true)]
	[InlineData("", "zi", true)]
	public void Validation_AtLeastOneVesselCode(string vesselCode, string vesselName, bool isValidExpected)
	{
		var subject = new V1_VesselIdentification();
		//Required fields
		//Test Parameters
		subject.VesselCode = vesselCode;
		subject.VesselName = vesselName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
