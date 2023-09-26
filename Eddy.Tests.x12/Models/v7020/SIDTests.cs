using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class SIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SID*8*y*8*i4vkvsIB*3*j";

		var expected = new SID_StandardTransportationCommodityCodeIdentification()
		{
			CommodityCodeQualifier = "8",
			CommodityCode = "y",
			YesNoConditionOrResponseCode = "8",
			Date = "i4vkvsIB",
			RatingSummaryValueCode = "3",
			YesNoConditionOrResponseCode2 = "j",
		};

		var actual = Map.MapObject<SID_StandardTransportationCommodityCodeIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		//Required fields
		subject.CommodityCode = "y";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		//Required fields
		subject.CommodityCodeQualifier = "8";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
