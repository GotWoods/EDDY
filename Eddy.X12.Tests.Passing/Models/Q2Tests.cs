using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*X*5H*krTlfv4x*mvwlXUHQ*UHjxvAgd*1*8*l*LJ*8M*y*W*iF*5*m*M";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "X",
			CountryCode = "5H",
			Date = "krTlfv4x",
			Date2 = "mvwlXUHQ",
			Date3 = "UHjxvAgd",
			LadingQuantity = 1,
			Weight = 8,
			WeightQualifier = "l",
			FlightVoyageNumber = "LJ",
			ReferenceIdentificationQualifier = "8M",
			ReferenceIdentification = "y",
			VesselCodeQualifier = "W",
			VesselName = "iF",
			Volume = 5,
			VolumeUnitQualifier = "m",
			WeightUnitCode = "M",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "y", true)]
	[InlineData("8M", "", false)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q2_StatusDetailsOcean();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "m", true)]
	[InlineData(0, "m", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new Q2_StatusDetailsOcean();
		if (volume > 0)
		subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
