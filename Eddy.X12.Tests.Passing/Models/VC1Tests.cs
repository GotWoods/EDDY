using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC1*U*Z*T*NV*4BL*7*H*2*w*4*5*1*y*4*h";

		var expected = new VC1_VehicleDetail()
		{
			Color = "U",
			Color2 = "Z",
			VehicleDimension = "T",
			SpecialHandlingCode = "NV",
			CurrencyCode = "4BL",
			MonetaryAmount = 7,
			WeightUnitCode = "H",
			Weight = 2,
			MeasurementUnitQualifier = "w",
			Height = 4,
			Length = 5,
			Width = 1,
			VolumeUnitQualifier = "y",
			Volume = 4,
			LocationIdentifier = "h",
		};

		var actual = Map.MapObject<VC1_VehicleDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "4BL", true)]
	[InlineData(7, "", false)]
	public void Validation_ARequiresBMonetaryAmount(decimal monetaryAmount, string currencyCode, bool isValidExpected)
	{
		var subject = new VC1_VehicleDetail();
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		subject.CurrencyCode = currencyCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("y", 4, true)]
	[InlineData("", 4, false)]
	[InlineData("y", 0, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new VC1_VehicleDetail();
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0)
		subject.Volume = volume;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
