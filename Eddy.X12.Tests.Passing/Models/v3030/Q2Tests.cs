using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class Q2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q2*d*77*bBzAWN*pTXigM*xU1aZw*2*4*2*on*YF*I*I*Uz*1*u*W";

		var expected = new Q2_StatusDetailsOcean()
		{
			VesselCode = "d",
			CountryCode = "77",
			Date = "bBzAWN",
			SailingDate = "pTXigM",
			DischargeDate = "xU1aZw",
			LadingQuantity = 2,
			Weight = 4,
			WeightQualifier = "2",
			FlightVoyageNumber = "on",
			ReferenceNumberQualifier = "YF",
			ReferenceNumber = "I",
			VesselCodeQualifier = "I",
			VesselName = "Uz",
			Volume = 1,
			VolumeUnitQualifier = "u",
			WeightUnitCode = "W",
		};

		var actual = Map.MapObject<Q2_StatusDetailsOcean>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YF", "I", true)]
	[InlineData("YF", "", false)]
	[InlineData("", "I", true)]
	public void Validation_ARequiresBReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new Q2_StatusDetailsOcean();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.VolumeUnitQualifier = "u";
			subject.WeightUnitCode = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "W", true)]
	[InlineData("u", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, string weightUnitCode, bool isValidExpected)
	{
		var subject = new Q2_StatusDetailsOcean();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		subject.WeightUnitCode = weightUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
