using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G39Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G39*sUr91NbzE8SA*PG*Y*oK*9*Q*T*5*qV*9*NB*5*1k*8*9m*957148*4*7*Cb*A*9*I*Vu*4*x*4*1*Ts1";

		var expected = new G39_ItemCharacteristicsVendorsSellingUnit()
		{
			UPCCaseCode = "sUr91NbzE8SA",
			ProductServiceIDQualifier = "PG",
			ProductServiceID = "Y",
			SpecialHandlingCode = "oK",
			UnitWeight = 9,
			WeightQualifier = "Q",
			WeightUnitCode = "T",
			Height = 5,
			UnitOrBasisForMeasurementCode = "qV",
			Width = 9,
			UnitOrBasisForMeasurementCode2 = "NB",
			Length = 5,
			UnitOrBasisForMeasurementCode3 = "1k",
			Volume = 8,
			UnitOrBasisForMeasurementCode4 = "9m",
			PalletBlockAndTiers = 957148,
			Pack = 4,
			Size = 7,
			UnitOrBasisForMeasurementCode5 = "Cb",
			Color = "A",
			OrderSizingFactor = 9,
			AlternateTiersPerPallet = "I",
			ProductServiceIDQualifier2 = "Vu",
			ProductServiceID2 = "4",
			WeightQualifier2 = "x",
			UnitWeight2 = 4,
			InnerPack = 1,
			PackagingCode = "Ts1",
		};

		var actual = Map.MapObject<G39_ItemCharacteristicsVendorsSellingUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("sUr91NbzE8SA", "PG", true)]
	[InlineData("sUr91NbzE8SA", "", true)]
	[InlineData("", "PG", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PG";
			subject.ProductServiceID = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "Q";
			subject.WeightUnitCode = "T";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "qV";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "NB";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode3 = "1k";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "9m";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "Cb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Vu";
			subject.ProductServiceID2 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "x";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PG", "Y", true)]
	[InlineData("PG", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "sUr91NbzE8SA";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "Q";
			subject.WeightUnitCode = "T";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "qV";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "NB";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode3 = "1k";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "9m";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "Cb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Vu";
			subject.ProductServiceID2 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "x";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "T", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, string weightUnitCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier = weightQualifier;
		subject.WeightUnitCode = weightUnitCode;
			subject.UPCCaseCode = "sUr91NbzE8SA";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PG";
			subject.ProductServiceID = "Y";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "qV";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "NB";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode3 = "1k";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "9m";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "Cb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Vu";
			subject.ProductServiceID2 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "x";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "qV", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "qV", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (height > 0)
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "sUr91NbzE8SA";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PG";
			subject.ProductServiceID = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "Q";
			subject.WeightUnitCode = "T";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "NB";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode3 = "1k";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "9m";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "Cb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Vu";
			subject.ProductServiceID2 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "x";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "NB", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "NB", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (width > 0)
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "sUr91NbzE8SA";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PG";
			subject.ProductServiceID = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "Q";
			subject.WeightUnitCode = "T";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "qV";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode3 = "1k";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "9m";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "Cb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Vu";
			subject.ProductServiceID2 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "x";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "1k", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "1k", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (length > 0)
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCCaseCode = "sUr91NbzE8SA";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PG";
			subject.ProductServiceID = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "Q";
			subject.WeightUnitCode = "T";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "qV";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "NB";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "9m";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "Cb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Vu";
			subject.ProductServiceID2 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "x";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "9m", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "9m", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
			subject.UPCCaseCode = "sUr91NbzE8SA";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PG";
			subject.ProductServiceID = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "Q";
			subject.WeightUnitCode = "T";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "qV";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "NB";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode3 = "1k";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "Cb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Vu";
			subject.ProductServiceID2 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "x";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Cb", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Cb", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
			subject.UPCCaseCode = "sUr91NbzE8SA";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PG";
			subject.ProductServiceID = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "Q";
			subject.WeightUnitCode = "T";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "qV";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "NB";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode3 = "1k";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "9m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Vu";
			subject.ProductServiceID2 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "x";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vu", "4", true)]
	[InlineData("Vu", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "sUr91NbzE8SA";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PG";
			subject.ProductServiceID = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "Q";
			subject.WeightUnitCode = "T";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "qV";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "NB";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode3 = "1k";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "9m";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "Cb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier2) || !string.IsNullOrEmpty(subject.WeightQualifier2) || subject.UnitWeight2 > 0)
		{
			subject.WeightQualifier2 = "x";
			subject.UnitWeight2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("x", 4, true)]
	[InlineData("x", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredWeightQualifier2(string weightQualifier2, decimal unitWeight2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier2 = weightQualifier2;
		if (unitWeight2 > 0)
			subject.UnitWeight2 = unitWeight2;
			subject.UPCCaseCode = "sUr91NbzE8SA";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PG";
			subject.ProductServiceID = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightQualifier = "Q";
			subject.WeightUnitCode = "T";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode = "qV";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 9;
			subject.UnitOrBasisForMeasurementCode2 = "NB";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode3 = "1k";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode4 = "9m";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 7;
			subject.UnitOrBasisForMeasurementCode5 = "Cb";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Vu";
			subject.ProductServiceID2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
