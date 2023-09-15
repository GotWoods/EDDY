using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class L3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L3*3*I*6*0a*m*l*3*geW*7*R*5*K*o*B1*Ju";

		var expected = new L3_TotalWeightAndCharges()
		{
			Weight = 3,
			WeightQualifier = "I",
			FreightRate = 6,
			RateValueQualifier = "0a",
			AmountCharged = "m",
			Advances = "l",
			PrepaidAmount = "3",
			SpecialChargeOrAllowanceCode = "geW",
			Volume = 7,
			VolumeUnitQualifier = "R",
			LadingQuantity = 5,
			WeightUnitCode = "K",
			TariffNumber = "o",
			DeclaredValue = "B1",
			RateValueQualifier2 = "Ju",
		};

		var actual = Map.MapObject<L3_TotalWeightAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "I", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "I", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "0a";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "B1";
			subject.RateValueQualifier2 = "Ju";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "0a", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "0a", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 3;
			subject.WeightQualifier = "I";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "B1";
			subject.RateValueQualifier2 = "Ju";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "R", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "R", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 3;
			subject.WeightQualifier = "I";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "0a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "B1";
			subject.RateValueQualifier2 = "Ju";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("K", 3, true)]
	[InlineData("K", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 3;
			subject.WeightQualifier = "I";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "0a";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.DeclaredValue = "B1";
			subject.RateValueQualifier2 = "Ju";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B1", "Ju", true)]
	[InlineData("B1", "", false)]
	[InlineData("", "Ju", false)]
	public void Validation_AllAreRequiredDeclaredValue(string declaredValue, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new L3_TotalWeightAndCharges();
		subject.DeclaredValue = declaredValue;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 3;
			subject.WeightQualifier = "I";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "0a";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
