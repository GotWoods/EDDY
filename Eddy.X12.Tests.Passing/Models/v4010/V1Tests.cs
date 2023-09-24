using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class V1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V1*c*JY*rR*s7*jT*f*pW*G*k";

		var expected = new V1_VesselIdentification()
		{
			VesselCode = "c",
			VesselName = "JY",
			CountryCode = "rR",
			FlightVoyageNumber = "s7",
			StandardCarrierAlphaCode = "jT",
			VesselRequirementCode = "f",
			VesselTypeCode = "pW",
			VesselCodeQualifier = "G",
			TransportationMethodTypeCode = "k",
		};

		var actual = Map.MapObject<V1_VesselIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("c", "JY", true)]
	[InlineData("c", "", true)]
	[InlineData("", "JY", true)]
	public void Validation_AtLeastOneVesselCode(string vesselCode, string vesselName, bool isValidExpected)
	{
		var subject = new V1_VesselIdentification();
		//Required fields
		//Test Parameters
		subject.VesselCode = vesselCode;
		subject.VesselName = vesselName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "c", true)]
	[InlineData("G", "", false)]
	[InlineData("", "c", true)]
	public void Validation_ARequiresBVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new V1_VesselIdentification();
		//Required fields
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;
		//At Least one
		subject.VesselName = "JY";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
