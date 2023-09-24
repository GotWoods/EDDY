using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PO4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO4*4*8*kY*ZxtIw*w*4*VB*7*Zz*9*4*5*EL";

		var expected = new PO4_ItemPhysicalDetails()
		{
			Pack = 4,
			Size = 8,
			UnitOrBasisForMeasurementCode = "kY",
			PackagingCode = "ZxtIw",
			WeightQualifier = "w",
			GrossWeightPerPack = 4,
			UnitOrBasisForMeasurementCode2 = "VB",
			GrossVolumePerPack = 7,
			UnitOrBasisForMeasurementCode3 = "Zz",
			Length = 9,
			Width = 4,
			Height = 5,
			UnitOrBasisForMeasurementCode4 = "EL",
		};

		var actual = Map.MapObject<PO4_ItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "kY", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "kY", true)]
	public void Validation_ARequiresBSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (size > 0) 
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode3 = "Zz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "EL";
			subject.Length = 9;
			subject.Width = 4;
			subject.Height = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("w", 4, true)]
	[InlineData("w", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal grossWeightPerPack, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		//A Requires B
		if (grossWeightPerPack > 0)
			subject.UnitOrBasisForMeasurementCode2 = "VB";
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode3 = "Zz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "EL";
			subject.Length = 9;
			subject.Width = 4;
			subject.Height = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "VB", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "VB", true)]
	public void Validation_ARequiresBGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode3 = "Zz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "EL";
			subject.Length = 9;
			subject.Width = 4;
			subject.Height = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Zz", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Zz", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "EL";
			subject.Length = 9;
			subject.Width = 4;
			subject.Height = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "EL", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "EL", true)]
	public void Validation_ARequiresBLength(decimal length, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode3 = "Zz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Width > 0 || subject.Height > 0)
		{
			subject.Width = 4;
			subject.Height = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "EL", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "EL", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode3 = "Zz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 9;
			subject.Height = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "EL", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "EL", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode3 = "Zz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 9;
			subject.Width = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("EL", 9, 4, 5, true)]
	[InlineData("EL", 0, 0, 0, false)]
	[InlineData("", 9, 4, 5, true)]
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
			subject.UnitOrBasisForMeasurementCode4 = "EL";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode4 = "EL";
		if (height > 0)
			subject.UnitOrBasisForMeasurementCode4 = "EL";
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode3 = "Zz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
