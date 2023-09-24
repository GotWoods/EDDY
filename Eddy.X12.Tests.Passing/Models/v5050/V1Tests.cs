using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class V1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V1*L*dn*xk*nd*qF*b*dR*t*u";

		var expected = new V1_VesselIdentification()
		{
			VesselCode = "L",
			VesselName = "dn",
			CountryCode = "xk",
			FlightVoyageNumber = "nd",
			StandardCarrierAlphaCode = "qF",
			VesselRequirementCode = "b",
			VesselTypeCode = "dR",
			VesselCodeQualifier = "t",
			TransportationMethodTypeCode = "u",
		};

		var actual = Map.MapObject<V1_VesselIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("L", "dn", true)]
	[InlineData("L", "", true)]
	[InlineData("", "dn", true)]
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
	[InlineData("t", "L", true)]
	[InlineData("t", "", false)]
	[InlineData("", "L", true)]
	public void Validation_ARequiresBVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new V1_VesselIdentification();
		//Required fields
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;
		//At Least one
		subject.VesselName = "dn";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
