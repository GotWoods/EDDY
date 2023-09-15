using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G39Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G39*sQ7Sub69RIbI*fk*D*XD*5*x*I*7*T7*9*N5*8*bZ*8*f6*738835*3*9*rx*O*8*U*a2*I*7*2*6";

		var expected = new G39_ItemCharacteristicsVendorsSellingUnit()
		{
			UPCCaseCode = "sQ7Sub69RIbI",
			ProductServiceIDQualifier = "fk",
			ProductServiceID = "D",
			SpecialHandlingCode = "XD",
			UnitWeight = 5,
			WeightQualifier = "x",
			WeightUnitCode = "I",
			Height = 7,
			UnitOrBasisForMeasurementCode = "T7",
			Width = 9,
			UnitOrBasisForMeasurementCode2 = "N5",
			Length = 8,
			UnitOrBasisForMeasurementCode3 = "bZ",
			Volume = 8,
			UnitOrBasisForMeasurementCode4 = "f6",
			PalletBlockAndTiers = 738835,
			Pack = 3,
			Size = 9,
			UnitOrBasisForMeasurementCode5 = "rx",
			Color = "O",
			OrderSizingFactor = 8,
			AlternateTiersPerPallet = "U",
			ProductServiceIDQualifier2 = "a2",
			ProductServiceID2 = "I",
			WeightQualifier2 = "7",
			UnitWeight2 = 2,
			InnerPack = 6,
		};

		var actual = Map.MapObject<G39_ItemCharacteristicsVendorsSellingUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("sQ7Sub69RIbI", "fk", true)]
	[InlineData("sQ7Sub69RIbI", "", true)]
	[InlineData("", "fk", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fk";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "x";
			subject.WeightUnitCode = "I";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOrBasisForMeasurementCode = "T7";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "N5";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode3 = "bZ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "f6";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 9;
			subject.UnitOrBasisForMeasurementCode5 = "rx";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "a2";
			subject.ProductServiceID2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "7";
			subject.UnitWeight2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fk", "D", true)]
	[InlineData("fk", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "sQ7Sub69RIbI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "x";
			subject.WeightUnitCode = "I";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOrBasisForMeasurementCode = "T7";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "N5";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode3 = "bZ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "f6";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 9;
			subject.UnitOrBasisForMeasurementCode5 = "rx";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "a2";
			subject.ProductServiceID2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "7";
			subject.UnitWeight2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "I", true)]
	[InlineData("x", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, string weightUnitCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier = weightQualifier;
		subject.WeightUnitCode = weightUnitCode;
			subject.UPCCaseCode = "sQ7Sub69RIbI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fk";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOrBasisForMeasurementCode = "T7";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "N5";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode3 = "bZ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "f6";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 9;
			subject.UnitOrBasisForMeasurementCode5 = "rx";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "a2";
			subject.ProductServiceID2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "7";
			subject.UnitWeight2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "T7", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "T7", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (height > 0)
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "sQ7Sub69RIbI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fk";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "x";
			subject.WeightUnitCode = "I";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "N5";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode3 = "bZ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "f6";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 9;
			subject.UnitOrBasisForMeasurementCode5 = "rx";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "a2";
			subject.ProductServiceID2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "7";
			subject.UnitWeight2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "N5", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "N5", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (width > 0)
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "sQ7Sub69RIbI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fk";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "x";
			subject.WeightUnitCode = "I";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOrBasisForMeasurementCode = "T7";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode3 = "bZ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "f6";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 9;
			subject.UnitOrBasisForMeasurementCode5 = "rx";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "a2";
			subject.ProductServiceID2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "7";
			subject.UnitWeight2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "bZ", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "bZ", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (length > 0)
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCCaseCode = "sQ7Sub69RIbI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fk";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "x";
			subject.WeightUnitCode = "I";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOrBasisForMeasurementCode = "T7";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "N5";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "f6";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 9;
			subject.UnitOrBasisForMeasurementCode5 = "rx";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "a2";
			subject.ProductServiceID2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "7";
			subject.UnitWeight2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "f6", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "f6", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
			subject.UPCCaseCode = "sQ7Sub69RIbI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fk";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "x";
			subject.WeightUnitCode = "I";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOrBasisForMeasurementCode = "T7";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "N5";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode3 = "bZ";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 9;
			subject.UnitOrBasisForMeasurementCode5 = "rx";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "a2";
			subject.ProductServiceID2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "7";
			subject.UnitWeight2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "rx", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "rx", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
			subject.UPCCaseCode = "sQ7Sub69RIbI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fk";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "x";
			subject.WeightUnitCode = "I";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOrBasisForMeasurementCode = "T7";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "N5";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode3 = "bZ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "f6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "a2";
			subject.ProductServiceID2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "7";
			subject.UnitWeight2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a2", "I", true)]
	[InlineData("a2", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "sQ7Sub69RIbI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fk";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "x";
			subject.WeightUnitCode = "I";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOrBasisForMeasurementCode = "T7";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "N5";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode3 = "bZ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "f6";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 9;
			subject.UnitOrBasisForMeasurementCode5 = "rx";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "7";
			subject.UnitWeight2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7", 2, true)]
	[InlineData("7", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredWeightQualifier2(string weightQualifier2, decimal unitWeight2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier2 = weightQualifier2;
		if (unitWeight2 > 0)
			subject.UnitWeight2 = unitWeight2;
			subject.UPCCaseCode = "sQ7Sub69RIbI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fk";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "x";
			subject.WeightUnitCode = "I";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOrBasisForMeasurementCode = "T7";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "N5";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode3 = "bZ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "f6";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 9;
			subject.UnitOrBasisForMeasurementCode5 = "rx";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "a2";
			subject.ProductServiceID2 = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
