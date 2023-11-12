using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LAD*Gyk*2*4*9*Q*4*sl*K*h0*W*lb*S*a";

		var expected = new LAD_LadingDetail()
		{
			PackagingFormCode = "Gyk",
			LadingQuantity = 2,
			WeightUnitCode = "4",
			UnitWeight = 9,
			WeightUnitCode2 = "Q",
			Weight = 4,
			ProductServiceIDQualifier = "sl",
			ProductServiceID = "K",
			ProductServiceIDQualifier2 = "h0",
			ProductServiceID2 = "W",
			ProductServiceIDQualifier3 = "lb",
			ProductServiceID3 = "S",
			LadingDescription = "a",
		};

		var actual = Map.MapObject<LAD_LadingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Gyk", 2, true)]
	[InlineData("Gyk", 0, false)]
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
			subject.WeightUnitCode = "4";
			subject.UnitWeight = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "Q";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sl";
			subject.ProductServiceID = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "h0";
			subject.ProductServiceID2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "lb";
			subject.ProductServiceID3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("4", 9, true)]
	[InlineData("4", 0, false)]
	[InlineData("", 9, false)]
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
			subject.PackagingFormCode = "Gyk";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "Q";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sl";
			subject.ProductServiceID = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "h0";
			subject.ProductServiceID2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "lb";
			subject.ProductServiceID3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Q", 4, true)]
	[InlineData("Q", 0, false)]
	[InlineData("", 4, false)]
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
			subject.PackagingFormCode = "Gyk";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "4";
			subject.UnitWeight = 9;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sl";
			subject.ProductServiceID = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "h0";
			subject.ProductServiceID2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "lb";
			subject.ProductServiceID3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sl", "K", true)]
	[InlineData("sl", "", false)]
	[InlineData("", "K", false)]
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
			subject.PackagingFormCode = "Gyk";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "4";
			subject.UnitWeight = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "Q";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "h0";
			subject.ProductServiceID2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "lb";
			subject.ProductServiceID3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h0", "W", true)]
	[InlineData("h0", "", false)]
	[InlineData("", "W", false)]
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
			subject.PackagingFormCode = "Gyk";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "4";
			subject.UnitWeight = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "Q";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sl";
			subject.ProductServiceID = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "lb";
			subject.ProductServiceID3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lb", "S", true)]
	[InlineData("lb", "", false)]
	[InlineData("", "S", false)]
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
			subject.PackagingFormCode = "Gyk";
			subject.LadingQuantity = 2;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "4";
			subject.UnitWeight = 9;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode2) || !string.IsNullOrEmpty(subject.WeightUnitCode2) || subject.Weight > 0)
		{
			subject.WeightUnitCode2 = "Q";
			subject.Weight = 4;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sl";
			subject.ProductServiceID = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "h0";
			subject.ProductServiceID2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
