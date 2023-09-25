using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*Z*i2*EwxQoVib*ovqgAVU8*XplvL5ko*6*2*z*Vx*eh*c*A*ZL*9*6*f";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "Z",
			CountryCode = "i2",
			Date = "EwxQoVib",
			Date2 = "ovqgAVU8",
			Date3 = "XplvL5ko",
			LadingQuantity = 6,
			Weight = 2,
			WeightQualifier = "z",
			FlightVoyageNumber = "Vx",
			ReferenceIdentificationQualifier = "eh",
			ReferenceIdentification = "c",
			VesselCodeQualifier = "A",
			VesselName = "ZL",
			Volume = 9,
			VolumeUnitQualifier = "6",
			WeightUnitCode = "f",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eh", "c", true)]
	[InlineData("eh", "", false)]
	[InlineData("", "c", true)]
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
			subject.VolumeUnitQualifier = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "6", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "6", false)]
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
