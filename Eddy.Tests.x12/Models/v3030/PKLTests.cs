using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PKLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKL*su*0*uO*5*2*2*8*y3*3*4N*5*sX";

		var expected = new PKL_MultiPackConfiguration()
		{
			ProductServiceIDQualifier = "su",
			ProductServiceID = "0",
			UnitOrBasisForMeasurementCode = "uO",
			Quantity = 5,
			Height = 2,
			Width = 2,
			ItemDepth = 8,
			UnitOrBasisForMeasurementCode2 = "y3",
			GrossWeightPerPack = 3,
			UnitOrBasisForMeasurementCode3 = "4N",
			GrossVolumePerPack = 5,
			DispositionCode = "sX",
		};

		var actual = Map.MapObject<PKL_MultiPackConfiguration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("su", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceID = "0";
		subject.UnitOrBasisForMeasurementCode = "uO";
		subject.Quantity = 5;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "4N";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.DispositionCode))
		{
			subject.GrossVolumePerPack = 5;
			subject.DispositionCode = "sX";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "y3";
			subject.Height = 2;
			subject.Width = 2;
			subject.ItemDepth = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "su";
		subject.UnitOrBasisForMeasurementCode = "uO";
		subject.Quantity = 5;
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "4N";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.DispositionCode))
		{
			subject.GrossVolumePerPack = 5;
			subject.DispositionCode = "sX";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "y3";
			subject.Height = 2;
			subject.Width = 2;
			subject.ItemDepth = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uO", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "su";
		subject.ProductServiceID = "0";
		subject.Quantity = 5;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "4N";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.DispositionCode))
		{
			subject.GrossVolumePerPack = 5;
			subject.DispositionCode = "sX";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "y3";
			subject.Height = 2;
			subject.Width = 2;
			subject.ItemDepth = 8;
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
		subject.ProductServiceIDQualifier = "su";
		subject.ProductServiceID = "0";
		subject.UnitOrBasisForMeasurementCode = "uO";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "4N";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.DispositionCode))
		{
			subject.GrossVolumePerPack = 5;
			subject.DispositionCode = "sX";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "y3";
			subject.Height = 2;
			subject.Width = 2;
			subject.ItemDepth = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "y3", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "y3", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "su";
		subject.ProductServiceID = "0";
		subject.UnitOrBasisForMeasurementCode = "uO";
		subject.Quantity = 5;
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "4N";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.DispositionCode))
		{
			subject.GrossVolumePerPack = 5;
			subject.DispositionCode = "sX";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.Width = 2;
			subject.ItemDepth = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "y3", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "y3", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "su";
		subject.ProductServiceID = "0";
		subject.UnitOrBasisForMeasurementCode = "uO";
		subject.Quantity = 5;
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "4N";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.DispositionCode))
		{
			subject.GrossVolumePerPack = 5;
			subject.DispositionCode = "sX";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.ItemDepth > 0)
		{
			subject.Height = 2;
			subject.ItemDepth = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "y3", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "y3", true)]
	public void Validation_ARequiresBItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "su";
		subject.ProductServiceID = "0";
		subject.UnitOrBasisForMeasurementCode = "uO";
		subject.Quantity = 5;
		//Test Parameters
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "4N";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.DispositionCode))
		{
			subject.GrossVolumePerPack = 5;
			subject.DispositionCode = "sX";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0)
		{
			subject.Height = 2;
			subject.Width = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("y3", 2, 2, 8, true)]
	[InlineData("y3", 0, 0, 0, false)]
	[InlineData("", 2, 2, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal height, decimal width, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "su";
		subject.ProductServiceID = "0";
		subject.UnitOrBasisForMeasurementCode = "uO";
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
			subject.UnitOrBasisForMeasurementCode2 = "y3";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode2 = "y3";
		if (itemDepth > 0)
			subject.UnitOrBasisForMeasurementCode2 = "y3";
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "4N";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.DispositionCode))
		{
			subject.GrossVolumePerPack = 5;
			subject.DispositionCode = "sX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "4N", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "4N", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "su";
		subject.ProductServiceID = "0";
		subject.UnitOrBasisForMeasurementCode = "uO";
		subject.Quantity = 5;
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.DispositionCode))
		{
			subject.GrossVolumePerPack = 5;
			subject.DispositionCode = "sX";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "y3";
			subject.Height = 2;
			subject.Width = 2;
			subject.ItemDepth = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "sX", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "sX", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string dispositionCode, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "su";
		subject.ProductServiceID = "0";
		subject.UnitOrBasisForMeasurementCode = "uO";
		subject.Quantity = 5;
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.DispositionCode = dispositionCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 3;
			subject.UnitOrBasisForMeasurementCode3 = "4N";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "y3";
			subject.Height = 2;
			subject.Width = 2;
			subject.ItemDepth = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
