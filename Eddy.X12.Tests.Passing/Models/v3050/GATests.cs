using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*n*m*7*up*Z*1*lTr*Umg2Hq*1";

		var expected = new GA_CanadianGrainInformation()
		{
			CommodityCodeQualifier = "n",
			CommodityCode = "m",
			WeightQualifier = "7",
			ReferenceNumberQualifier = "up",
			ReferenceNumber = "Z",
			Week = 1,
			UnloadTerminal = "lTr",
			Date = "Umg2Hq",
			IncentiveGrainRateIndicator = "1",
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
