using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PKLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKL*G8*X*Qh*4*2*5*9*cz*6*lO*1*2k";

		var expected = new PKL_MultiPackConfiguration()
		{
			ProductServiceIDQualifier = "G8",
			ProductServiceID = "X",
			UnitOrBasisForMeasurementCode = "Qh",
			Quantity = 4,
			Height = 2,
			Width = 5,
			ItemDepth = 9,
			UnitOrBasisForMeasurementCode2 = "cz",
			GrossWeightPerPack = 6,
			UnitOrBasisForMeasurementCode3 = "lO",
			GrossVolumePerPack = 1,
			UnitOrBasisForMeasurementCode4 = "2k",
		};

		var actual = Map.MapObject<PKL_MultiPackConfiguration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G8", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceID = "X";
		subject.UnitOrBasisForMeasurementCode = "Qh";
		subject.Quantity = 4;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 6;
			subject.UnitOrBasisForMeasurementCode3 = "lO";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "2k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "cz";
			subject.Height = 2;
			subject.Width = 5;
			subject.ItemDepth = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "G8";
		subject.UnitOrBasisForMeasurementCode = "Qh";
		subject.Quantity = 4;
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 6;
			subject.UnitOrBasisForMeasurementCode3 = "lO";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "2k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "cz";
			subject.Height = 2;
			subject.Width = 5;
			subject.ItemDepth = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qh", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "G8";
		subject.ProductServiceID = "X";
		subject.Quantity = 4;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 6;
			subject.UnitOrBasisForMeasurementCode3 = "lO";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "2k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "cz";
			subject.Height = 2;
			subject.Width = 5;
			subject.ItemDepth = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "G8";
		subject.ProductServiceID = "X";
		subject.UnitOrBasisForMeasurementCode = "Qh";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 6;
			subject.UnitOrBasisForMeasurementCode3 = "lO";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "2k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "cz";
			subject.Height = 2;
			subject.Width = 5;
			subject.ItemDepth = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "cz", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "cz", true)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "G8";
		subject.ProductServiceID = "X";
		subject.UnitOrBasisForMeasurementCode = "Qh";
		subject.Quantity = 4;
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 6;
			subject.UnitOrBasisForMeasurementCode3 = "lO";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "2k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.Width = 5;
			subject.ItemDepth = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "cz", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "cz", true)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "G8";
		subject.ProductServiceID = "X";
		subject.UnitOrBasisForMeasurementCode = "Qh";
		subject.Quantity = 4;
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 6;
			subject.UnitOrBasisForMeasurementCode3 = "lO";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "2k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.ItemDepth > 0)
		{
			subject.Height = 2;
			subject.ItemDepth = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "cz", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "cz", true)]
	public void Validation_ARequiresBItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "G8";
		subject.ProductServiceID = "X";
		subject.UnitOrBasisForMeasurementCode = "Qh";
		subject.Quantity = 4;
		//Test Parameters
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 6;
			subject.UnitOrBasisForMeasurementCode3 = "lO";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "2k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0)
		{
			subject.Height = 2;
			subject.Width = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("cz", 2, 5, 9, true)]
	[InlineData("cz", 0, 0, 0, false)]
	[InlineData("", 2, 5, 9, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal height, decimal width, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "G8";
		subject.ProductServiceID = "X";
		subject.UnitOrBasisForMeasurementCode = "Qh";
		subject.Quantity = 4;
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
			subject.UnitOrBasisForMeasurementCode2 = "cz";
		if (width > 0)
			subject.UnitOrBasisForMeasurementCode2 = "cz";
		if (itemDepth > 0)
			subject.UnitOrBasisForMeasurementCode2 = "cz";
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 6;
			subject.UnitOrBasisForMeasurementCode3 = "lO";
		}
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "2k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "lO", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "lO", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "G8";
		subject.ProductServiceID = "X";
		subject.UnitOrBasisForMeasurementCode = "Qh";
		subject.Quantity = 4;
		//Test Parameters
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.GrossVolumePerPack > 0 || subject.GrossVolumePerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.GrossVolumePerPack = 1;
			subject.UnitOrBasisForMeasurementCode4 = "2k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "cz";
			subject.Height = 2;
			subject.Width = 5;
			subject.ItemDepth = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "2k", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "2k", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		//Required fields
		subject.ProductServiceIDQualifier = "G8";
		subject.ProductServiceID = "X";
		subject.UnitOrBasisForMeasurementCode = "Qh";
		subject.Quantity = 4;
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.GrossWeightPerPack > 0 || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.GrossWeightPerPack = 6;
			subject.UnitOrBasisForMeasurementCode3 = "lO";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Height > 0 || subject.Width > 0 || subject.ItemDepth > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "cz";
			subject.Height = 2;
			subject.Width = 5;
			subject.ItemDepth = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
