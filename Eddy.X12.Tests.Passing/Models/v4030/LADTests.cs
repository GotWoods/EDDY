using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LAD*RA0*3*p*6*C*8*TC*m*CU*f*Ox*s*s*69";

		var expected = new LAD_LadingDetail()
		{
			PackagingFormCode = "RA0",
			LadingQuantity = 3,
			WeightUnitCode = "p",
			UnitWeight = 6,
			WeightUnitCode2 = "C",
			Weight = 8,
			ProductServiceIDQualifier = "TC",
			ProductServiceID = "m",
			ProductServiceIDQualifier2 = "CU",
			ProductServiceID2 = "f",
			ProductServiceIDQualifier3 = "Ox",
			ProductServiceID3 = "s",
			LadingDescription = "s",
			LadingValue = 69,
		};

		var actual = Map.MapObject<LAD_LadingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("RA0", 3, true)]
	[InlineData("RA0", 0, false)]
	[InlineData("", 3, false)]
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
			subject.WeightUnitCode = "p";
			subject.UnitWeight = 6;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "C";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "TC";
			subject.ProductServiceID = "m";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CU";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Ox";
			subject.ProductServiceID3 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("p", 6, true)]
	[InlineData("p", 0, false)]
	[InlineData("", 6, false)]
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
			subject.PackagingFormCode = "RA0";
			subject.LadingQuantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "C";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "TC";
			subject.ProductServiceID = "m";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CU";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Ox";
			subject.ProductServiceID3 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("C", 8, true)]
	[InlineData("C", 0, false)]
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
			subject.PackagingFormCode = "RA0";
			subject.LadingQuantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "p";
			subject.UnitWeight = 6;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "TC";
			subject.ProductServiceID = "m";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CU";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Ox";
			subject.ProductServiceID3 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TC", "m", true)]
	[InlineData("TC", "", false)]
	[InlineData("", "m", false)]
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
			subject.PackagingFormCode = "RA0";
			subject.LadingQuantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "p";
			subject.UnitWeight = 6;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "C";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CU";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Ox";
			subject.ProductServiceID3 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CU", "f", true)]
	[InlineData("CU", "", false)]
	[InlineData("", "f", false)]
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
			subject.PackagingFormCode = "RA0";
			subject.LadingQuantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "p";
			subject.UnitWeight = 6;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "C";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "TC";
			subject.ProductServiceID = "m";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Ox";
			subject.ProductServiceID3 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ox", "s", true)]
	[InlineData("Ox", "", false)]
	[InlineData("", "s", false)]
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
			subject.PackagingFormCode = "RA0";
			subject.LadingQuantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "p";
			subject.UnitWeight = 6;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "C";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "TC";
			subject.ProductServiceID = "m";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CU";
			subject.ProductServiceID2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
