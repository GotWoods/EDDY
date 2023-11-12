using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class V1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V1*p*E9*n1*t9*zM*z*zZ*V*H";

		var expected = new V1_VesselIdentification()
		{
			VesselCode = "p",
			VesselName = "E9",
			CountryCode = "n1",
			FlightVoyageNumber = "t9",
			StandardCarrierAlphaCode = "zM",
			VesselRequirementCode = "z",
			VesselTypeCode = "zZ",
			VesselCodeQualifier = "V",
			TransportationMethodTypeCode = "H",
		};

		var actual = Map.MapObject<V1_VesselIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("p", "E9", true)]
	[InlineData("p", "", true)]
	[InlineData("", "E9", true)]
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
	[InlineData("V", "p", true)]
	[InlineData("V", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new V1_VesselIdentification();
		//Required fields
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;
		//At Least one
		subject.VesselName = "E9";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
