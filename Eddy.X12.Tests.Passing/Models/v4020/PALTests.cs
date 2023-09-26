using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class PALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAL*D*4*9*1*4*TD*3*7*4*Ge*5*AJ*4*Pq*2*5*X";

		var expected = new PAL_PalletInformation()
		{
			PalletTypeCode = "D",
			PalletTiers = 4,
			PalletBlocks = 9,
			Pack = 1,
			UnitWeight = 4,
			UnitOrBasisForMeasurementCode = "TD",
			Length = 3,
			Width = 7,
			Height = 4,
			UnitOrBasisForMeasurementCode2 = "Ge",
			GrossWeightPerPack = 5,
			UnitOrBasisForMeasurementCode3 = "AJ",
			GrossVolumePerPack = 4,
			UnitOrBasisForMeasurementCode4 = "Pq",
			PalletExchangeCode = "2",
			InnerPack = 5,
			PalletStructureCode = "X",
		};

		var actual = Map.MapObject<PAL_PalletInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "TD", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "TD", false)]
	public void Validation_AllAreRequiredUnitWeight(decimal unitWeight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (unitWeight > 0) 
			subject.UnitWeight = unitWeight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode3 = "AJ";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 4;
			subject.UnitOrBasisForMeasurementCode4 = "Pq";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Ge";
			subject.Length = 3;
			subject.Width = 7;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Ge", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Ge", true)]
	public void Validation_ARequiresBLength(decimal length, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "TD";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode3 = "AJ";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 4;
			subject.UnitOrBasisForMeasurementCode4 = "Pq";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Width > 0 || subject.Height > 0)
		{
			subject.Width = 7;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Ge", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Ge", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "TD";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode3 = "AJ";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 4;
			subject.UnitOrBasisForMeasurementCode4 = "Pq";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 3;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Ge", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Ge", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "TD";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode3 = "AJ";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 4;
			subject.UnitOrBasisForMeasurementCode4 = "Pq";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 3;
			subject.Width = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("Ge", 3, 7, 4, true)]
	[InlineData("Ge", 0, 0, 0, false)]
	[InlineData("", 3, 7, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal length, decimal width, decimal height, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
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
			subject.UnitOrBasisForMeasurementCode2 = "Ge";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode2 = "Ge";
		if (height > 0)
			subject.UnitOrBasisForMeasurementCode2 = "Ge";
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "TD";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode3 = "AJ";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 4;
			subject.UnitOrBasisForMeasurementCode4 = "Pq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "AJ", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "AJ", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "TD";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 4;
			subject.UnitOrBasisForMeasurementCode4 = "Pq";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Ge";
			subject.Length = 3;
			subject.Width = 7;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Pq", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Pq", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 4;
			subject.UnitOrBasisForMeasurementCode = "TD";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode3 = "AJ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Ge";
			subject.Length = 3;
			subject.Width = 7;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
