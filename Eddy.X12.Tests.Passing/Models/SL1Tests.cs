using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SL1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SL1*mN*Q*C*t*PI6nkQ3y*Hu*pV*tU*H";

		var expected = new SL1_TariffDetails()
		{
			ServiceLevelCode = "mN",
			TariffNumber = "Q",
			CommodityCode = "C",
			Scale = "t",
			Date = "PI6nkQ3y",
			ServiceLevelCode2 = "Hu",
			ShipmentMethodOfPaymentCode = "pV",
			DataSourceCode = "tU",
			InternationalDomesticCode = "H",
		};

		var actual = Map.MapObject<SL1_TariffDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mN", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SL1_TariffDetails();
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("C","t", true)]
	[InlineData("", "t", true)]
	[InlineData("C", "", true)]
	public void Validation_AtLeastOneCommodityCode(string commodityCode, string scale, bool isValidExpected)
	{
		var subject = new SL1_TariffDetails();
		subject.ServiceLevelCode = "mN";
		subject.CommodityCode = commodityCode;
		subject.Scale = scale;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
