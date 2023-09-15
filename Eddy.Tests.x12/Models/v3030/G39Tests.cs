using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G39Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G39*ULgFU1D6g5IR*rb*8*dX*4*q*r*4*I0*2*JU*1*Fa*4*82*821915*6*7*x8*p*2*R*eS*A*3*8";

		var expected = new G39_ItemCharacteristicsVendorsSellingUnit()
		{
			UPCCaseCode = "ULgFU1D6g5IR",
			ProductServiceIDQualifier = "rb",
			ProductServiceID = "8",
			SpecialHandlingCode = "dX",
			UnitWeight = 4,
			WeightQualifier = "q",
			WeightUnitCode = "r",
			Height = 4,
			UnitOrBasisForMeasurementCode = "I0",
			Width = 2,
			UnitOrBasisForMeasurementCode2 = "JU",
			Length = 1,
			UnitOrBasisForMeasurementCode3 = "Fa",
			Volume = 4,
			UnitOrBasisForMeasurementCode4 = "82",
			PalletBlockAndTiers = 821915,
			Pack = 6,
			Size = 7,
			UnitOrBasisForMeasurementCode5 = "x8",
			Color = "p",
			EquivalentWeight = 2,
			AlternateTiersPerPallet = "R",
			ProductServiceIDQualifier2 = "eS",
			ProductServiceID2 = "A",
			WeightQualifier2 = "3",
			UnitWeight2 = 8,
		};

		var actual = Map.MapObject<G39_ItemCharacteristicsVendorsSellingUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ULgFU1D6g5IR", "rb", true)]
	[InlineData("ULgFU1D6g5IR", "", true)]
	[InlineData("", "rb", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rb";
			subject.ProductServiceID = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "q";
			subject.WeightUnitCode = "r";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode = "I0";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 2;
			subject.UnitOrBasisForMeasurementCode2 = "JU";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Fa";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode4 = "82";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "x8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "eS";
			subject.ProductServiceID2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "3";
			subject.UnitWeight2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rb", "8", true)]
	[InlineData("rb", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "ULgFU1D6g5IR";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "q";
			subject.WeightUnitCode = "r";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode = "I0";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 2;
			subject.UnitOrBasisForMeasurementCode2 = "JU";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Fa";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode4 = "82";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "x8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "eS";
			subject.ProductServiceID2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "3";
			subject.UnitWeight2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "r", true)]
	[InlineData("q", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, string weightUnitCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier = weightQualifier;
		subject.WeightUnitCode = weightUnitCode;
			subject.UPCCaseCode = "ULgFU1D6g5IR";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rb";
			subject.ProductServiceID = "8";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode = "I0";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 2;
			subject.UnitOrBasisForMeasurementCode2 = "JU";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Fa";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode4 = "82";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "x8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "eS";
			subject.ProductServiceID2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "3";
			subject.UnitWeight2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "I0", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "I0", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (height > 0)
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "ULgFU1D6g5IR";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rb";
			subject.ProductServiceID = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "q";
			subject.WeightUnitCode = "r";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 2;
			subject.UnitOrBasisForMeasurementCode2 = "JU";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Fa";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode4 = "82";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "x8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "eS";
			subject.ProductServiceID2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "3";
			subject.UnitWeight2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "JU", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "JU", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (width > 0)
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "ULgFU1D6g5IR";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rb";
			subject.ProductServiceID = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "q";
			subject.WeightUnitCode = "r";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode = "I0";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Fa";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode4 = "82";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "x8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "eS";
			subject.ProductServiceID2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "3";
			subject.UnitWeight2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Fa", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Fa", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (length > 0)
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCCaseCode = "ULgFU1D6g5IR";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rb";
			subject.ProductServiceID = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "q";
			subject.WeightUnitCode = "r";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode = "I0";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 2;
			subject.UnitOrBasisForMeasurementCode2 = "JU";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode4 = "82";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "x8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "eS";
			subject.ProductServiceID2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "3";
			subject.UnitWeight2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "82", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "82", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
			subject.UPCCaseCode = "ULgFU1D6g5IR";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rb";
			subject.ProductServiceID = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "q";
			subject.WeightUnitCode = "r";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode = "I0";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 2;
			subject.UnitOrBasisForMeasurementCode2 = "JU";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Fa";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "x8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "eS";
			subject.ProductServiceID2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "3";
			subject.UnitWeight2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "x8", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "x8", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
			subject.UPCCaseCode = "ULgFU1D6g5IR";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rb";
			subject.ProductServiceID = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "q";
			subject.WeightUnitCode = "r";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode = "I0";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 2;
			subject.UnitOrBasisForMeasurementCode2 = "JU";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Fa";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode4 = "82";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "eS";
			subject.ProductServiceID2 = "A";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "3";
			subject.UnitWeight2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eS", "A", true)]
	[InlineData("eS", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "ULgFU1D6g5IR";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rb";
			subject.ProductServiceID = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "q";
			subject.WeightUnitCode = "r";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode = "I0";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 2;
			subject.UnitOrBasisForMeasurementCode2 = "JU";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Fa";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode4 = "82";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "x8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "3";
			subject.UnitWeight2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("3", 8, true)]
	[InlineData("3", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredWeightQualifier2(string weightQualifier2, decimal unitWeight2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier2 = weightQualifier2;
		if (unitWeight2 > 0)
			subject.UnitWeight2 = unitWeight2;
			subject.UPCCaseCode = "ULgFU1D6g5IR";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rb";
			subject.ProductServiceID = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "q";
			subject.WeightUnitCode = "r";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 4;
			subject.UnitOrBasisForMeasurementCode = "I0";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 2;
			subject.UnitOrBasisForMeasurementCode2 = "JU";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Fa";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode4 = "82";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "x8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "eS";
			subject.ProductServiceID2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
