using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ID1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID1*0llTqYyXF9Nd*nY*m*D*2*e9*3*5*2*Zb*4*Xd*7*w*1*Tv*2*9*58*kMUFn8uD*o*9*US*U*J2*j*8*2*q*9*9*k*6*5";

		var expected = new ID1_ItemDetailDimensions()
		{
			UPCEANConsumerPackageCode = "0llTqYyXF9Nd",
			ProductServiceIDQualifier = "nY",
			ProductServiceID = "m",
			FreeFormDescription = "D",
			Size = 2,
			UnitOrBasisForMeasurementCode = "e9",
			Height = 3,
			Width = 5,
			ItemDepth = 2,
			UnitOrBasisForMeasurementCode2 = "Zb",
			Weight = 4,
			UnitOrBasisForMeasurementCode3 = "Xd",
			CategoryReferenceCode = "7",
			Category = "w",
			Subcategory = "1",
			UnitOrBasisForMeasurementCode4 = "Tv",
			Pack = 2,
			InnerPack = 9,
			DateQualifier = "58",
			Date = "kMUFn8uD",
			NestingCode = "o",
			Nesting = 9,
			UnitOrBasisForMeasurementCode5 = "US",
			PegCode = "U",
			UnitOrBasisForMeasurementCode6 = "J2",
			ReferenceIdentification = "j",
			XPeg = 8,
			YPeg = 2,
			ReferenceIdentification2 = "q",
			XPeg2 = 9,
			YPeg2 = 9,
			ReferenceIdentification3 = "k",
			XPeg3 = 6,
			YPeg3 = 5,
		};

		var actual = Map.MapObject<ID1_ItemDetailDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("0llTqYyXF9Nd", "nY", true)]
	[InlineData("0llTqYyXF9Nd", "", true)]
	[InlineData("", "nY", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nY", "m", true)]
	[InlineData("nY", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		subject.FreeFormDescription = freeFormDescription;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredSize(decimal size, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		if (size > 0)
			subject.Size = size;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e9", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		if (height > 0)
			subject.Height = height;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		if (width > 0)
			subject.Width = width;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredItemDepth(decimal itemDepth, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		if (itemDepth > 0)
			subject.ItemDepth = itemDepth;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zb", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Xd", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Xd", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "w", true)]
	[InlineData("7", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredCategoryReferenceCode(string categoryReferenceCode, string category, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		subject.CategoryReferenceCode = categoryReferenceCode;
		subject.Category = category;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("58", "kMUFn8uD", true)]
	[InlineData("58", "", false)]
	[InlineData("", "kMUFn8uD", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "J2", true)]
	[InlineData("j", "", false)]
	[InlineData("", "J2", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		subject.ReferenceIdentification = referenceIdentification;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "J2", true)]
	[InlineData("q", "", false)]
	[InlineData("", "J2", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "J2", true)]
	[InlineData("k", "", false)]
	[InlineData("", "J2", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "D";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Height = 3;
		subject.Width = 5;
		subject.ItemDepth = 2;
		subject.UnitOrBasisForMeasurementCode2 = "Zb";
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "0llTqYyXF9Nd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "nY";
			subject.ProductServiceID = "m";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode3 = "Xd";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "7";
			subject.Category = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "58";
			subject.Date = "kMUFn8uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
