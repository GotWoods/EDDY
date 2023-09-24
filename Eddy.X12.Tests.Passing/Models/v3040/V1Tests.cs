using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class V1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V1*9*Zx*G0*Kl*ql*d*7C*N*5";

		var expected = new V1_VesselIdentification()
		{
			VesselCode = "9",
			VesselName = "Zx",
			CountryCode = "G0",
			FlightVoyageNumber = "Kl",
			StandardCarrierAlphaCode = "ql",
			VesselRequirementCode = "d",
			VesselTypeCode = "7C",
			VesselCodeQualifier = "N",
			TransportationMethodTypeCode = "5",
		};

		var actual = Map.MapObject<V1_VesselIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9", "Zx", true)]
	[InlineData("9", "", true)]
	[InlineData("", "Zx", true)]
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
	[InlineData("N", "9", true)]
	[InlineData("N", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new V1_VesselIdentification();
		//Required fields
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;
		//At Least one
		subject.VesselName = "Zx";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
