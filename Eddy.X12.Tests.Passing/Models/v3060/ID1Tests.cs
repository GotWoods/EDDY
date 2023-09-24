using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ID1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID1*BgdEEcomIEAI*b5*U*L*2*yT*4*2*7*ry*6*Je*z*U*3*Dn*6*2*Q7*Rp4SwV*V*9*5V*s*fz*E*6*8*r*4*9*W*3*7";

		var expected = new ID1_ItemDetailDimensions()
		{
			UPCEANConsumerPackageCode = "BgdEEcomIEAI",
			ProductServiceIDQualifier = "b5",
			ProductServiceID = "U",
			FreeFormDescription = "L",
			Size = 2,
			UnitOrBasisForMeasurementCode = "yT",
			Height = 4,
			Width = 2,
			ItemDepth = 7,
			UnitOrBasisForMeasurementCode2 = "ry",
			Weight = 6,
			UnitOrBasisForMeasurementCode3 = "Je",
			CategoryReferenceCode = "z",
			Category = "U",
			Subcategory = "3",
			UnitOrBasisForMeasurementCode4 = "Dn",
			Pack = 6,
			InnerPack = 2,
			DateQualifier = "Q7",
			Date = "Rp4SwV",
			NestingCode = "V",
			Nesting = 9,
			UnitOrBasisForMeasurementCode5 = "5V",
			PegCode = "s",
			UnitOrBasisForMeasurementCode6 = "fz",
			ReferenceIdentification = "E",
			XPeg = 6,
			YPeg = 8,
			ReferenceIdentification2 = "r",
			XPeg2 = 4,
			YPeg2 = 9,
			ReferenceIdentification3 = "W",
			XPeg3 = 3,
			YPeg3 = 7,
		};

		var actual = Map.MapObject<ID1_ItemDetailDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("BgdEEcomIEAI", "b5", true)]
	[InlineData("BgdEEcomIEAI", "", true)]
	[InlineData("", "b5", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b5", "U", true)]
	[InlineData("b5", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		subject.FreeFormDescription = freeFormDescription;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredSize(decimal size, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		if (size > 0)
			subject.Size = size;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yT", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		if (height > 0)
			subject.Height = height;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		if (width > 0)
			subject.Width = width;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredItemDepth(decimal itemDepth, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		if (itemDepth > 0)
			subject.ItemDepth = itemDepth;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ry", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "Je", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "Je", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "U", true)]
	[InlineData("z", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredCategoryReferenceCode(string categoryReferenceCode, string category, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		subject.CategoryReferenceCode = categoryReferenceCode;
		subject.Category = category;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q7", "Rp4SwV", true)]
	[InlineData("Q7", "", false)]
	[InlineData("", "Rp4SwV", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "fz", true)]
	[InlineData("E", "", false)]
	[InlineData("", "fz", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		subject.ReferenceIdentification = referenceIdentification;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "fz", true)]
	[InlineData("r", "", false)]
	[InlineData("", "fz", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "fz", true)]
	[InlineData("W", "", false)]
	[InlineData("", "fz", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "L";
		subject.Size = 2;
		subject.UnitOrBasisForMeasurementCode = "yT";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 7;
		subject.UnitOrBasisForMeasurementCode2 = "ry";
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "BgdEEcomIEAI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "b5";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Je";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "z";
			subject.Category = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Q7";
			subject.Date = "Rp4SwV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
