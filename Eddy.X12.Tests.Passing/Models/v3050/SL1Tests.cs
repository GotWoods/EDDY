using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SL1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SL1*Iq*Q*Y*S*qk8UM2*N1*K4*72*V";

		var expected = new SL1_TariffReference()
		{
			ServiceLevelCode = "Iq",
			TariffNumber = "Q",
			CommodityCode = "Y",
			Scale = "S",
			Date = "qk8UM2",
			ServiceLevelCode2 = "N1",
			ShipmentMethodOfPayment = "K4",
			DataSourceCode = "72",
			InternationalDomesticCode = "V",
		};

		var actual = Map.MapObject<SL1_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Iq", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SL1_TariffReference();
		subject.ServiceLevelCode = serviceLevelCode;
			subject.CommodityCode = "Y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Y", "S", true)]
	[InlineData("Y", "", true)]
	[InlineData("", "S", true)]
	public void Validation_AtLeastOneCommodityCode(string commodityCode, string scale, bool isValidExpected)
	{
		var subject = new SL1_TariffReference();
		subject.ServiceLevelCode = "Iq";
		subject.CommodityCode = commodityCode;
		subject.Scale = scale;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
