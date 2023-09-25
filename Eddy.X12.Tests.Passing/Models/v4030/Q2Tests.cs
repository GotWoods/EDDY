using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*w*MF*1uzsaKEd*05Nw6tgc*8nd0nQG0*1*5*6*uj*0d*B*D*ui*7*z*q";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "w",
			CountryCode = "MF",
			Date = "1uzsaKEd",
			Date2 = "05Nw6tgc",
			Date3 = "8nd0nQG0",
			LadingQuantity = 1,
			Weight = 5,
			WeightQualifier = "6",
			FlightVoyageNumber = "uj",
			ReferenceIdentificationQualifier = "0d",
			ReferenceIdentification = "B",
			VesselCodeQualifier = "D",
			VesselName = "ui",
			Volume = 7,
			VolumeUnitQualifier = "z",
			WeightUnitCode = "q",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0d", "B", true)]
	[InlineData("0d", "", false)]
	[InlineData("", "B", true)]
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
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "z", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "z", false)]
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
