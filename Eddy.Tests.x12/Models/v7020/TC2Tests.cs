using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class TC2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TC2*V*d";

		var expected = new TC2_Commodity()
		{
			CommodityCodeQualifier = "V",
			CommodityCode = "d",
		};

		var actual = Map.MapObject<TC2_Commodity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new TC2_Commodity();
		subject.CommodityCode = "d";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new TC2_Commodity();
		subject.CommodityCodeQualifier = "V";
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
