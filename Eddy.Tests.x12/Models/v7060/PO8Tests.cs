using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class PO8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO8*e*2*1*rp*kf9**6*OQ*4*f7*9*CL*4*eg*4*xp*1";

		var expected = new PO8_UnmarkedTradeItemPhysicalDetails()
		{
			AssignedIdentification = "e",
			Pack = 2,
			Size = 1,
			UnitOrBasisForMeasurementCode = "rp",
			PackagingCode = "kf9",
			CompositeProductWeightBasis = null,
			GrossVolumePerPack = 6,
			UnitOrBasisForMeasurementCode2 = "OQ",
			Length = 4,
			UnitOrBasisForMeasurementCode3 = "f7",
			Width = 9,
			UnitOrBasisForMeasurementCode4 = "CL",
			Height = 4,
			UnitOrBasisForMeasurementCode5 = "eg",
			ItemDepth = 4,
			UnitOrBasisForMeasurementCode6 = "xp",
			InnerPack = 1,
		};

		var actual = Map.MapObject<PO8_UnmarkedTradeItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "rp";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode2 = "OQ";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 4;
			subject.UnitOrBasisForMeasurementCode3 = "f7";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode4 = "CL";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode5 = "eg";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.ItemDepth = 4;
			subject.UnitOrBasisForMeasurementCode6 = "xp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "rp", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "rp", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
		//Required fields
		subject.AssignedIdentification = "e";
		//Test Parameters
		if (size > 0) 
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode2 = "OQ";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 4;
			subject.UnitOrBasisForMeasurementCode3 = "f7";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode4 = "CL";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode5 = "eg";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.ItemDepth = 4;
			subject.UnitOrBasisForMeasurementCode6 = "xp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "OQ", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "OQ", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
		//Required fields
		subject.AssignedIdentification = "e";
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "rp";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 4;
			subject.UnitOrBasisForMeasurementCode3 = "f7";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode4 = "CL";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode5 = "eg";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.ItemDepth = 4;
			subject.UnitOrBasisForMeasurementCode6 = "xp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "f7", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "f7", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
		//Required fields
		subject.AssignedIdentification = "e";
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "rp";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode2 = "OQ";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode4 = "CL";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode5 = "eg";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.ItemDepth = 4;
			subject.UnitOrBasisForMeasurementCode6 = "xp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 4, false)]
	[InlineData(4, 0, true)]
	[InlineData(0, 4, true)]
	public void Validation_OnlyOneOfLength(decimal length, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
		//Required fields
		subject.AssignedIdentification = "e";
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;

        if (subject.Length > 0)
            subject.UnitOrBasisForMeasurementCode3 = "AB";

        //If one filled, all required
        if (subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "rp";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode2 = "OQ";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode4 = "CL";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode5 = "eg";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.ItemDepth = 4;
			subject.UnitOrBasisForMeasurementCode6 = "xp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "CL", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "CL", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
		//Required fields
		subject.AssignedIdentification = "e";
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "rp";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode2 = "OQ";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 4;
			subject.UnitOrBasisForMeasurementCode3 = "f7";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode5 = "eg";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.ItemDepth = 4;
			subject.UnitOrBasisForMeasurementCode6 = "xp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "eg", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "eg", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
		//Required fields
		subject.AssignedIdentification = "e";
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "rp";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode2 = "OQ";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 4;
			subject.UnitOrBasisForMeasurementCode3 = "f7";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode4 = "CL";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.ItemDepth = 4;
			subject.UnitOrBasisForMeasurementCode6 = "xp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "xp", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "xp", false)]
	public void Validation_AllAreRequiredItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
		//Required fields
		subject.AssignedIdentification = "e";
		//Test Parameters
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "rp";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.GrossVolumePerPack = 6;
			subject.UnitOrBasisForMeasurementCode2 = "OQ";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 4;
			subject.UnitOrBasisForMeasurementCode3 = "f7";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode4 = "CL";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode5 = "eg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
