using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*J*yc*29KERS8i*ZoPs9SCl*gCB1QzE2*3*4*4*4q*zO*n*0*MD*2*C*B";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "J",
			CountryCode = "yc",
			Date = "29KERS8i",
			Date2 = "ZoPs9SCl",
			Date3 = "gCB1QzE2",
			LadingQuantity = 3,
			Weight = 4,
			WeightQualifier = "4",
			FlightVoyageNumber = "4q",
			ReferenceIdentificationQualifier = "zO",
			ReferenceIdentification = "n",
			VesselCodeQualifier = "0",
			VesselName = "MD",
			Volume = 2,
			VolumeUnitQualifier = "C",
			WeightUnitCode = "B",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zO", "n", true)]
	[InlineData("zO", "", false)]
	[InlineData("", "n", true)]
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
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "C", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "C", false)]
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
