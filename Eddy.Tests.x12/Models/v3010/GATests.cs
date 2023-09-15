using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*Z*J*d*P4*7*1*7aL*TfHGox*g";

		var expected = new GA_CanadianGrainInformation()
		{
			CommodityCodeQualifier = "Z",
			CommodityCode = "J",
			WeightQualifier = "d",
			ReferenceNumberQualifier = "P4",
			ReferenceNumber = "7",
			Week = 1,
			UnloadTerminal = "7aL",
			Date = "TfHGox",
			IncentiveGrainRateIndicator = "g",
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
