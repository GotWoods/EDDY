using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LAD*qZu*4*D*4*6*2*Jl*A*gF*B*67*t*F";

		var expected = new LAD_LadingDetail()
		{
			PackagingFormCode = "qZu",
			LadingQuantity = 4,
			WeightUnitQualifier = "D",
			UnitWeight = 4,
			WeightUnitQualifier2 = "6",
			Weight = 2,
			ProductServiceIDQualifier = "Jl",
			ProductServiceID = "A",
			ProductServiceIDQualifier2 = "gF",
			ProductServiceID2 = "B",
			ProductServiceIDQualifier3 = "67",
			ProductServiceID3 = "t",
			LadingDescription = "F",
		};

		var actual = Map.MapObject<LAD_LadingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("qZu", 4, true)]
	[InlineData("qZu", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new LAD_LadingDetail();
		//Required fields
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.UnitWeight > 0)
		{
			subject.WeightUnitQualifier = "D";
			subject.UnitWeight = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier2) || !string.IsNullOrEmpty(subject.WeightUnitQualifier2) || subject.Weight > 0)
		{
			subject.WeightUnitQualifier2 = "6";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Jl";
			subject.ProductServiceID = "A";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "gF";
			subject.ProductServiceID2 = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "67";
			subject.ProductServiceID3 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 4, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredWeightUnitQualifier(string weightUnitQualifier, decimal unitWeight, bool isValidExpected)
	{
		var subject = new LAD_LadingDetail();
		//Required fields
		//Test Parameters
		subject.WeightUnitQualifier = weightUnitQualifier;
		if (unitWeight > 0) 
			subject.UnitWeight = unitWeight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "qZu";
			subject.LadingQuantity = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier2) || !string.IsNullOrEmpty(subject.WeightUnitQualifier2) || subject.Weight > 0)
		{
			subject.WeightUnitQualifier2 = "6";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Jl";
			subject.ProductServiceID = "A";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "gF";
			subject.ProductServiceID2 = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "67";
			subject.ProductServiceID3 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6", 2, true)]
	[InlineData("6", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredWeightUnitQualifier2(string weightUnitQualifier2, decimal weight, bool isValidExpected)
	{
		var subject = new LAD_LadingDetail();
		//Required fields
		//Test Parameters
		subject.WeightUnitQualifier2 = weightUnitQualifier2;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "qZu";
			subject.LadingQuantity = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.UnitWeight > 0)
		{
			subject.WeightUnitQualifier = "D";
			subject.UnitWeight = 4;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Jl";
			subject.ProductServiceID = "A";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "gF";
			subject.ProductServiceID2 = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "67";
			subject.ProductServiceID3 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Jl", "A", true)]
	[InlineData("Jl", "", false)]
	[InlineData("", "A", false)]
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
			subject.PackagingFormCode = "qZu";
			subject.LadingQuantity = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.UnitWeight > 0)
		{
			subject.WeightUnitQualifier = "D";
			subject.UnitWeight = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier2) || !string.IsNullOrEmpty(subject.WeightUnitQualifier2) || subject.Weight > 0)
		{
			subject.WeightUnitQualifier2 = "6";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "gF";
			subject.ProductServiceID2 = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "67";
			subject.ProductServiceID3 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gF", "B", true)]
	[InlineData("gF", "", false)]
	[InlineData("", "B", false)]
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
			subject.PackagingFormCode = "qZu";
			subject.LadingQuantity = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.UnitWeight > 0)
		{
			subject.WeightUnitQualifier = "D";
			subject.UnitWeight = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier2) || !string.IsNullOrEmpty(subject.WeightUnitQualifier2) || subject.Weight > 0)
		{
			subject.WeightUnitQualifier2 = "6";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Jl";
			subject.ProductServiceID = "A";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "67";
			subject.ProductServiceID3 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("67", "t", true)]
	[InlineData("67", "", false)]
	[InlineData("", "t", false)]
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
			subject.PackagingFormCode = "qZu";
			subject.LadingQuantity = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.UnitWeight > 0)
		{
			subject.WeightUnitQualifier = "D";
			subject.UnitWeight = 4;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier2) || !string.IsNullOrEmpty(subject.WeightUnitQualifier2) || subject.Weight > 0)
		{
			subject.WeightUnitQualifier2 = "6";
			subject.Weight = 2;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Jl";
			subject.ProductServiceID = "A";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "gF";
			subject.ProductServiceID2 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
