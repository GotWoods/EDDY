using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class FU3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FU3*k*fA*p*CA*Y*w*b*7*H*9*ks*1*hI*1*Yh*5*7q*8";

		var expected = new FU3_ProductDetail()
		{
			ProductName = "k",
			UnitOrBasisForMeasurementCode = "fA",
			BrandName = "p",
			EntityIdentifierCode = "CA",
			Name = "Y",
			ProductLabel = "w",
			Description = "b",
			WeightQualifier = "7",
			WeightUnitCode = "H",
			UnitWeight = 9,
			UnitOrBasisForMeasurementCode2 = "ks",
			Height = 1,
			UnitOrBasisForMeasurementCode3 = "hI",
			Width = 1,
			UnitOrBasisForMeasurementCode4 = "Yh",
			ItemDepth = 5,
			UnitOrBasisForMeasurementCode5 = "7q",
			Volume = 8,
		};

		var actual = Map.MapObject<FU3_ProductDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredProductName(string productName, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		//Required fields
		//Test Parameters
		subject.ProductName = productName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "CA";
			subject.Name = "Y";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "ks";
			subject.Height = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Width > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "hI";
			subject.Width = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "Yh";
			subject.ItemDepth = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Volume > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "7q";
			subject.Volume = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CA", "Y", true)]
	[InlineData("CA", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		//Required fields
		subject.ProductName = "k";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "ks";
			subject.Height = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Width > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "hI";
			subject.Width = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "Yh";
			subject.ItemDepth = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Volume > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "7q";
			subject.Volume = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ks", 1, true)]
	[InlineData("ks", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal height, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		//Required fields
		subject.ProductName = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (height > 0) 
			subject.Height = height;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "CA";
			subject.Name = "Y";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Width > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "hI";
			subject.Width = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "Yh";
			subject.ItemDepth = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Volume > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "7q";
			subject.Volume = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("hI", 1, true)]
	[InlineData("hI", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal width, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		//Required fields
		subject.ProductName = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (width > 0) 
			subject.Width = width;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "CA";
			subject.Name = "Y";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "ks";
			subject.Height = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "Yh";
			subject.ItemDepth = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Volume > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "7q";
			subject.Volume = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Yh", 5, true)]
	[InlineData("Yh", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal itemDepth, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		//Required fields
		subject.ProductName = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "CA";
			subject.Name = "Y";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "ks";
			subject.Height = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Width > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "hI";
			subject.Width = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5) || subject.Volume > 0)
		{
			subject.UnitOrBasisForMeasurementCode5 = "7q";
			subject.Volume = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7q", 8, true)]
	[InlineData("7q", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode5(string unitOrBasisForMeasurementCode5, decimal volume, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		//Required fields
		subject.ProductName = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		if (volume > 0) 
			subject.Volume = volume;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "CA";
			subject.Name = "Y";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "ks";
			subject.Height = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Width > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "hI";
			subject.Width = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4) || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode4 = "Yh";
			subject.ItemDepth = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
