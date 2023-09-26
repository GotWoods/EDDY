using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class PR1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR1*Q*v*n*U*L*o*w6*lL*R*M*M*8S*aS";

		var expected = new PR1_PriceRequestParameterList1()
		{
			CommodityCodeQualifier = "Q",
			CommodityCode = "v",
			CommodityCode2 = "n",
			LocationQualifier = "U",
			LocationIdentifier = "L",
			LocationIdentifier2 = "o",
			StateOrProvinceCode = "w6",
			StandardCarrierAlphaCode = "lL",
			LocationQualifier2 = "R",
			LocationIdentifier3 = "M",
			LocationIdentifier4 = "M",
			StateOrProvinceCode2 = "8S",
			StandardCarrierAlphaCode2 = "aS",
		};

		var actual = Map.MapObject<PR1_PriceRequestParameterList1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCode = "v";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//At Least one
		subject.LocationIdentifier = "L";
		subject.LocationIdentifier3 = "M";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "U";
			subject.LocationIdentifier = "L";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier3 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "Q";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//At Least one
		subject.LocationIdentifier = "L";
		subject.LocationIdentifier3 = "M";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "U";
			subject.LocationIdentifier = "L";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier3 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "L", true)]
	[InlineData("U", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "Q";
		subject.CommodityCode = "v";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		//At Least one
		subject.StateOrProvinceCode = "w6";
		subject.LocationIdentifier3 = "M";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier3 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("L", "w6", true)]
	[InlineData("L", "", true)]
	[InlineData("", "w6", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "Q";
		subject.CommodityCode = "v";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.LocationIdentifier3 = "M";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "U";
			subject.LocationIdentifier = "L";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier3 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "M", true)]
	[InlineData("R", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier3, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "Q";
		subject.CommodityCode = "v";
		//Test Parameters
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier3 = locationIdentifier3;
		//At Least one
		subject.LocationIdentifier = "L";
		subject.StateOrProvinceCode2 = "8S";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "U";
			subject.LocationIdentifier = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("M", "8S", true)]
	[InlineData("M", "", true)]
	[InlineData("", "8S", true)]
	public void Validation_AtLeastOneLocationIdentifier3(string locationIdentifier3, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "Q";
		subject.CommodityCode = "v";
		//Test Parameters
		subject.LocationIdentifier3 = locationIdentifier3;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		//At Least one
		subject.LocationIdentifier = "L";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "U";
			subject.LocationIdentifier = "L";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier3 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
