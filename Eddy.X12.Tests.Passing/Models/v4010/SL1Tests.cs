using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SL1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SL1*Dw*w*i*V*4rLCUjGY*Jy*YY*h0*D";

		var expected = new SL1_TariffReference()
		{
			ServiceLevelCode = "Dw",
			TariffNumber = "w",
			CommodityCode = "i",
			Scale = "V",
			Date = "4rLCUjGY",
			ServiceLevelCode2 = "Jy",
			ShipmentMethodOfPayment = "YY",
			DataSourceCode = "h0",
			InternationalDomesticCode = "D",
		};

		var actual = Map.MapObject<SL1_TariffReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dw", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SL1_TariffReference();
		subject.ServiceLevelCode = serviceLevelCode;
			subject.CommodityCode = "i";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("i", "V", true)]
	[InlineData("i", "", true)]
	[InlineData("", "V", true)]
	public void Validation_AtLeastOneCommodityCode(string commodityCode, string scale, bool isValidExpected)
	{
		var subject = new SL1_TariffReference();
		subject.ServiceLevelCode = "Dw";
		subject.CommodityCode = commodityCode;
		subject.Scale = scale;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
