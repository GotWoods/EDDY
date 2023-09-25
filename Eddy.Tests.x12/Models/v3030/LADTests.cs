using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class LADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LAD*B9V*2*K*3*l*8*zt*R*bi*Q*Yu*q*L";

		var expected = new LAD_LadingDetail()
		{
			PackagingFormCode = "B9V",
			LadingQuantity = 2,
			WeightUnitCode = "K",
			UnitWeight = 3,
			WeightUnitCode2 = "l",
			Weight = 8,
			ProductServiceIDQualifier = "zt",
			ProductServiceID = "R",
			ProductServiceIDQualifier2 = "bi",
			ProductServiceID2 = "Q",
			ProductServiceIDQualifier3 = "Yu",
			ProductServiceID3 = "q",
			LadingDescription = "L",
		};

		var actual = Map.MapObject<LAD_LadingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("B9V", 2, true)]
	[InlineData("B9V", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new LAD_LadingDetail();
		//Required fields
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "K";
			subject.UnitWeight = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "l";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "zt";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bi";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Yu";
			subject.ProductServiceID3 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("K", 3, true)]
	[InlineData("K", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal unitWeight, bool isValidExpected)
	{
		var subject = new LAD_LadingDetail();
		//Required fields
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (unitWeight > 0) 
			subject.UnitWeight = unitWeight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "B9V";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "l";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "zt";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bi";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Yu";
			subject.ProductServiceID3 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("l", 8, true)]
	[InlineData("l", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredWeightUnitCode2(string weightUnitCode2, decimal weight, bool isValidExpected)
	{
		var subject = new LAD_LadingDetail();
		//Required fields
		//Test Parameters
		subject.WeightUnitCode2 = weightUnitCode2;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "B9V";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "K";
			subject.UnitWeight = 3;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "zt";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bi";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Yu";
			subject.ProductServiceID3 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zt", "R", true)]
	[InlineData("zt", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new LAD_LadingDetail();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "B9V";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "K";
			subject.UnitWeight = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "l";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bi";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Yu";
			subject.ProductServiceID3 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bi", "Q", true)]
	[InlineData("bi", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new LAD_LadingDetail();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "B9V";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "K";
			subject.UnitWeight = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "l";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "zt";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Yu";
			subject.ProductServiceID3 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Yu", "q", true)]
	[InlineData("Yu", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new LAD_LadingDetail();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "B9V";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "K";
			subject.UnitWeight = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "l";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "zt";
			subject.ProductServiceID = "R";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bi";
			subject.ProductServiceID2 = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
