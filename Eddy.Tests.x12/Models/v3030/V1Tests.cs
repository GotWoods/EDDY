using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class V1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V1*8*m3*yp*8u*6M*j*KT*C*t";

		var expected = new V1_VesselIdentification()
		{
			VesselCode = "8",
			VesselName = "m3",
			CountryCode = "yp",
			FlightVoyageNumber = "8u",
			StandardCarrierAlphaCode = "6M",
			VesselRequirementCode = "j",
			VesselTypeCode = "KT",
			VesselCodeQualifier = "C",
			TransportationMethodTypeCode = "t",
		};

		var actual = Map.MapObject<V1_VesselIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("8", "m3", true)]
	[InlineData("8", "", true)]
	[InlineData("", "m3", true)]
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
