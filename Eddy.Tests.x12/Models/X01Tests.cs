using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class X01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X01*eY*U*u*i*n*h9*5Z*LAg*gAGdLrEh*2";

		var expected = new X01_AutomatedManifestArchiveStatusDetails()
		{
			StandardCarrierAlphaCode = "eY",
			LocationQualifier = "U",
			LocationIdentifier = "u",
			VesselCodeQualifier = "i",
			VesselCode = "n",
			VesselName = "h9",
			FlightVoyageNumber = "5Z",
			DateTimeQualifier = "LAg",
			Date = "gAGdLrEh",
			Quantity = 2,
		};

		var actual = Map.MapObject<X01_AutomatedManifestArchiveStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eY", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		subject.LocationQualifier = "U";
		subject.LocationIdentifier = "u";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		subject.StandardCarrierAlphaCode = "eY";
		subject.LocationIdentifier = "u";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		subject.StandardCarrierAlphaCode = "eY";
		subject.LocationQualifier = "U";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("i", "n", true)]
	[InlineData("", "n", false)]
	[InlineData("i", "", false)]
	public void Validation_AllAreRequiredVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		subject.StandardCarrierAlphaCode = "eY";
		subject.LocationQualifier = "U";
		subject.LocationIdentifier = "u";
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
