using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class PALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAL*w*8*2*7*2*l6*3*6*7*0i*1*AC*5*IO*H*6*V*7*b*L";

		var expected = new PAL_PalletTypeAndLoadCharacteristics()
		{
			PalletTypeCode = "w",
			PalletTiers = 8,
			PalletBlocks = 2,
			Pack = 7,
			UnitWeight = 2,
			UnitOrBasisForMeasurementCode = "l6",
			Length = 3,
			Width = 6,
			Height = 7,
			UnitOrBasisForMeasurementCode2 = "0i",
			GrossWeightPerPack = 1,
			UnitOrBasisForMeasurementCode3 = "AC",
			GrossVolumePerPack = 5,
			UnitOrBasisForMeasurementCode4 = "IO",
			PalletExchangeCode = "H",
			InnerPack = 6,
			PalletStructureCode = "V",
			Quantity = 7,
			YesNoConditionOrResponseCode = "b",
			Description = "L",
		};

		var actual = Map.MapObject<PAL_PalletTypeAndLoadCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "l6", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "l6", false)]
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
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "AC";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 5;
			subject.UnitOrBasisForMeasurementCode4 = "IO";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "0i";
			subject.Length = 3;
			subject.Width = 6;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "0i", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "0i", true)]
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
			subject.UnitWeight = 2;
			subject.UnitOrBasisForMeasurementCode = "l6";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "AC";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 5;
			subject.UnitOrBasisForMeasurementCode4 = "IO";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Width > 0 || subject.Height > 0)
		{
			subject.Width = 6;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "0i", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "0i", true)]
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
			subject.UnitWeight = 2;
			subject.UnitOrBasisForMeasurementCode = "l6";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "AC";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 5;
			subject.UnitOrBasisForMeasurementCode4 = "IO";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 3;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "0i", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "0i", true)]
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
			subject.UnitWeight = 2;
			subject.UnitOrBasisForMeasurementCode = "l6";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "AC";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 5;
			subject.UnitOrBasisForMeasurementCode4 = "IO";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 3;
			subject.Width = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("0i", 3, 6, 7, true)]
	[InlineData("0i", 0, 0, 0, false)]
	[InlineData("", 3, 6, 7, true)]
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
			subject.UnitOrBasisForMeasurementCode2 = "0i";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode2 = "0i";
		if (height > 0)
			subject.UnitOrBasisForMeasurementCode2 = "0i";
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 2;
			subject.UnitOrBasisForMeasurementCode = "l6";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "AC";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 5;
			subject.UnitOrBasisForMeasurementCode4 = "IO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "AC", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "AC", false)]
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
			subject.UnitWeight = 2;
			subject.UnitOrBasisForMeasurementCode = "l6";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 5;
			subject.UnitOrBasisForMeasurementCode4 = "IO";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "0i";
			subject.Length = 3;
			subject.Width = 6;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "IO", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "IO", false)]
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
			subject.UnitWeight = 2;
			subject.UnitOrBasisForMeasurementCode = "l6";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "AC";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "0i";
			subject.Length = 3;
			subject.Width = 6;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
