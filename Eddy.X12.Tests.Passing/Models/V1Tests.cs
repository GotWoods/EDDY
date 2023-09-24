using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class V1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V1*A*R0*Ya*hu*YC*W*Xq*o*P";

		var expected = new V1_VesselIdentification()
		{
			VesselCode = "A",
			VesselName = "R0",
			CountryCode = "Ya",
			FlightVoyageNumber = "hu",
			StandardCarrierAlphaCode = "YC",
			VesselRequirementCode = "W",
			VesselTypeCode = "Xq",
			VesselCodeQualifier = "o",
			TransportationMethodTypeCode = "P",
		};

		var actual = Map.MapObject<V1_VesselIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("A","R0", true)]
	[InlineData("", "R0", true)]
	[InlineData("A", "", true)]
	public void Validation_AtLeastOneVesselCode(string vesselCode, string vesselName, bool isValidExpected)
	{
		var subject = new V1_VesselIdentification();
		subject.VesselCode = vesselCode;
		subject.VesselName = vesselName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "A", true)]
	[InlineData("o", "", false)]
	public void Validation_ARequiresBVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new V1_VesselIdentification();
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
