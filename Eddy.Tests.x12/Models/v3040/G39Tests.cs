using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class G39Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G39*3JAm3sTEb5Qd*HH*9*CO*8*z*h*8*5o*1*Ng*1*3n*1*Sw*239736*7*8*GV*0*7*c*WK*2*N*4*4";

		var expected = new G39_ItemCharacteristicsVendorsSellingUnit()
		{
			UPCCaseCode = "3JAm3sTEb5Qd",
			ProductServiceIDQualifier = "HH",
			ProductServiceID = "9",
			SpecialHandlingCode = "CO",
			UnitWeight = 8,
			WeightQualifier = "z",
			WeightUnitCode = "h",
			Height = 8,
			UnitOrBasisForMeasurementCode = "5o",
			Width = 1,
			UnitOrBasisForMeasurementCode2 = "Ng",
			Length = 1,
			UnitOrBasisForMeasurementCode3 = "3n",
			Volume = 1,
			UnitOrBasisForMeasurementCode4 = "Sw",
			PalletBlockAndTiers = 239736,
			Pack = 7,
			Size = 8,
			UnitOrBasisForMeasurementCode5 = "GV",
			Color = "0",
			EquivalentWeight = 7,
			AlternateTiersPerPallet = "c",
			ProductServiceIDQualifier2 = "WK",
			ProductServiceID2 = "2",
			WeightQualifier2 = "N",
			UnitWeight2 = 4,
			InnerPack = 4,
		};

		var actual = Map.MapObject<G39_ItemCharacteristicsVendorsSellingUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("3JAm3sTEb5Qd", "HH", true)]
	[InlineData("3JAm3sTEb5Qd", "", true)]
	[InlineData("", "HH", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "HH";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "z";
			subject.WeightUnitCode = "h";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode = "5o";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Ng";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "3n";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Sw";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 8;
			subject.UnitOrBasisForMeasurementCode5 = "GV";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WK";
			subject.ProductServiceID2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "N";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HH", "9", true)]
	[InlineData("HH", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "3JAm3sTEb5Qd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "z";
			subject.WeightUnitCode = "h";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode = "5o";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Ng";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "3n";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Sw";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 8;
			subject.UnitOrBasisForMeasurementCode5 = "GV";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WK";
			subject.ProductServiceID2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "N";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "h", true)]
	[InlineData("z", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, string weightUnitCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier = weightQualifier;
		subject.WeightUnitCode = weightUnitCode;
			subject.UPCCaseCode = "3JAm3sTEb5Qd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "HH";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode = "5o";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Ng";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "3n";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Sw";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 8;
			subject.UnitOrBasisForMeasurementCode5 = "GV";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WK";
			subject.ProductServiceID2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "N";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "5o", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "5o", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (height > 0)
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "3JAm3sTEb5Qd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "HH";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "z";
			subject.WeightUnitCode = "h";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Ng";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "3n";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Sw";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 8;
			subject.UnitOrBasisForMeasurementCode5 = "GV";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WK";
			subject.ProductServiceID2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "N";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Ng", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Ng", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (width > 0)
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "3JAm3sTEb5Qd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "HH";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "z";
			subject.WeightUnitCode = "h";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode = "5o";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "3n";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Sw";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 8;
			subject.UnitOrBasisForMeasurementCode5 = "GV";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WK";
			subject.ProductServiceID2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "N";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "3n", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "3n", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (length > 0)
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCCaseCode = "3JAm3sTEb5Qd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "HH";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "z";
			subject.WeightUnitCode = "h";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode = "5o";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Ng";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Sw";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 8;
			subject.UnitOrBasisForMeasurementCode5 = "GV";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WK";
			subject.ProductServiceID2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "N";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Sw", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Sw", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
			subject.UPCCaseCode = "3JAm3sTEb5Qd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "HH";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "z";
			subject.WeightUnitCode = "h";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode = "5o";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Ng";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "3n";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 8;
			subject.UnitOrBasisForMeasurementCode5 = "GV";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WK";
			subject.ProductServiceID2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "N";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "GV", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "GV", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
			subject.UPCCaseCode = "3JAm3sTEb5Qd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "HH";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "z";
			subject.WeightUnitCode = "h";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode = "5o";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Ng";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "3n";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Sw";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WK";
			subject.ProductServiceID2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "N";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WK", "2", true)]
	[InlineData("WK", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "3JAm3sTEb5Qd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "HH";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "z";
			subject.WeightUnitCode = "h";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode = "5o";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Ng";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "3n";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Sw";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 8;
			subject.UnitOrBasisForMeasurementCode5 = "GV";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "N";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("N", 4, true)]
	[InlineData("N", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredWeightQualifier2(string weightQualifier2, decimal unitWeight2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier2 = weightQualifier2;
		if (unitWeight2 > 0)
			subject.UnitWeight2 = unitWeight2;
			subject.UPCCaseCode = "3JAm3sTEb5Qd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "HH";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "z";
			subject.WeightUnitCode = "h";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode = "5o";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Ng";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "3n";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Sw";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 8;
			subject.UnitOrBasisForMeasurementCode5 = "GV";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WK";
			subject.ProductServiceID2 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
