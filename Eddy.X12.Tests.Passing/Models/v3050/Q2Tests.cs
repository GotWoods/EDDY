using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*T*kH*XgOG77*W5piWJ*QLvtV6*9*4*V*hf*zp*Z*4*pK*2*J*R";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "T",
			CountryCode = "kH",
			Date = "XgOG77",
			Date2 = "W5piWJ",
			Date3 = "QLvtV6",
			LadingQuantity = 9,
			Weight = 4,
			WeightQualifier = "V",
			FlightVoyageNumber = "hf",
			ReferenceNumberQualifier = "zp",
			ReferenceNumber = "Z",
			VesselCodeQualifier = "4",
			VesselName = "pK",
			Volume = 2,
			VolumeUnitQualifier = "J",
			WeightUnitCode = "R",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zp", "Z", true)]
	[InlineData("zp", "", false)]
	[InlineData("", "Z", true)]
	public void Validation_ARequiresBReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new Q2_StatusDetailsOcean();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "J", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "J", false)]
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
