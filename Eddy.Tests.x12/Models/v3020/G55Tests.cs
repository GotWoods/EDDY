using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G55Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G55*MP*J*Jt*x*5*3k*7*IX*1*Jy*1*G9*3*6*jI*q*j*hZH*5*3*j*p*2*7*7*6*D*b*uM*H*C";

		var expected = new G55_ItemCharacteristicsConsumerUnit()
		{
			ProductServiceIDQualifier = "MP",
			ProductServiceID = "J",
			ProductServiceIDQualifier2 = "Jt",
			ProductServiceID2 = "x",
			Height = 5,
			UnitOfMeasurementCode = "3k",
			Width = 7,
			UnitOfMeasurementCode2 = "IX",
			Length = 1,
			UnitOfMeasurementCode3 = "Jy",
			Volume = 1,
			UnitOfMeasurementCode4 = "G9",
			Pack = 3,
			Size = 6,
			UnitOfMeasurementCode5 = "jI",
			CashRegisterItemDescription = "q",
			CashRegisterItemDescription2 = "j",
			CouponFamilyCode = "hZH",
			DatedProductNumberOfDays = 5,
			DepositValue = 3,
			PrePriceIndicator = "j",
			Color = "p",
			UnitWeight = 2,
			WeightQualifier = "7",
			WeightUnitQualifier = "7",
			UnitWeight2 = 6,
			WeightQualifier2 = "D",
			WeightUnitQualifier2 = "b",
			ProductServiceIDQualifier3 = "uM",
			ProductServiceID3 = "H",
			FreeFormDescription = "C",
		};

		var actual = Map.MapObject<G55_ItemCharacteristicsConsumerUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MP", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceID = "J";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Jt";
			subject.ProductServiceID2 = "x";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOfMeasurementCode = "3k";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOfMeasurementCode2 = "IX";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOfMeasurementCode3 = "Jy";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode4 = "G9";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 6;
			subject.UnitOfMeasurementCode5 = "jI";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "uM";
			subject.ProductServiceID3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "MP";
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Jt";
			subject.ProductServiceID2 = "x";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOfMeasurementCode = "3k";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOfMeasurementCode2 = "IX";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOfMeasurementCode3 = "Jy";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode4 = "G9";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 6;
			subject.UnitOfMeasurementCode5 = "jI";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "uM";
			subject.ProductServiceID3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Jt", "x", true)]
	[InlineData("Jt", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "MP";
		subject.ProductServiceID = "J";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOfMeasurementCode = "3k";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOfMeasurementCode2 = "IX";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOfMeasurementCode3 = "Jy";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode4 = "G9";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 6;
			subject.UnitOfMeasurementCode5 = "jI";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "uM";
			subject.ProductServiceID3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "3k", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "3k", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "MP";
		subject.ProductServiceID = "J";
		if (height > 0)
			subject.Height = height;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Jt";
			subject.ProductServiceID2 = "x";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOfMeasurementCode2 = "IX";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOfMeasurementCode3 = "Jy";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode4 = "G9";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 6;
			subject.UnitOfMeasurementCode5 = "jI";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "uM";
			subject.ProductServiceID3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "IX", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "IX", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "MP";
		subject.ProductServiceID = "J";
		if (width > 0)
			subject.Width = width;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Jt";
			subject.ProductServiceID2 = "x";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOfMeasurementCode = "3k";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOfMeasurementCode3 = "Jy";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode4 = "G9";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 6;
			subject.UnitOfMeasurementCode5 = "jI";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "uM";
			subject.ProductServiceID3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Jy", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Jy", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "MP";
		subject.ProductServiceID = "J";
		if (length > 0)
			subject.Length = length;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Jt";
			subject.ProductServiceID2 = "x";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOfMeasurementCode = "3k";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOfMeasurementCode2 = "IX";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode4 = "G9";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 6;
			subject.UnitOfMeasurementCode5 = "jI";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "uM";
			subject.ProductServiceID3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "G9", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "G9", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode4, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "MP";
		subject.ProductServiceID = "J";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOfMeasurementCode4 = unitOfMeasurementCode4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Jt";
			subject.ProductServiceID2 = "x";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOfMeasurementCode = "3k";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOfMeasurementCode2 = "IX";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOfMeasurementCode3 = "Jy";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 6;
			subject.UnitOfMeasurementCode5 = "jI";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "uM";
			subject.ProductServiceID3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "jI", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "jI", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOfMeasurementCode5, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "MP";
		subject.ProductServiceID = "J";
		if (size > 0)
			subject.Size = size;
		subject.UnitOfMeasurementCode5 = unitOfMeasurementCode5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Jt";
			subject.ProductServiceID2 = "x";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOfMeasurementCode = "3k";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOfMeasurementCode2 = "IX";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOfMeasurementCode3 = "Jy";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode4 = "G9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "uM";
			subject.ProductServiceID3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uM", "H", true)]
	[InlineData("uM", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "MP";
		subject.ProductServiceID = "J";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Jt";
			subject.ProductServiceID2 = "x";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 5;
			subject.UnitOfMeasurementCode = "3k";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 7;
			subject.UnitOfMeasurementCode2 = "IX";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 1;
			subject.UnitOfMeasurementCode3 = "Jy";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode4 = "G9";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 6;
			subject.UnitOfMeasurementCode5 = "jI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
