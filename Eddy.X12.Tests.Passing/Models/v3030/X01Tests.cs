using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class X01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X01*F2*G*h*u*q*Xn*a1*cak*Sxih4s*5";

		var expected = new X01_AutomatedManifestArchiveStatusDetails()
		{
			StandardCarrierAlphaCode = "F2",
			LocationQualifier = "G",
			LocationIdentifier = "h",
			VesselCodeQualifier = "u",
			VesselCode = "q",
			VesselName = "Xn",
			FlightVoyageNumber = "a1",
			DateTimeQualifier = "cak",
			Date = "Sxih4s",
			Quantity = 5,
		};

		var actual = Map.MapObject<X01_AutomatedManifestArchiveStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F2", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.LocationQualifier = "G";
		subject.LocationIdentifier = "h";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "u";
			subject.VesselCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "F2";
		subject.LocationIdentifier = "h";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "u";
			subject.VesselCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "F2";
		subject.LocationQualifier = "G";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "u";
			subject.VesselCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "q", true)]
	[InlineData("u", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "F2";
		subject.LocationQualifier = "G";
		subject.LocationIdentifier = "h";
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
