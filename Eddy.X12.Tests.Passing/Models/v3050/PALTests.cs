using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAL*h*1*7*5*9*MG*3*3*9*cA*3*Me*8*75*X";

		var expected = new PAL_PalletInformation()
		{
			PalletTypeCode = "h",
			PalletTiers = 1,
			PalletBlocks = 7,
			Pack = 5,
			UnitWeight = 9,
			UnitOrBasisForMeasurementCode = "MG",
			Length = 3,
			Width = 3,
			Height = 9,
			UnitOrBasisForMeasurementCode2 = "cA",
			GrossWeightPerPack = 3,
			UnitOrBasisForMeasurementCode3 = "Me",
			GrossVolumePerPack = 8,
			UnitOrBasisForMeasurementCode4 = "75",
			PalletExchangeCode = "X",
		};

		var actual = Map.MapObject<PAL_PalletInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "MG", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "MG", false)]
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
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Me";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode4 = "75";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "cA";
			subject.Length = 3;
			subject.Width = 3;
			subject.Height = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "cA", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "cA", true)]
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
			subject.UnitWeight = 9;
			subject.UnitOrBasisForMeasurementCode = "MG";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Me";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode4 = "75";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Width > 0 || subject.Height > 0)
		{
			subject.Width = 3;
			subject.Height = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "cA", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "cA", true)]
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
			subject.UnitWeight = 9;
			subject.UnitOrBasisForMeasurementCode = "MG";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Me";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode4 = "75";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 3;
			subject.Height = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "cA", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "cA", true)]
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
			subject.UnitWeight = 9;
			subject.UnitOrBasisForMeasurementCode = "MG";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Me";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode4 = "75";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 3;
			subject.Width = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("cA", 3, 3, 9, true)]
	[InlineData("cA", 0, 0, 0, false)]
	[InlineData("", 3, 3, 9, true)]
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
			subject.UnitOrBasisForMeasurementCode2 = "cA";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode2 = "cA";
		if (height > 0)
			subject.UnitOrBasisForMeasurementCode2 = "cA";
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.UnitWeight = 9;
			subject.UnitOrBasisForMeasurementCode = "MG";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Me";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode4 = "75";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Me", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Me", false)]
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
			subject.UnitWeight = 9;
			subject.UnitOrBasisForMeasurementCode = "MG";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode4 = "75";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "cA";
			subject.Length = 3;
			subject.Width = 3;
			subject.Height = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "75", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "75", false)]
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
			subject.UnitWeight = 9;
			subject.UnitOrBasisForMeasurementCode = "MG";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Me";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "cA";
			subject.Length = 3;
			subject.Width = 3;
			subject.Height = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
