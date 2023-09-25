using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*u*Jw*i3odXqXe*YQNuLEYU*8sxZYT2m*7*4*8*AA*Ls*b*b*dy*5*R*U";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "u",
			CountryCode = "Jw",
			Date = "i3odXqXe",
			Date2 = "YQNuLEYU",
			Date3 = "8sxZYT2m",
			LadingQuantity = 7,
			Weight = 4,
			WeightQualifier = "8",
			FlightVoyageNumber = "AA",
			ReferenceIdentificationQualifier = "Ls",
			ReferenceIdentification = "b",
			VesselCodeQualifier = "b",
			VesselName = "dy",
			Volume = 5,
			VolumeUnitQualifier = "R",
			WeightUnitCode = "U",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ls", "b", true)]
	[InlineData("Ls", "", false)]
	[InlineData("", "b", true)]
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
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "R", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "R", false)]
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
