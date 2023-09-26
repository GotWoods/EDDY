using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class X01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X01*RN*d*G*d*L2p7*PP*ef*Owq*czEAiW*7";

		var expected = new X01_AutomatedManifestArchiveStatusDetails()
		{
			StandardCarrierAlphaCode = "RN",
			LocationQualifier = "d",
			LocationIdentifier = "G",
			VesselCodeQualifier = "d",
			VesselCode = "L2p7",
			VesselName = "PP",
			FlightVoyageNumber = "ef",
			DateTimeQualifier = "Owq",
			Date = "czEAiW",
			Quantity = 7,
		};

		var actual = Map.MapObject<X01_AutomatedManifestArchiveStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RN", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.LocationQualifier = "d";
		subject.LocationIdentifier = "G";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "d";
			subject.VesselCode = "L2p7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "RN";
		subject.LocationIdentifier = "G";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "d";
			subject.VesselCode = "L2p7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "RN";
		subject.LocationQualifier = "d";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "d";
			subject.VesselCode = "L2p7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "L2p7", true)]
	[InlineData("d", "", false)]
	[InlineData("", "L2p7", false)]
	public void Validation_AllAreRequiredVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "RN";
		subject.LocationQualifier = "d";
		subject.LocationIdentifier = "G";
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
