using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PKLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKL*7K*8*sQ*6*8*1*3*u4*8*yX*3*hz*8";

		var expected = new PKL_MultiPackConfiguration()
		{
			ProductServiceIDQualifier = "7K",
			ProductServiceID = "8",
			UnitOrBasisForMeasurementCode = "sQ",
			Quantity = 6,
			Height = 8,
			Width = 1,
			ItemDepth = 3,
			UnitOrBasisForMeasurementCode2 = "u4",
			GrossWeightPerPack = 8,
			UnitOrBasisForMeasurementCode3 = "yX",
			GrossVolumePerPack = 3,
			UnitOrBasisForMeasurementCode4 = "hz",
			YesNoConditionOrResponseCode = "8",
		};

		var actual = Map.MapObject<PKL_MultiPackConfiguration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7K", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceID = "8";
		subject.UnitOrBasisForMeasurementCode = "sQ";
		subject.Quantity = 6;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "yX";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode4 = "hz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "u4";
			subject.Height = 8;
			subject.Width = 1;
			subject.ItemDepth = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "7K";
		subject.UnitOrBasisForMeasurementCode = "sQ";
		subject.Quantity = 6;
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "yX";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode4 = "hz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "u4";
			subject.Height = 8;
			subject.Width = 1;
			subject.ItemDepth = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sQ", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "7K";
		subject.ProductServiceID = "8";
		subject.Quantity = 6;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "yX";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode4 = "hz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "u4";
			subject.Height = 8;
			subject.Width = 1;
			subject.ItemDepth = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "7K";
		subject.ProductServiceID = "8";
		subject.UnitOrBasisForMeasurementCode = "sQ";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "yX";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode4 = "hz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "u4";
			subject.Height = 8;
			subject.Width = 1;
			subject.ItemDepth = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "u4", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "u4", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "7K";
		subject.ProductServiceID = "8";
		subject.UnitOrBasisForMeasurementCode = "sQ";
		subject.Quantity = 6;
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "yX";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode4 = "hz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.Width = 1;
			subject.ItemDepth = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "u4", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "u4", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "7K";
		subject.ProductServiceID = "8";
		subject.UnitOrBasisForMeasurementCode = "sQ";
		subject.Quantity = 6;
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "yX";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode4 = "hz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.ItemDepth > 0)
		{
			subject.Height = 8;
			subject.ItemDepth = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "u4", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "u4", true)]
	public void Validation_ARequiresBItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "7K";
		subject.ProductServiceID = "8";
		subject.UnitOrBasisForMeasurementCode = "sQ";
		subject.Quantity = 6;
		//Test Parameters
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "yX";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode4 = "hz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0)
		{
			subject.Height = 8;
			subject.Width = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("u4", 8, 1, 3, true)]
	[InlineData("u4", 0, 0, 0, false)]
	[InlineData("", 8, 1, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal height, decimal width, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "7K";
		subject.ProductServiceID = "8";
		subject.UnitOrBasisForMeasurementCode = "sQ";
		subject.Quantity = 6;
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
			subject.UnitOrBasisForMeasurementCode2 = "u4";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode2 = "u4";
		if (itemDepth > 0)
			subject.UnitOrBasisForMeasurementCode2 = "u4";
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "yX";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode4 = "hz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "yX", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "yX", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "7K";
		subject.ProductServiceID = "8";
		subject.UnitOrBasisForMeasurementCode = "sQ";
		subject.Quantity = 6;
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 3;
			subject.UnitOrBasisForMeasurementCode4 = "hz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "u4";
			subject.Height = 8;
			subject.Width = 1;
			subject.ItemDepth = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "hz", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "hz", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "7K";
		subject.ProductServiceID = "8";
		subject.UnitOrBasisForMeasurementCode = "sQ";
		subject.Quantity = 6;
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 8;
			subject.UnitOrBasisForMeasurementCode3 = "yX";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "u4";
			subject.Height = 8;
			subject.Width = 1;
			subject.ItemDepth = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
