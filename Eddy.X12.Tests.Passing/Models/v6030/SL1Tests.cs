using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class SL1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SL1*1C*S*Z*4*ZrHJEW1C*qo*cC*vq*k";

		var expected = new SL1_TariffDetails()
		{
			ServiceLevelCode = "1C",
			TariffNumber = "S",
			CommodityCode = "Z",
			Scale = "4",
			Date = "ZrHJEW1C",
			ServiceLevelCode2 = "qo",
			ShipmentMethodOfPaymentCode = "cC",
			DataSourceCode = "vq",
			InternationalDomesticCode = "k",
		};

		var actual = Map.MapObject<SL1_TariffDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1C", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SL1_TariffDetails();
		subject.ServiceLevelCode = serviceLevelCode;
			subject.CommodityCode = "Z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Z", "4", true)]
	[InlineData("Z", "", true)]
	[InlineData("", "4", true)]
	public void Validation_AtLeastOneCommodityCode(string commodityCode, string scale, bool isValidExpected)
	{
		var subject = new SL1_TariffDetails();
		subject.ServiceLevelCode = "1C";
		subject.CommodityCode = commodityCode;
		subject.Scale = scale;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
