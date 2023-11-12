using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class PALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAL*Q*3*2*4*4*7E*2*7*6*FB*3*HW*6*pt*i*2*c*2";

		var expected = new PAL_PalletTypeAndLoadCharacteristics()
		{
			PalletTypeCode = "Q",
			PalletTiers = 3,
			PalletBlocks = 2,
			Pack = 4,
			UnitWeight = 4,
			UnitOrBasisForMeasurementCode = "7E",
			Length = 2,
			Width = 7,
			Height = 6,
			UnitOrBasisForMeasurementCode2 = "FB",
			GrossWeightPerPack = 3,
			UnitOrBasisForMeasurementCode3 = "HW",
			GrossVolumePerPack = 6,
			UnitOrBasisForMeasurementCode4 = "pt",
			PalletExchangeCode = "i",
			InnerPack = 2,
			PalletStructureCode = "c",
			Quantity = 2,
		};

		var actual = Map.MapObject<PAL_PalletTypeAndLoadCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "7E", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "7E", false)]
	public void Validation_AllAreRequiredUnitWeight(decimal unitWeight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PAL_PalletTypeAndLoadCharacteristics();
		//Required fields
		//Test Parameters
		if (unitWeight > 0) 
			subject.UnitWeight = unitWeight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "HW";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode4 = "pt";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "FB";
			subject.Length = 2;
			subject.Width = 7;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "FB", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "FB", true)]
	public void Validation_ARequiresBLength(decimal length, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PAL_PalletTypeAndLoadCharacteristics();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "7E";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "HW";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode4 = "pt";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Width > 0 || subject.Height > 0)
		{
			subject.Width = 7;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "FB", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "FB", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PAL_PalletTypeAndLoadCharacteristics();
		//Required fields
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "7E";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "HW";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode4 = "pt";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 2;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "FB", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "FB", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PAL_PalletTypeAndLoadCharacteristics();
		//Required fields
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "7E";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "HW";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode4 = "pt";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 2;
			subject.Width = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("FB", 2, 7, 6, true)]
	[InlineData("FB", 0, 0, 0, false)]
	[InlineData("", 2, 7, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal length, decimal width, decimal height, bool isValidExpected)
	{
		var subject = new PAL_PalletTypeAndLoadCharacteristics();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (length > 0) 
			subject.Length = length;
		if (width > 0) 
			subject.Width = width;
		if (height > 0) 
			subject.Height = height;
		//A Requires B
		if (length > 0)
			subject.UnitOrBasisForMeasurementCode2 = "FB";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode2 = "FB";
		if (height > 0)
			subject.UnitOrBasisForMeasurementCode2 = "FB";
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "7E";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "HW";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode4 = "pt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "HW", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "HW", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PAL_PalletTypeAndLoadCharacteristics();
		//Required fields
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "7E";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode4 = "pt";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "FB";
			subject.Length = 2;
			subject.Width = 7;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "pt", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "pt", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PAL_PalletTypeAndLoadCharacteristics();
		//Required fields
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "7E";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "HW";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "FB";
			subject.Length = 2;
			subject.Width = 7;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
