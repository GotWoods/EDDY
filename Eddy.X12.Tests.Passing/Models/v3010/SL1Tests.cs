using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SL1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SL1*zu*L*d*U*4NBWZu*IR*cL*03*8";

		var expected = new SL1_TariffReference()
		{
			ServiceLevelCode = "zu",
			TariffNumber = "L",
			CommodityCode = "d",
			Scale = "U",
			EffectiveDate = "4NBWZu",
			ServiceLevelCode2 = "IR",
			ShipmentMethodOfPayment = "cL",
			DataSourceCode = "03",
			InternationalDomesticCode = "8",
		};

		var actual = Map.MapObject<SL1_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zu", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SL1_TariffReference();
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
