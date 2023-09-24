using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PS*jKc*3*xA*1*Z4*V*YL*wj*8*M";

		var expected = new PS_ProtectiveServiceInstructions()
		{
			ProtectiveServiceRuleCode = "jKc",
			ProtectiveServiceCode = "3",
			UnitOrBasisForMeasurementCode = "xA",
			Temperature = 1,
			StandardCarrierAlphaCode = "Z4",
			FreightStationAccountingCode = "V",
			CityName = "YL",
			StateOrProvinceCode = "wj",
			Weight = 8,
			PreCooledRule710Code = "M",
		};

		var actual = Map.MapObject<PS_ProtectiveServiceInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jKc", true)]
	public void Validation_RequiredProtectiveServiceRuleCode(string protectiveServiceRuleCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceCode = "3";
		//Test Parameters
		subject.ProtectiveServiceRuleCode = protectiveServiceRuleCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredProtectiveServiceCode(string protectiveServiceCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceRuleCode = "jKc";
		//Test Parameters
		subject.ProtectiveServiceCode = protectiveServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
