using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class X01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X01*Zm*A*D*v*8*jj*kP*XS7*Dq9AxfJz*3";

		var expected = new X01_AutomatedManifestArchiveStatusDetails()
		{
			StandardCarrierAlphaCode = "Zm",
			LocationQualifier = "A",
			LocationIdentifier = "D",
			VesselCodeQualifier = "v",
			VesselCode = "8",
			VesselName = "jj",
			FlightVoyageNumber = "kP",
			DateTimeQualifier = "XS7",
			Date = "Dq9AxfJz",
			Quantity = 3,
		};

		var actual = Map.MapObject<X01_AutomatedManifestArchiveStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zm", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.LocationQualifier = "A";
		subject.LocationIdentifier = "D";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "v";
			subject.VesselCode = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "Zm";
		subject.LocationIdentifier = "D";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "v";
			subject.VesselCode = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "Zm";
		subject.LocationQualifier = "A";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCodeQualifier) || !string.IsNullOrEmpty(subject.VesselCode))
		{
			subject.VesselCodeQualifier = "v";
			subject.VesselCode = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "8", true)]
	[InlineData("v", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredVesselCodeQualifier(string vesselCodeQualifier, string vesselCode, bool isValidExpected)
	{
		var subject = new X01_AutomatedManifestArchiveStatusDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "Zm";
		subject.LocationQualifier = "A";
		subject.LocationIdentifier = "D";
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
