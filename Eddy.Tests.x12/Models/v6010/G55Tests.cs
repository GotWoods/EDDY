using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class G55Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G55*V2*I*JD*0*1*Rg*7*rH*6*To*6*yZ*7*4*N5*n*E*DNF*6*6*v*G*5*f*A*3*K*y*LR*2*n*3*j7d";

		var expected = new G55_ItemCharacteristicsConsumerUnit()
		{
			ProductServiceIDQualifier = "V2",
			ProductServiceID = "I",
			ProductServiceIDQualifier2 = "JD",
			ProductServiceID2 = "0",
			Height = 1,
			UnitOrBasisForMeasurementCode = "Rg",
			Width = 7,
			UnitOrBasisForMeasurementCode2 = "rH",
			Length = 6,
			UnitOrBasisForMeasurementCode3 = "To",
			Volume = 6,
			UnitOrBasisForMeasurementCode4 = "yZ",
			Pack = 7,
			Size = 4,
			UnitOrBasisForMeasurementCode5 = "N5",
			CashRegisterItemDescription = "n",
			CashRegisterItemDescription2 = "E",
			CouponFamilyCode = "DNF",
			DatedProductNumberOfDays = 6,
			DepositValue = 6,
			YesNoConditionOrResponseCode = "v",
			Color = "G",
			UnitWeight = 5,
			WeightQualifier = "f",
			WeightUnitCode = "A",
			UnitWeight2 = 3,
			WeightQualifier2 = "K",
			WeightUnitCode2 = "y",
			ProductServiceIDQualifier3 = "LR",
			ProductServiceID3 = "2",
			FreeFormDescription = "n",
			InnerPack = 3,
			PackagingCode = "j7d",
		};

		var actual = Map.MapObject<G55_ItemCharacteristicsConsumerUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V2", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceID = "I";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "JD";
			subject.ProductServiceID2 = "0";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode = "Rg";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOrBasisForMeasurementCode2 = "rH";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 6;
			subject.UnitOrBasisForMeasurementCode3 = "To";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode4 = "yZ";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode5 = "N5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "LR";
			subject.ProductServiceID3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "V2";
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "JD";
			subject.ProductServiceID2 = "0";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode = "Rg";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOrBasisForMeasurementCode2 = "rH";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 6;
			subject.UnitOrBasisForMeasurementCode3 = "To";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode4 = "yZ";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode5 = "N5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "LR";
			subject.ProductServiceID3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JD", "0", true)]
	[InlineData("JD", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "V2";
		subject.ProductServiceID = "I";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode = "Rg";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOrBasisForMeasurementCode2 = "rH";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 6;
			subject.UnitOrBasisForMeasurementCode3 = "To";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode4 = "yZ";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode5 = "N5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "LR";
			subject.ProductServiceID3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Rg", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Rg", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "V2";
		subject.ProductServiceID = "I";
		if (height > 0)
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "JD";
			subject.ProductServiceID2 = "0";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOrBasisForMeasurementCode2 = "rH";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 6;
			subject.UnitOrBasisForMeasurementCode3 = "To";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode4 = "yZ";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode5 = "N5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "LR";
			subject.ProductServiceID3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "rH", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "rH", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "V2";
		subject.ProductServiceID = "I";
		if (width > 0)
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "JD";
			subject.ProductServiceID2 = "0";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode = "Rg";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 6;
			subject.UnitOrBasisForMeasurementCode3 = "To";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode4 = "yZ";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode5 = "N5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "LR";
			subject.ProductServiceID3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "To", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "To", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "V2";
		subject.ProductServiceID = "I";
		if (length > 0)
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "JD";
			subject.ProductServiceID2 = "0";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode = "Rg";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOrBasisForMeasurementCode2 = "rH";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode4 = "yZ";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode5 = "N5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "LR";
			subject.ProductServiceID3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "yZ", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "yZ", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "V2";
		subject.ProductServiceID = "I";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "JD";
			subject.ProductServiceID2 = "0";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode = "Rg";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOrBasisForMeasurementCode2 = "rH";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 6;
			subject.UnitOrBasisForMeasurementCode3 = "To";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode5 = "N5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "LR";
			subject.ProductServiceID3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "N5", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "N5", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "V2";
		subject.ProductServiceID = "I";
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "JD";
			subject.ProductServiceID2 = "0";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode = "Rg";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOrBasisForMeasurementCode2 = "rH";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 6;
			subject.UnitOrBasisForMeasurementCode3 = "To";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode4 = "yZ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "LR";
			subject.ProductServiceID3 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LR", "2", true)]
	[InlineData("LR", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "V2";
		subject.ProductServiceID = "I";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "JD";
			subject.ProductServiceID2 = "0";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode = "Rg";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOrBasisForMeasurementCode2 = "rH";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 6;
			subject.UnitOrBasisForMeasurementCode3 = "To";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode4 = "yZ";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode5 = "N5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
