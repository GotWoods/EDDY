using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ID1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID1*2tHLuongHAZt*d9*E*K*3*Id*4*8*4*Hx*9*MJ*H*X*U*to*9*8*Zu*IjMHTG*n*3*Gr*N*65*v*3*4*J*1*3*t*8*9";

		var expected = new ID1_ItemDetailDimensions()
		{
			UPCEANConsumerPackageCode = "2tHLuongHAZt",
			ProductServiceIDQualifier = "d9",
			ProductServiceID = "E",
			FreeFormDescription = "K",
			Size = 3,
			UnitOfMeasurementCode = "Id",
			Height = 4,
			Width = 8,
			ItemDepth = 4,
			UnitOfMeasurementCode2 = "Hx",
			Weight = 9,
			UnitOfMeasurementCode3 = "MJ",
			CategoryReferenceCode = "H",
			Category = "X",
			Subcategory = "U",
			UnitOfMeasurementCode4 = "to",
			Pack = 9,
			InnerPack = 8,
			DateQualifier = "Zu",
			Date = "IjMHTG",
			NestingCode = "n",
			Nesting = 3,
			UnitOfMeasurementCode5 = "Gr",
			PegCode = "N",
			UnitOfMeasurementCode6 = "65",
			ReferenceNumber = "v",
			XPeg = 3,
			YPeg = 4,
			ReferenceNumber2 = "J",
			XPeg2 = 1,
			YPeg2 = 3,
			ReferenceNumber3 = "t",
			XPeg3 = 8,
			YPeg3 = 9,
		};

		var actual = Map.MapObject<ID1_ItemDetailDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("2tHLuongHAZt", "d9", true)]
	[InlineData("2tHLuongHAZt", "", true)]
	[InlineData("", "d9", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d9", "E", true)]
	[InlineData("d9", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		subject.FreeFormDescription = freeFormDescription;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredSize(decimal size, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		if (size > 0)
			subject.Size = size;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Id", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		if (height > 0)
			subject.Height = height;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		if (width > 0)
			subject.Width = width;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredItemDepth(decimal itemDepth, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.UnitOfMeasurementCode2 = "Hx";
		if (itemDepth > 0)
			subject.ItemDepth = itemDepth;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hx", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "MJ", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "MJ", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "X", true)]
	[InlineData("H", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredCategoryReferenceCode(string categoryReferenceCode, string category, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		subject.CategoryReferenceCode = categoryReferenceCode;
		subject.Category = category;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Zu", "IjMHTG", true)]
	[InlineData("Zu", "", false)]
	[InlineData("", "IjMHTG", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "65", true)]
	[InlineData("v", "", false)]
	[InlineData("", "65", true)]
	public void Validation_ARequiresBReferenceNumber(string referenceNumber, string unitOfMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		subject.ReferenceNumber = referenceNumber;
		subject.UnitOfMeasurementCode6 = unitOfMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "65", true)]
	[InlineData("J", "", false)]
	[InlineData("", "65", true)]
	public void Validation_ARequiresBReferenceNumber2(string referenceNumber2, string unitOfMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		subject.ReferenceNumber2 = referenceNumber2;
		subject.UnitOfMeasurementCode6 = unitOfMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "65", true)]
	[InlineData("t", "", false)]
	[InlineData("", "65", true)]
	public void Validation_ARequiresBReferenceNumber3(string referenceNumber3, string unitOfMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "K";
		subject.Size = 3;
		subject.UnitOfMeasurementCode = "Id";
		subject.Height = 4;
		subject.Width = 8;
		subject.ItemDepth = 4;
		subject.UnitOfMeasurementCode2 = "Hx";
		subject.ReferenceNumber3 = referenceNumber3;
		subject.UnitOfMeasurementCode6 = unitOfMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "2tHLuongHAZt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d9";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Weight = 9;
			subject.UnitOfMeasurementCode3 = "MJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "H";
			subject.Category = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Zu";
			subject.Date = "IjMHTG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
