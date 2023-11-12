using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*Pqnc*jB*VChJYN*zAqRDH*FbliSL*8*4*T*Ld*Aa*G*n*zQ*3*H*u";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "Pqnc",
			CountryCode = "jB",
			Date = "VChJYN",
			SailingDate = "zAqRDH",
			DischargeDate = "FbliSL",
			LadingQuantity = 8,
			Weight = 4,
			WeightQualifier = "T",
			FlightVoyageNumber = "Ld",
			ReferenceNumberQualifier = "Aa",
			ReferenceNumber = "G",
			VesselCodeQualifier = "n",
			VesselName = "zQ",
			Volume = 3,
			VolumeUnitQualifier = "H",
			WeightUnitQualifier = "u",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Aa", "G", true)]
	[InlineData("Aa", "", false)]
	[InlineData("", "G", true)]
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
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "H", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "H", false)]
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
