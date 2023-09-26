using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAL*P*6*7*3*6*oq*7*2*7*Gh*2*Ck*3*sI*W";

		var expected = new PAL_PalletInformation()
		{
			PalletTypeCode = "P",
			PalletTiers = 6,
			PalletBlocks = 7,
			Pack = 3,
			UnitWeight = 6,
			UnitOfMeasurementCode = "oq",
			Length = 7,
			Width = 2,
			Height = 7,
			UnitOfMeasurementCode2 = "Gh",
			GrossWeightPerPack = 2,
			UnitOfMeasurementCode3 = "Ck",
			GrossVolumePerPack = 3,
			UnitOfMeasurementCode4 = "sI",
			PalletExchangeCode = "W",
		};

		var actual = Map.MapObject<PAL_PalletInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "oq", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "oq", false)]
	public void Validation_AllAreRequiredUnitWeight(decimal unitWeight, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (unitWeight > 0) 
			subject.UnitWeight = unitWeight;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.GrossWeightPerPack = 2;
			subject.UnitOfMeasurementCode3 = "Ck";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOfMeasurementCode4 = "sI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Gh", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Gh", true)]
	public void Validation_ARequiresBLength(decimal length, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.UnitWeight = 6;
			subject.UnitOfMeasurementCode = "oq";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.GrossWeightPerPack = 2;
			subject.UnitOfMeasurementCode3 = "Ck";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOfMeasurementCode4 = "sI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Gh", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Gh", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.UnitWeight = 6;
			subject.UnitOfMeasurementCode = "oq";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.GrossWeightPerPack = 2;
			subject.UnitOfMeasurementCode3 = "Ck";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOfMeasurementCode4 = "sI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Gh", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Gh", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.UnitWeight = 6;
			subject.UnitOfMeasurementCode = "oq";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.GrossWeightPerPack = 2;
			subject.UnitOfMeasurementCode3 = "Ck";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOfMeasurementCode4 = "sI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Ck", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Ck", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.UnitWeight = 6;
			subject.UnitOfMeasurementCode = "oq";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOfMeasurementCode4 = "sI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "sI", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "sI", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOfMeasurementCode4, bool isValidExpected)
	{
		var subject = new PAL_PalletInformation();
		//Required fields
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOfMeasurementCode4 = unitOfMeasurementCode4;
		//If one filled, all required
		if(subject.UnitWeight > 0 || subject.UnitWeight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.UnitWeight = 6;
			subject.UnitOfMeasurementCode = "oq";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.GrossWeightPerPack = 2;
			subject.UnitOfMeasurementCode3 = "Ck";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
