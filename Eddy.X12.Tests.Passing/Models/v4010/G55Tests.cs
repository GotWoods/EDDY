using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G55Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G55*PH*N*1L*8*3*Qn*4*dK*1*00*5*LR*2*3*4G*W*3*g9b*4*5*z*M*5*7*O*1*0*F*G1*r*Y*3*1rh";

		var expected = new G55_ItemCharacteristicsConsumerUnit()
		{
			ProductServiceIDQualifier = "PH",
			ProductServiceID = "N",
			ProductServiceIDQualifier2 = "1L",
			ProductServiceID2 = "8",
			Height = 3,
			UnitOrBasisForMeasurementCode = "Qn",
			Width = 4,
			UnitOrBasisForMeasurementCode2 = "dK",
			Length = 1,
			UnitOrBasisForMeasurementCode3 = "00",
			Volume = 5,
			UnitOrBasisForMeasurementCode4 = "LR",
			Pack = 2,
			Size = 3,
			UnitOrBasisForMeasurementCode5 = "4G",
			CashRegisterItemDescription = "W",
			CashRegisterItemDescription2 = "3",
			CouponFamilyCode = "g9b",
			DatedProductNumberOfDays = 4,
			DepositValue = 5,
			YesNoConditionOrResponseCode = "z",
			Color = "M",
			UnitWeight = 5,
			WeightQualifier = "7",
			WeightUnitCode = "O",
			UnitWeight2 = 1,
			WeightQualifier2 = "0",
			WeightUnitCode2 = "F",
			ProductServiceIDQualifier3 = "G1",
			ProductServiceID3 = "r",
			FreeFormDescription = "Y",
			InnerPack = 3,
			PackagingCode = "1rh",
		};

		var actual = Map.MapObject<G55_ItemCharacteristicsConsumerUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PH", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "1L";
			subject.ProductServiceID2 = "8";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 3;
			subject.UnitOrBasisForMeasurementCode = "Qn";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 4;
			subject.UnitOrBasisForMeasurementCode2 = "dK";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "00";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode4 = "LR";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode5 = "4G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "G1";
			subject.ProductServiceID3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "PH";
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "1L";
			subject.ProductServiceID2 = "8";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 3;
			subject.UnitOrBasisForMeasurementCode = "Qn";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 4;
			subject.UnitOrBasisForMeasurementCode2 = "dK";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "00";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode4 = "LR";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode5 = "4G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "G1";
			subject.ProductServiceID3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1L", "8", true)]
	[InlineData("1L", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "PH";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 3;
			subject.UnitOrBasisForMeasurementCode = "Qn";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 4;
			subject.UnitOrBasisForMeasurementCode2 = "dK";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "00";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode4 = "LR";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode5 = "4G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "G1";
			subject.ProductServiceID3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Qn", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Qn", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "PH";
		subject.ProductServiceID = "N";
		if (height > 0)
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "1L";
			subject.ProductServiceID2 = "8";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 4;
			subject.UnitOrBasisForMeasurementCode2 = "dK";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "00";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode4 = "LR";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode5 = "4G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "G1";
			subject.ProductServiceID3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "dK", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "dK", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "PH";
		subject.ProductServiceID = "N";
		if (width > 0)
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "1L";
			subject.ProductServiceID2 = "8";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 3;
			subject.UnitOrBasisForMeasurementCode = "Qn";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "00";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode4 = "LR";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode5 = "4G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "G1";
			subject.ProductServiceID3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "00", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "00", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "PH";
		subject.ProductServiceID = "N";
		if (length > 0)
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "1L";
			subject.ProductServiceID2 = "8";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 3;
			subject.UnitOrBasisForMeasurementCode = "Qn";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 4;
			subject.UnitOrBasisForMeasurementCode2 = "dK";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode4 = "LR";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode5 = "4G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "G1";
			subject.ProductServiceID3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "LR", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "LR", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "PH";
		subject.ProductServiceID = "N";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "1L";
			subject.ProductServiceID2 = "8";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 3;
			subject.UnitOrBasisForMeasurementCode = "Qn";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 4;
			subject.UnitOrBasisForMeasurementCode2 = "dK";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "00";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode5 = "4G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "G1";
			subject.ProductServiceID3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "4G", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "4G", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "PH";
		subject.ProductServiceID = "N";
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "1L";
			subject.ProductServiceID2 = "8";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 3;
			subject.UnitOrBasisForMeasurementCode = "Qn";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 4;
			subject.UnitOrBasisForMeasurementCode2 = "dK";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "00";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode4 = "LR";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "G1";
			subject.ProductServiceID3 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G1", "r", true)]
	[InlineData("G1", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "PH";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "1L";
			subject.ProductServiceID2 = "8";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Height = 3;
			subject.UnitOrBasisForMeasurementCode = "Qn";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 4;
			subject.UnitOrBasisForMeasurementCode2 = "dK";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode3 = "00";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode4 = "LR";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode5 = "4G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
