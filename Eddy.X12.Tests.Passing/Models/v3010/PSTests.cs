using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PS*QMv*h*Y2*7*iL*N*f4*pd*2*e";

		var expected = new PS_ProtectiveServiceInstructions()
		{
			ProtectiveServiceRuleCode = "QMv",
			ProtectiveServiceCode = "h",
			UnitOfMeasurementCode = "Y2",
			Temperature = 7,
			StandardCarrierAlphaCode = "iL",
			FreightStationAccountingCode = "N",
			CityName = "f4",
			StateOrProvinceCode = "pd",
			Weight = 2,
			PreCooledRule710Code = "e",
		};

		var actual = Map.MapObject<PS_ProtectiveServiceInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QMv", true)]
	public void Validation_RequiredProtectiveServiceRuleCode(string protectiveServiceRuleCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceCode = "h";
		//Test Parameters
		subject.ProtectiveServiceRuleCode = protectiveServiceRuleCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredProtectiveServiceCode(string protectiveServiceCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceRuleCode = "QMv";
		//Test Parameters
		subject.ProtectiveServiceCode = protectiveServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
