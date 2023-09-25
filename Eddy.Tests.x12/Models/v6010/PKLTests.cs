using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class PKLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKL*Fq*A*Jk*5*5*1*4*yI*3*Iz*7*iL*W";

		var expected = new PKL_MultiPackConfiguration()
		{
			ProductServiceIDQualifier = "Fq",
			ProductServiceID = "A",
			UnitOrBasisForMeasurementCode = "Jk",
			Quantity = 5,
			Height = 5,
			Width = 1,
			ItemDepth = 4,
			UnitOrBasisForMeasurementCode2 = "yI",
			GrossWeightPerPack = 3,
			UnitOrBasisForMeasurementCode3 = "Iz",
			GrossVolumePerPack = 7,
			UnitOrBasisForMeasurementCode4 = "iL",
			YesNoConditionOrResponseCode = "W",
		};

		var actual = Map.MapObject<PKL_MultiPackConfiguration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fq", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "Jk";
		subject.Quantity = 5;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Iz";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode4 = "iL";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "yI";
			subject.Height = 5;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Fq";
		subject.UnitOrBasisForMeasurementCode = "Jk";
		subject.Quantity = 5;
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Iz";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode4 = "iL";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "yI";
			subject.Height = 5;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jk", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Fq";
		subject.ProductServiceID = "A";
		subject.Quantity = 5;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Iz";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode4 = "iL";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "yI";
			subject.Height = 5;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Fq";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "Jk";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Iz";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode4 = "iL";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "yI";
			subject.Height = 5;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "yI", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "yI", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Fq";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "Jk";
		subject.Quantity = 5;
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Iz";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode4 = "iL";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "yI", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "yI", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Fq";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "Jk";
		subject.Quantity = 5;
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Iz";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode4 = "iL";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.ItemDepth > 0)
		{
			subject.Height = 5;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "yI", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "yI", true)]
	public void Validation_ARequiresBItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Fq";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "Jk";
		subject.Quantity = 5;
		//Test Parameters
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Iz";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode4 = "iL";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0)
		{
			subject.Height = 5;
			subject.Width = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("yI", 5, 1, 4, true)]
	[InlineData("yI", 0, 0, 0, false)]
	[InlineData("", 5, 1, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal height, decimal width, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Fq";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "Jk";
		subject.Quantity = 5;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (height > 0) 
			subject.Height = height;
		if (width > 0) 
			subject.Width = width;
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		//A Requires B
		if (height > 0)
			subject.UnitOrBasisForMeasurementCode2 = "yI";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode2 = "yI";
		if (itemDepth > 0)
			subject.UnitOrBasisForMeasurementCode2 = "yI";
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Iz";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode4 = "iL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Iz", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Iz", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Fq";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "Jk";
		subject.Quantity = 5;
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 7;
			subject.UnitOrBasisForMeasurementCode4 = "iL";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "yI";
			subject.Height = 5;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "iL", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "iL", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Fq";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "Jk";
		subject.Quantity = 5;
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Iz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "yI";
			subject.Height = 5;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
