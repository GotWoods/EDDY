using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ID1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID1*aoan4mMKHkS4*Zu*d*G*2*LS*5*1*7*9T*1*Ox*r*o*n*Rn*2*9*hN*tIlRET*n*5*lh*G*SR*V*7*2*j*9*2*j*7*9";

		var expected = new ID1_ItemDetailDimensions()
		{
			UPCEANConsumerPackageCode = "aoan4mMKHkS4",
			ProductServiceIDQualifier = "Zu",
			ProductServiceID = "d",
			FreeFormDescription = "G",
			Size = 2,
			UnitOrBasisForMeasurementCode = "LS",
			Height = 5,
			Width = 1,
			ItemDepth = 7,
			UnitOrBasisForMeasurementCode2 = "9T",
			Weight = 1,
			UnitOrBasisForMeasurementCode3 = "Ox",
			CategoryReferenceCode = "r",
			Category = "o",
			Subcategory = "n",
			UnitOrBasisForMeasurementCode4 = "Rn",
			Pack = 2,
			InnerPack = 9,
			DateQualifier = "hN",
			Date = "tIlRET",
			NestingCode = "n",
			Nesting = 5,
			UnitOrBasisForMeasurementCode5 = "lh",
			PegCode = "G",
			UnitOrBasisForMeasurementCode6 = "SR",
			ReferenceNumber = "V",
			XPeg = 7,
			YPeg = 2,
			ReferenceNumber2 = "j",
			XPeg2 = 9,
			YPeg2 = 2,
			ReferenceNumber3 = "j",
			XPeg3 = 7,
			YPeg3 = 9,
		};

		var actual = Map.MapObject<ID1_ItemDetailDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("aoan4mMKHkS4", "Zu", true)]
	[InlineData("aoan4mMKHkS4", "", true)]
	[InlineData("", "Zu", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Zu", "d", true)]
	[InlineData("Zu", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		subject.FreeFormDescription = freeFormDescription;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredSize(decimal size, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		if (size > 0)
			subject.Size = size;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LS", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		if (height > 0)
			subject.Height = height;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		if (width > 0)
			subject.Width = width;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredItemDepth(decimal itemDepth, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		if (itemDepth > 0)
			subject.ItemDepth = itemDepth;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9T", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Ox", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Ox", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "o", true)]
	[InlineData("r", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredCategoryReferenceCode(string categoryReferenceCode, string category, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		subject.CategoryReferenceCode = categoryReferenceCode;
		subject.Category = category;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hN", "tIlRET", true)]
	[InlineData("hN", "", false)]
	[InlineData("", "tIlRET", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "SR", true)]
	[InlineData("V", "", false)]
	[InlineData("", "SR", true)]
	public void Validation_ARequiresBReferenceNumber(string referenceNumber, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		subject.ReferenceNumber = referenceNumber;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "SR", true)]
	[InlineData("j", "", false)]
	[InlineData("", "SR", true)]
	public void Validation_ARequiresBReferenceNumber2(string referenceNumber2, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		subject.ReferenceNumber2 = referenceNumber2;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "SR", true)]
	[InlineData("j", "", false)]
	[InlineData("", "SR", true)]
	public void Validation_ARequiresBReferenceNumber3(string referenceNumber3, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "G";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "LS";
		subject.Height = 5;
		subject.Width = 1;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "9T";
		subject.ReferenceNumber3 = referenceNumber3;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "aoan4mMKHkS4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zu";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Ox";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "r";
			subject.Category = "o";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "hN";
			subject.Date = "tIlRET";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
