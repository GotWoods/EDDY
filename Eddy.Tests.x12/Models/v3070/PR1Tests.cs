using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PR1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR1*s*7*s*I*X*j*fK*ds*q*p*Q*fI*HU";

		var expected = new PR1_PriceRequestParameterList1()
		{
			CommodityCodeQualifier = "s",
			CommodityCode = "7",
			CommodityCode2 = "s",
			LocationQualifier = "I",
			LocationIdentifier = "X",
			LocationIdentifier2 = "j",
			StateOrProvinceCode = "fK",
			StandardCarrierAlphaCode = "ds",
			LocationQualifier2 = "q",
			LocationIdentifier3 = "p",
			LocationIdentifier4 = "Q",
			StateOrProvinceCode2 = "fI",
			StandardCarrierAlphaCode2 = "HU",
		};

		var actual = Map.MapObject<PR1_PriceRequestParameterList1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCode = "7";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//At Least one
		subject.LocationIdentifier = "X";
		subject.LocationIdentifier3 = "p";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "I";
			subject.LocationIdentifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "q";
			subject.LocationIdentifier3 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "s";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//At Least one
		subject.LocationIdentifier = "X";
		subject.LocationIdentifier3 = "p";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "I";
			subject.LocationIdentifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "q";
			subject.LocationIdentifier3 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "X", true)]
	[InlineData("I", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "s";
		subject.CommodityCode = "7";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		//At Least one
		subject.StateOrProvinceCode = "fK";
		subject.LocationIdentifier3 = "p";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "q";
			subject.LocationIdentifier3 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("X", "fK", true)]
	[InlineData("X", "", true)]
	[InlineData("", "fK", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "s";
		subject.CommodityCode = "7";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.LocationIdentifier3 = "p";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "I";
			subject.LocationIdentifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "q";
			subject.LocationIdentifier3 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "p", true)]
	[InlineData("q", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier3, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "s";
		subject.CommodityCode = "7";
		//Test Parameters
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier3 = locationIdentifier3;
		//At Least one
		subject.LocationIdentifier = "X";
		subject.StateOrProvinceCode2 = "fI";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "I";
			subject.LocationIdentifier = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("p", "fI", true)]
	[InlineData("p", "", true)]
	[InlineData("", "fI", true)]
	public void Validation_AtLeastOneLocationIdentifier3(string locationIdentifier3, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "s";
		subject.CommodityCode = "7";
		//Test Parameters
		subject.LocationIdentifier3 = locationIdentifier3;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		//At Least one
		subject.LocationIdentifier = "X";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "I";
			subject.LocationIdentifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier2 = "q";
			subject.LocationIdentifier3 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
