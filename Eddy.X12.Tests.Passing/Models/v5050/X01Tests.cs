using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class X01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X01*G0*a*M*p*6*oX*Pe*GfF*ubEDeqWp*7";

		var expected = new X01_AutomatedManifestArchiveStatusDetails()
		{
			StandardCarrierAlphaCode = "G0",
			LocationQualifier = "a",
			LocationIdentifier = "M",
			VesselCodeQualifier = "p",
			VesselCode = "6",
			VesselName = "oX",
			FlightVoyageNumber = "Pe",
			DateTimeQualifier = "GfF",
			Date = "ubEDeqWp",
			Quantity = 7,
		};

		var actual = Map.MapObject<X01_AutomatedManifestArchiveStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G0", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "M";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "p";
			subject.VesselCode = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G0";
		subject.LocationIdentifier = "M";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "p";
			subject.VesselCode = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G0";
		subject.LocationQualifier = "a";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "p";
			subject.VesselCode = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "6", true)]
	[InlineData("p", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G0";
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "M";
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
