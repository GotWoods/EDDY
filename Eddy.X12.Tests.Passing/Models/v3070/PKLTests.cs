using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PKLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKL*Qt*O*rV*8*2*1*4*gx*1*xs*1*PA";

		var expected = new PKL_MultiPackConfiguration()
		{
			ProductServiceIDQualifier = "Qt",
			ProductServiceID = "O",
			UnitOrBasisForMeasurementCode = "rV",
			Quantity = 8,
			Height = 2,
			Width = 1,
			ItemDepth = 4,
			UnitOrBasisForMeasurementCode2 = "gx",
			GrossWeightPerPack = 1,
			UnitOrBasisForMeasurementCode3 = "xs",
			GrossVolumePerPack = 1,
			UnitOrBasisForMeasurementCode4 = "PA",
		};

		var actual = Map.MapObject<PKL_MultiPackConfiguration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qt", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceID = "O";
		subject.UnitOrBasisForMeasurementCode = "rV";
		subject.Quantity = 8;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "xs";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "PA";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "gx";
			subject.Height = 2;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Qt";
		subject.UnitOrBasisForMeasurementCode = "rV";
		subject.Quantity = 8;
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "xs";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "PA";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "gx";
			subject.Height = 2;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rV", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Qt";
		subject.ProductServiceID = "O";
		subject.Quantity = 8;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "xs";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "PA";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "gx";
			subject.Height = 2;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Qt";
		subject.ProductServiceID = "O";
		subject.UnitOrBasisForMeasurementCode = "rV";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "xs";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "PA";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "gx";
			subject.Height = 2;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "gx", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "gx", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Qt";
		subject.ProductServiceID = "O";
		subject.UnitOrBasisForMeasurementCode = "rV";
		subject.Quantity = 8;
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "xs";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "PA";
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
	[InlineData(1, "gx", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "gx", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Qt";
		subject.ProductServiceID = "O";
		subject.UnitOrBasisForMeasurementCode = "rV";
		subject.Quantity = 8;
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "xs";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "PA";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.ItemDepth > 0)
		{
			subject.Height = 2;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "gx", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "gx", true)]
	public void Validation_ARequiresBItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Qt";
		subject.ProductServiceID = "O";
		subject.UnitOrBasisForMeasurementCode = "rV";
		subject.Quantity = 8;
		//Test Parameters
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "xs";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "PA";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0)
		{
			subject.Height = 2;
			subject.Width = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("gx", 2, 1, 4, true)]
	[InlineData("gx", 0, 0, 0, false)]
	[InlineData("", 2, 1, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal height, decimal width, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Qt";
		subject.ProductServiceID = "O";
		subject.UnitOrBasisForMeasurementCode = "rV";
		subject.Quantity = 8;
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
			subject.UnitOrBasisForMeasurementCode2 = "gx";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode2 = "gx";
		if (itemDepth > 0)
			subject.UnitOrBasisForMeasurementCode2 = "gx";
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "xs";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "PA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "xs", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "xs", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Qt";
		subject.ProductServiceID = "O";
		subject.UnitOrBasisForMeasurementCode = "rV";
		subject.Quantity = 8;
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "PA";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "gx";
			subject.Height = 2;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "PA", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "PA", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "Qt";
		subject.ProductServiceID = "O";
		subject.UnitOrBasisForMeasurementCode = "rV";
		subject.Quantity = 8;
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 1;
			subject.UnitOrBasisForMeasurementCode3 = "xs";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "gx";
			subject.Height = 2;
			subject.Width = 1;
			subject.ItemDepth = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
