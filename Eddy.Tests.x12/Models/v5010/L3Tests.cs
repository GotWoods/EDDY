using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class L3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L3*2*l*1*Rk*x*v*t*sT2*7*p*9*b*7*uI*o8";

		var expected = new L3_TotalWeightAndCharges()
		{
			Weight = 2,
			WeightQualifier = "l",
			FreightRate = 1,
			RateValueQualifier = "Rk",
			AmountCharged = "x",
			Advances = "v",
			PrepaidAmount = "t",
			SpecialChargeOrAllowanceCode = "sT2",
			Volume = 7,
			VolumeUnitQualifier = "p",
			LadingQuantity = 9,
			WeightUnitCode = "b",
			TariffNumber = "7",
			DeclaredValue = "uI",
			RateValueQualifier2 = "o8",
		};

		var actual = Map.MapObject<L3_TotalWeightAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "l", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "l", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 1;
			subject.RateValueQualifier = "Rk";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "uI";
			subject.RateValueQualifier2 = "o8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Rk", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Rk", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 2;
			subject.WeightQualifier = "l";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "uI";
			subject.RateValueQualifier2 = "o8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "p", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "p", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 2;
			subject.WeightQualifier = "l";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 1;
			subject.RateValueQualifier = "Rk";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "uI";
			subject.RateValueQualifier2 = "o8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("b", 2, true)]
	[InlineData("b", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 2;
			subject.WeightQualifier = "l";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 1;
			subject.RateValueQualifier = "Rk";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "uI";
			subject.RateValueQualifier2 = "o8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uI", "o8", true)]
	[InlineData("uI", "", false)]
	[InlineData("", "o8", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 2;
			subject.WeightQualifier = "l";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 1;
			subject.RateValueQualifier = "Rk";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
