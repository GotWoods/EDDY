using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SID*L*o*L*eIH6Xl*66*4*O";

		var expected = new SID_StandardTransportationCommodityCodeIdentification()
		{
			CommodityCodeQualifier = "L",
			CommodityCode = "o",
			YesNoConditionOrResponseCode = "L",
			Date = "eIH6Xl",
			Century = 66,
			RatingSummaryValueCode = "4",
			YesNoConditionOrResponseCode2 = "O",
		};

		var actual = Map.MapObject<SID_StandardTransportationCommodityCodeIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		//Required fields
		subject.CommodityCode = "o";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(66, "eIH6Xl", true)]
	[InlineData(66, "", false)]
	[InlineData(0, "eIH6Xl", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		//Required fields
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "o";
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
