using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*r*0T*7tyK0jd8*QcBhu0JO*LTc1mSVV*8*3*E*T7*0X*i*I*9B*4*B*q";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "r",
			CountryCode = "0T",
			Date = "7tyK0jd8",
			Date2 = "QcBhu0JO",
			Date3 = "LTc1mSVV",
			LadingQuantity = 8,
			Weight = 3,
			WeightQualifier = "E",
			FlightVoyageNumber = "T7",
			ReferenceIdentificationQualifier = "0X",
			ReferenceIdentification = "i",
			VesselCodeQualifier = "I",
			VesselName = "9B",
			Volume = 4,
			VolumeUnitQualifier = "B",
			WeightUnitCode = "q",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0X", "i", true)]
	[InlineData("0X", "", false)]
	[InlineData("", "i", true)]
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
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "B", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "B", false)]
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
