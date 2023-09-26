using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class VC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC1*O*Z*r*2f*tfI*4*i*5*5*5*9*6*B*8*N";

		var expected = new VC1_VehicleDetail()
		{
			Color = "O",
			Color2 = "Z",
			VehicleDimension = "r",
			SpecialHandlingCode = "2f",
			CurrencyCode = "tfI",
			MonetaryAmount = 4,
			WeightUnitCode = "i",
			Weight = 5,
			MeasurementUnitQualifier = "5",
			Height = 5,
			Length = 9,
			Width = 6,
			VolumeUnitQualifier = "B",
			Volume = 8,
			LocationIdentifier = "N",
		};

		var actual = Map.MapObject<VC1_VehicleDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "tfI", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "tfI", true)]
	public void Validation_ARequiresBMonetaryAmount(decimal monetaryAmount, string currencyCode, bool isValidExpected)
	{
		var subject = new VC1_VehicleDetail();
		//Required fields
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.CurrencyCode = currencyCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "B";
			subject.Volume = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("B", 8, true)]
	[InlineData("B", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new VC1_VehicleDetail();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
