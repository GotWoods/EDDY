using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class L3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L3*1*L*3*ym*B*P*n*pfW*7*K*2*7*6*3L*i6";

		var expected = new L3_TotalWeightAndCharges()
		{
			Weight = 1,
			WeightQualifier = "L",
			FreightRate = 3,
			RateValueQualifier = "ym",
			Charge = "B",
			Advances = "P",
			PrepaidAmount = "n",
			SpecialChargeOrAllowanceCode = "pfW",
			Volume = 7,
			VolumeUnitQualifier = "K",
			LadingQuantity = 2,
			WeightUnitCode = "7",
			TariffNumber = "6",
			DeclaredValue = "3L",
			RateValueQualifier2 = "i6",
		};

		var actual = Map.MapObject<L3_TotalWeightAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "L", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "L", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 3;
			subject.RateValueQualifier = "ym";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "3L";
			subject.RateValueQualifier2 = "i6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "ym", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "ym", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 1;
			subject.WeightQualifier = "L";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "3L";
			subject.RateValueQualifier2 = "i6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "K", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "K", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 1;
			subject.WeightQualifier = "L";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 3;
			subject.RateValueQualifier = "ym";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "3L";
			subject.RateValueQualifier2 = "i6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7", 1, true)]
	[InlineData("7", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 1;
			subject.WeightQualifier = "L";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 3;
			subject.RateValueQualifier = "ym";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "3L";
			subject.RateValueQualifier2 = "i6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3L", "i6", true)]
	[InlineData("3L", "", false)]
	[InlineData("", "i6", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 1;
			subject.WeightQualifier = "L";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 3;
			subject.RateValueQualifier = "ym";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
