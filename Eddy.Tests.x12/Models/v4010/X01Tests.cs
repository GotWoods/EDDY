using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class X01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X01*xi*8*d*G*X*mU*Ud*lPJ*kxL6Qyiy*5";

		var expected = new X01_AutomatedManifestArchiveStatusDetails()
		{
			StandardCarrierAlphaCode = "xi",
			LocationQualifier = "8",
			LocationIdentifier = "d",
			VesselCodeQualifier = "G",
			VesselCode = "X",
			VesselName = "mU",
			FlightVoyageNumber = "Ud",
			DateTimeQualifier = "lPJ",
			Date = "kxL6Qyiy",
			Quantity = 5,
		};

		var actual = Map.MapObject<X01_AutomatedManifestArchiveStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xi", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "d";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "G";
			subject.VesselCode = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "xi";
		subject.LocationIdentifier = "d";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "G";
			subject.VesselCode = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "xi";
		subject.LocationQualifier = "8";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "G";
			subject.VesselCode = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "X", true)]
	[InlineData("G", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "xi";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "d";
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
