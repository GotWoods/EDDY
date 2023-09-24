using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SID*B*T*G*hbqAQ5Bw*M*o";

		var expected = new SID_StandardTransportationCommodityCodeIdentification()
		{
			CommodityCodeQualifier = "B",
			CommodityCode = "T",
			YesNoConditionOrResponseCode = "G",
			Date = "hbqAQ5Bw",
			RatingSummaryValueCode = "M",
			YesNoConditionOrResponseCode2 = "o",
		};

		var actual = Map.MapObject<SID_StandardTransportationCommodityCodeIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		subject.CommodityCode = "T";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		subject.CommodityCodeQualifier = "B";
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
