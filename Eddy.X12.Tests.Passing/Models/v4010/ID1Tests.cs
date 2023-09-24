using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ID1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID1*OA34OlxBpR50*2N*H*H*9*yC*1*5*5*Q2*1*sh*q*c*Y*Uq*9*7*sq*bwi22xDy*v*3*DA*G*uR*Q*2*5*u*3*8*s*3*4";

		var expected = new ID1_ItemDetailDimensions()
		{
			UPCEANConsumerPackageCode = "OA34OlxBpR50",
			ProductServiceIDQualifier = "2N",
			ProductServiceID = "H",
			FreeFormDescription = "H",
			Size = 9,
			UnitOrBasisForMeasurementCode = "yC",
			Height = 1,
			Width = 5,
			ItemDepth = 5,
			UnitOrBasisForMeasurementCode2 = "Q2",
			Weight = 1,
			UnitOrBasisForMeasurementCode3 = "sh",
			CategoryReferenceCode = "q",
			Category = "c",
			Subcategory = "Y",
			UnitOrBasisForMeasurementCode4 = "Uq",
			Pack = 9,
			InnerPack = 7,
			DateQualifier = "sq",
			Date = "bwi22xDy",
			NestingCode = "v",
			Nesting = 3,
			UnitOrBasisForMeasurementCode5 = "DA",
			PegCode = "G",
			UnitOrBasisForMeasurementCode6 = "uR",
			ReferenceIdentification = "Q",
			XPeg = 2,
			YPeg = 5,
			ReferenceIdentification2 = "u",
			XPeg2 = 3,
			YPeg2 = 8,
			ReferenceIdentification3 = "s",
			XPeg3 = 3,
			YPeg3 = 4,
		};

		var actual = Map.MapObject<ID1_ItemDetailDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("OA34OlxBpR50", "2N", true)]
	[InlineData("OA34OlxBpR50", "", true)]
	[InlineData("", "2N", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2N", "H", true)]
	[InlineData("2N", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		subject.FreeFormDescription = freeFormDescription;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredSize(decimal size, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		if (size > 0)
			subject.Size = size;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yC", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		if (height > 0)
			subject.Height = height;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		if (width > 0)
			subject.Width = width;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredItemDepth(decimal itemDepth, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		if (itemDepth > 0)
			subject.ItemDepth = itemDepth;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q2", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "sh", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "sh", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "c", true)]
	[InlineData("q", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredCategoryReferenceCode(string categoryReferenceCode, string category, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		subject.CategoryReferenceCode = categoryReferenceCode;
		subject.Category = category;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sq", "bwi22xDy", true)]
	[InlineData("sq", "", false)]
	[InlineData("", "bwi22xDy", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "uR", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "uR", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		subject.ReferenceIdentification = referenceIdentification;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "uR", true)]
	[InlineData("u", "", false)]
	[InlineData("", "uR", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "uR", true)]
	[InlineData("s", "", false)]
	[InlineData("", "uR", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "H";
		subject.Size = 9;
		subject.UnitOrBasisForMeasurementCode = "yC";
		subject.Height = 1;
		subject.Width = 5;
		subject.ItemDepth = 5;
		subject.UnitOrBasisForMeasurementCode2 = "Q2";
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "OA34OlxBpR50";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "2N";
			subject.ProductServiceID = "H";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode3 = "sh";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "q";
			subject.Category = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "sq";
			subject.Date = "bwi22xDy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
