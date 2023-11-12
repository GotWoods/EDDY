using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PO4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO4*6*3*lQ*YBj*2*4*4V*3*Ti*9*8*7*st*5*wy*D*R*8";

		var expected = new PO4_ItemPhysicalDetails()
		{
			Pack = 6,
			Size = 3,
			UnitOrBasisForMeasurementCode = "lQ",
			PackagingCode = "YBj",
			WeightQualifier = "2",
			GrossWeightPerPack = 4,
			UnitOrBasisForMeasurementCode2 = "4V",
			GrossVolumePerPack = 3,
			UnitOrBasisForMeasurementCode3 = "Ti",
			Length = 9,
			Width = 8,
			Height = 7,
			UnitOrBasisForMeasurementCode4 = "st",
			InnerPack = 5,
			SurfaceLayerPositionCode = "wy",
			AssignedIdentification = "D",
			AssignedIdentification2 = "R",
			Number = 8,
		};

		var actual = Map.MapObject<PO4_ItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "lQ", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "lQ", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (size > 0) 
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 4;
			subject.UnitOrBasisForMeasurementCode2 = "4V";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Ti";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "st";
			subject.Length = 9;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2", 4, true)]
	[InlineData("2", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal grossWeightPerPack, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "lQ";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 4;
			subject.UnitOrBasisForMeasurementCode2 = "4V";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Ti";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "st";
			subject.Length = 9;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "4V", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "4V", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "lQ";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Ti";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "st";
			subject.Length = 9;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Ti", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Ti", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "lQ";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 4;
			subject.UnitOrBasisForMeasurementCode2 = "4V";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "st";
			subject.Length = 9;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "st", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "st", true)]
	public void Validation_ARequiresBLength(decimal length, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "lQ";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 4;
			subject.UnitOrBasisForMeasurementCode2 = "4V";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Ti";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Width > 0 || subject.Height > 0)
		{
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "st", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "st", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "lQ";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 4;
			subject.UnitOrBasisForMeasurementCode2 = "4V";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Ti";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 9;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "st", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "st", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "lQ";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 4;
			subject.UnitOrBasisForMeasurementCode2 = "4V";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Ti";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 9;
			subject.Width = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("st", 9, 8, 7, true)]
	[InlineData("st", 0, 0, 0, false)]
	[InlineData("", 9, 8, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal length, decimal width, decimal height, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (length > 0) 
			subject.Length = length;
		if (width > 0) 
			subject.Width = width;
		if (height > 0) 
			subject.Height = height;
		//A Requires B
		if (length > 0)
			subject.UnitOrBasisForMeasurementCode4 = "st";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode4 = "st";
		if (height > 0)
			subject.UnitOrBasisForMeasurementCode4 = "st";
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "lQ";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 4;
			subject.UnitOrBasisForMeasurementCode2 = "4V";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Ti";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "D", true)]
	[InlineData("R", "", false)]
	[InlineData("", "D", true)]
	public void Validation_ARequiresBAssignedIdentification2(string assignedIdentification2, string assignedIdentification, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification2 = assignedIdentification2;
		subject.AssignedIdentification = assignedIdentification;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "lQ";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 4;
			subject.UnitOrBasisForMeasurementCode2 = "4V";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Ti";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "st";
			subject.Length = 9;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "YBj", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "YBj", true)]
	public void Validation_ARequiresBNumber(int number, string packagingCode, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		subject.PackagingCode = packagingCode;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "lQ";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 4;
			subject.UnitOrBasisForMeasurementCode2 = "4V";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Ti";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "st";
			subject.Length = 9;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
