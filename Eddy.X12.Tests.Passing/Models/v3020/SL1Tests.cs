using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SL1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SL1*id*6*s*6*E8VVwA*M2*Cz*PJ*7";

		var expected = new SL1_TariffReference()
		{
			ServiceLevelCode = "id",
			TariffNumber = "6",
			CommodityCode = "s",
			Scale = "6",
			Date = "E8VVwA",
			ServiceLevelCode2 = "M2",
			ShipmentMethodOfPayment = "Cz",
			DataSourceCode = "PJ",
			InternationalDomesticCode = "7",
		};

		var actual = Map.MapObject<SL1_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("id", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SL1_TariffReference();
		subject.ServiceLevelCode = serviceLevelCode;
			subject.CommodityCode = "s";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("s", "6", true)]
	[InlineData("s", "", true)]
	[InlineData("", "6", true)]
	public void Validation_AtLeastOneCommodityCode(string commodityCode, string scale, bool isValidExpected)
	{
		var subject = new SL1_TariffReference();
		subject.ServiceLevelCode = "id";
		subject.CommodityCode = commodityCode;
		subject.Scale = scale;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
