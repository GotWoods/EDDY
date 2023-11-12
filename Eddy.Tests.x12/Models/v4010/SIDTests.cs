using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SID*n*G*d*CrxqalGl*F*a";

		var expected = new SID_StandardTransportationCommodityCodeIdentification()
		{
			CommodityCodeQualifier = "n",
			CommodityCode = "G",
			YesNoConditionOrResponseCode = "d",
			Date = "CrxqalGl",
			RatingSummaryValueCode = "F",
			YesNoConditionOrResponseCode2 = "a",
		};

		var actual = Map.MapObject<SID_StandardTransportationCommodityCodeIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		//Required fields
		subject.CommodityCode = "G";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		//Required fields
		subject.CommodityCodeQualifier = "n";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
