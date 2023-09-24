using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class ID1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID1*1BUg57c5y5Lt*SV*4*v*7*Nh*6*4*1*H7*8*4Y*n*h*Q*xF*4*8*xy*zV0dh6hu*t*6*VG*9*ws*X*2*1*L*9*9*m*9*4";

		var expected = new ID1_ItemDetailDimensions()
		{
			UPCEANConsumerPackageCode = "1BUg57c5y5Lt",
			ProductServiceIDQualifier = "SV",
			ProductServiceID = "4",
			FreeFormDescription = "v",
			Size = 7,
			UnitOrBasisForMeasurementCode = "Nh",
			Height = 6,
			Width = 4,
			ItemDepth = 1,
			UnitOrBasisForMeasurementCode2 = "H7",
			Weight = 8,
			UnitOrBasisForMeasurementCode3 = "4Y",
			CategoryReferenceCode = "n",
			Category = "h",
			Subcategory = "Q",
			UnitOrBasisForMeasurementCode4 = "xF",
			Pack = 4,
			InnerPack = 8,
			DateQualifier = "xy",
			Date = "zV0dh6hu",
			NestingCode = "t",
			Nesting = 6,
			UnitOrBasisForMeasurementCode5 = "VG",
			PegCode = "9",
			UnitOrBasisForMeasurementCode6 = "ws",
			ReferenceIdentification = "X",
			XPeg = 2,
			YPeg = 1,
			ReferenceIdentification2 = "L",
			XPeg2 = 9,
			YPeg2 = 9,
			ReferenceIdentification3 = "m",
			XPeg3 = 9,
			YPeg3 = 4,
		};

		var actual = Map.MapObject<ID1_ItemDetailDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("1BUg57c5y5Lt", "SV", true)]
	[InlineData("1BUg57c5y5Lt", "", true)]
	[InlineData("", "SV", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("SV", "4", true)]
	[InlineData("SV", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		subject.FreeFormDescription = freeFormDescription;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredSize(decimal size, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		if (size > 0)
			subject.Size = size;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nh", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		if (height > 0)
			subject.Height = height;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		if (width > 0)
			subject.Width = width;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredItemDepth(decimal itemDepth, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		if (itemDepth > 0)
			subject.ItemDepth = itemDepth;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H7", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "4Y", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "4Y", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "h", true)]
	[InlineData("n", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredCategoryReferenceCode(string categoryReferenceCode, string category, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		subject.CategoryReferenceCode = categoryReferenceCode;
		subject.Category = category;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xy", "zV0dh6hu", true)]
	[InlineData("xy", "", false)]
	[InlineData("", "zV0dh6hu", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "ws", true)]
	[InlineData("X", "", false)]
	[InlineData("", "ws", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		subject.ReferenceIdentification = referenceIdentification;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L", "ws", true)]
	[InlineData("L", "", false)]
	[InlineData("", "ws", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "ws", true)]
	[InlineData("m", "", false)]
	[InlineData("", "ws", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "v";
		subject.Size = 7;
		subject.UnitOrBasisForMeasurementCode = "Nh";
		subject.Height = 6;
		subject.Width = 4;
		subject.ItemDepth = 1;
		subject.UnitOrBasisForMeasurementCode2 = "H7";
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
			subject.UPCEANConsumerPackageCode = "1BUg57c5y5Lt";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "SV";
			subject.ProductServiceID = "4";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.CategoryReferenceCode) || !string.IsNullOrEmpty(subject.Category))
		{
			subject.CategoryReferenceCode = "n";
			subject.Category = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "xy";
			subject.Date = "zV0dh6hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
