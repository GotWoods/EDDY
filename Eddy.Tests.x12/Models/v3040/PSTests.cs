using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PS*QRm*I*0R*6*Fy*y*JG*0V*7*J";

		var expected = new PS_ProtectiveServiceInstructions()
		{
			ProtectiveServiceRuleCode = "QRm",
			ProtectiveServiceCode = "I",
			UnitOrBasisForMeasurementCode = "0R",
			Temperature = 6,
			StandardCarrierAlphaCode = "Fy",
			FreightStationAccountingCode = "y",
			CityName = "JG",
			StateOrProvinceCode = "0V",
			Weight = 7,
			PreCooledRule710Code = "J",
		};

		var actual = Map.MapObject<PS_ProtectiveServiceInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QRm", true)]
	public void Validation_RequiredProtectiveServiceRuleCode(string protectiveServiceRuleCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceCode = "I";
		//Test Parameters
		subject.ProtectiveServiceRuleCode = protectiveServiceRuleCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredProtectiveServiceCode(string protectiveServiceCode, bool isValidExpected)
	{
		var subject = new PS_ProtectiveServiceInstructions();
		//Required fields
		subject.ProtectiveServiceRuleCode = "QRm";
		//Test Parameters
		subject.ProtectiveServiceCode = protectiveServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
