using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class VC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC1*A*Q*q*Hj*Nyc*6*i*7*P*1*3*6*y*6*8";

		var expected = new VC1_VehicleDetail()
		{
			Color = "A",
			Color2 = "Q",
			VehicleDimension = "q",
			SpecialHandlingCode = "Hj",
			CurrencyCode = "Nyc",
			MonetaryAmount = 6,
			WeightUnitCode = "i",
			Weight = 7,
			MeasurementUnitQualifier = "P",
			Height = 1,
			Length = 3,
			Width = 6,
			VolumeUnitQualifier = "y",
			Volume = 6,
			LocationIdentifier = "8",
		};

		var actual = Map.MapObject<VC1_VehicleDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "Nyc", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "Nyc", true)]
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
			subject.VolumeUnitQualifier = "y";
			subject.Volume = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("y", 6, true)]
	[InlineData("y", 0, false)]
	[InlineData("", 6, false)]
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
