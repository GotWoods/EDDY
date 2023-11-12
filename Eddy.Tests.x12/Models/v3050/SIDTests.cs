using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SID*8*3*t*12QjkV*72*4";

		var expected = new SID_StandardTransportationCommodityCodeIdentification()
		{
			CommodityCodeQualifier = "8",
			CommodityCode = "3",
			YesNoConditionOrResponseCode = "t",
			Date = "12QjkV",
			Century = 72,
			RatingSummaryValueCode = "4",
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
		subject.CommodityCode = "3";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		//Required fields
		subject.CommodityCodeQualifier = "8";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(72, "12QjkV", true)]
	[InlineData(72, "", false)]
	[InlineData(0, "12QjkV", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new SID_StandardTransportationCommodityCodeIdentification();
		//Required fields
		subject.CommodityCodeQualifier = "8";
		subject.CommodityCode = "3";
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
