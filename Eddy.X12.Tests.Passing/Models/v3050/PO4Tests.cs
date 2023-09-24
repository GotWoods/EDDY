using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PO4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO4*9*2*NB*cK9*I*5*Ub*8*8n*2*8*7*Ae*3";

		var expected = new PO4_ItemPhysicalDetails()
		{
			Pack = 9,
			Size = 2,
			UnitOrBasisForMeasurementCode = "NB",
			PackagingCode = "cK9",
			WeightQualifier = "I",
			GrossWeightPerPack = 5,
			UnitOrBasisForMeasurementCode2 = "Ub",
			GrossVolumePerPack = 8,
			UnitOrBasisForMeasurementCode3 = "8n",
			Length = 2,
			Width = 8,
			Height = 7,
			UnitOrBasisForMeasurementCode4 = "Ae",
			InnerPack = 3,
		};

		var actual = Map.MapObject<PO4_ItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "NB", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "NB", false)]
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
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Ub";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "8n";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "Ae";
			subject.Length = 2;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("I", 5, true)]
	[InlineData("I", 0, false)]
	[InlineData("", 5, true)]
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
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode = "NB";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Ub";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "8n";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "Ae";
			subject.Length = 2;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "Ub", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "Ub", false)]
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
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode = "NB";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "8n";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "Ae";
			subject.Length = 2;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "8n", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "8n", false)]
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
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode = "NB";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Ub";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "Ae";
			subject.Length = 2;
			subject.Width = 8;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Ae", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Ae", true)]
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
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode = "NB";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Ub";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "8n";
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
	[InlineData(8, "Ae", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Ae", true)]
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
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode = "NB";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Ub";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "8n";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 2;
			subject.Height = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Ae", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Ae", true)]
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
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode = "NB";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Ub";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "8n";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 2;
			subject.Width = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("Ae", 2, 8, 7, true)]
	[InlineData("Ae", 0, 0, 0, false)]
	[InlineData("", 2, 8, 7, true)]
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
			subject.UnitOrBasisForMeasurementCode4 = "Ae";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode4 = "Ae";
		if (height > 0)
			subject.UnitOrBasisForMeasurementCode4 = "Ae";
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode = "NB";
		}
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossWeightPerPack = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Ub";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossVolumePerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "8n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
