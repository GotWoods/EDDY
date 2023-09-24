using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class G39Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G39*ppQktD3f4Dvi*g7*Z*1R*3*E*c*5*9f*6*fu*2*mN*2*16*526148*3*2*2Y*b*2*4*k6*V*m*3*2*Lkc*0";

		var expected = new G39_ItemCharacteristicsVendorsSellingUnit()
		{
			UPCCaseCode = "ppQktD3f4Dvi",
			ProductServiceIDQualifier = "g7",
			ProductServiceID = "Z",
			SpecialHandlingCode = "1R",
			UnitWeight = 3,
			WeightQualifier = "E",
			WeightUnitCode = "c",
			Height = 5,
			UnitOrBasisForMeasurementCode = "9f",
			Width = 6,
			UnitOrBasisForMeasurementCode2 = "fu",
			Length = 2,
			UnitOrBasisForMeasurementCode3 = "mN",
			Volume = 2,
			UnitOrBasisForMeasurementCode4 = "16",
			PalletBlockAndTiers = 526148,
			Pack = 3,
			Size = 2,
			UnitOrBasisForMeasurementCode5 = "2Y",
			Color = "b",
			OrderSizingFactor = 2,
			AlternateTiersPerPallet = 4,
			ProductServiceIDQualifier2 = "k6",
			ProductServiceID2 = "V",
			WeightQualifier2 = "m",
			UnitWeight2 = 3,
			InnerPack = 2,
			PackagingCode = "Lkc",
			CashRegisterItemDescription = "0",
		};

		var actual = Map.MapObject<G39_ItemCharacteristicsVendorsSellingUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ppQktD3f4Dvi", "g7", true)]
	[InlineData("ppQktD3f4Dvi", "", true)]
	[InlineData("", "g7", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "g7";
			subject.ProductServiceID = "Z";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "9f";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 6;
			subject.UnitOrBasisForMeasurementCode2 = "fu";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 2;
			subject.UnitOrBasisForMeasurementCode3 = "mN";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode4 = "16";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode5 = "2Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "k6";
			subject.ProductServiceID2 = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "m";
			subject.UnitWeight2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g7", "Z", true)]
	[InlineData("g7", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "ppQktD3f4Dvi";
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "9f";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 6;
			subject.UnitOrBasisForMeasurementCode2 = "fu";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 2;
			subject.UnitOrBasisForMeasurementCode3 = "mN";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode4 = "16";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode5 = "2Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "k6";
			subject.ProductServiceID2 = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "m";
			subject.UnitWeight2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "9f", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "9f", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (height > 0)
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "ppQktD3f4Dvi";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "g7";
			subject.ProductServiceID = "Z";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 6;
			subject.UnitOrBasisForMeasurementCode2 = "fu";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 2;
			subject.UnitOrBasisForMeasurementCode3 = "mN";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode4 = "16";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode5 = "2Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "k6";
			subject.ProductServiceID2 = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "m";
			subject.UnitWeight2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "fu", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "fu", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (width > 0)
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "ppQktD3f4Dvi";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "g7";
			subject.ProductServiceID = "Z";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "9f";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 2;
			subject.UnitOrBasisForMeasurementCode3 = "mN";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode4 = "16";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode5 = "2Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "k6";
			subject.ProductServiceID2 = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "m";
			subject.UnitWeight2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "mN", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "mN", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (length > 0)
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCCaseCode = "ppQktD3f4Dvi";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "g7";
			subject.ProductServiceID = "Z";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "9f";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 6;
			subject.UnitOrBasisForMeasurementCode2 = "fu";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode4 = "16";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode5 = "2Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "k6";
			subject.ProductServiceID2 = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "m";
			subject.UnitWeight2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "16", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "16", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
			subject.UPCCaseCode = "ppQktD3f4Dvi";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "g7";
			subject.ProductServiceID = "Z";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "9f";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 6;
			subject.UnitOrBasisForMeasurementCode2 = "fu";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 2;
			subject.UnitOrBasisForMeasurementCode3 = "mN";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode5 = "2Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "k6";
			subject.ProductServiceID2 = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "m";
			subject.UnitWeight2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "2Y", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "2Y", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
			subject.UPCCaseCode = "ppQktD3f4Dvi";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "g7";
			subject.ProductServiceID = "Z";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "9f";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 6;
			subject.UnitOrBasisForMeasurementCode2 = "fu";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 2;
			subject.UnitOrBasisForMeasurementCode3 = "mN";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode4 = "16";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "k6";
			subject.ProductServiceID2 = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "m";
			subject.UnitWeight2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k6", "V", true)]
	[InlineData("k6", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "ppQktD3f4Dvi";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "g7";
			subject.ProductServiceID = "Z";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "9f";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 6;
			subject.UnitOrBasisForMeasurementCode2 = "fu";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 2;
			subject.UnitOrBasisForMeasurementCode3 = "mN";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode4 = "16";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode5 = "2Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "m";
			subject.UnitWeight2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("m", 3, true)]
	[InlineData("m", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredWeightQualifier2(string weightQualifier2, decimal unitWeight2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier2 = weightQualifier2;
		if (unitWeight2 > 0)
			subject.UnitWeight2 = unitWeight2;
			subject.UPCCaseCode = "ppQktD3f4Dvi";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "g7";
			subject.ProductServiceID = "Z";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "9f";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 6;
			subject.UnitOrBasisForMeasurementCode2 = "fu";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 2;
			subject.UnitOrBasisForMeasurementCode3 = "mN";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode4 = "16";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 2;
			subject.UnitOrBasisForMeasurementCode5 = "2Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "k6";
			subject.ProductServiceID2 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
