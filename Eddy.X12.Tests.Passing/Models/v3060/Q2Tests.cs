using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*M*Eb*oeB6II*iG6KlX*vLGNDz*3*6*Y*Wr*H6*h*T*s2*9*5*x";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "M",
			CountryCode = "Eb",
			Date = "oeB6II",
			Date2 = "iG6KlX",
			Date3 = "vLGNDz",
			LadingQuantity = 3,
			Weight = 6,
			WeightQualifier = "Y",
			FlightVoyageNumber = "Wr",
			ReferenceIdentificationQualifier = "H6",
			ReferenceIdentification = "h",
			VesselCodeQualifier = "T",
			VesselName = "s2",
			Volume = 9,
			VolumeUnitQualifier = "5",
			WeightUnitCode = "x",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H6", "h", true)]
	[InlineData("H6", "", false)]
	[InlineData("", "h", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q2_StatusDetailsOcean();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 9;
			subject.VolumeUnitQualifier = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "5", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "5", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new Q2_StatusDetailsOcean();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
