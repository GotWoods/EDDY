using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class JSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JS*ZV*0*Fy*U";

		var expected = new JS_RailJunctionSettlementRoleInformation()
		{
			StandardCarrierAlphaCode = "ZV",
			RailJunctionSettlementRoleCode = "0",
			StandardCarrierAlphaCode2 = "Fy",
			RailJunctionSettlementRoleCode2 = "U",
		};

		var actual = Map.MapObject<JS_RailJunctionSettlementRoleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JS_RailJunctionSettlementRoleInformation();
		subject.RailJunctionSettlementRoleCode = "0";
		subject.StandardCarrierAlphaCode2 = "Fy";
		subject.RailJunctionSettlementRoleCode2 = "U";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredRailJunctionSettlementRoleCode(string railJunctionSettlementRoleCode, bool isValidExpected)
	{
		var subject = new JS_RailJunctionSettlementRoleInformation();
		subject.StandardCarrierAlphaCode = "ZV";
		subject.StandardCarrierAlphaCode2 = "Fy";
		subject.RailJunctionSettlementRoleCode2 = "U";
		subject.RailJunctionSettlementRoleCode = railJunctionSettlementRoleCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fy", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new JS_RailJunctionSettlementRoleInformation();
		subject.StandardCarrierAlphaCode = "ZV";
		subject.RailJunctionSettlementRoleCode = "0";
		subject.RailJunctionSettlementRoleCode2 = "U";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredRailJunctionSettlementRoleCode2(string railJunctionSettlementRoleCode2, bool isValidExpected)
	{
		var subject = new JS_RailJunctionSettlementRoleInformation();
		subject.StandardCarrierAlphaCode = "ZV";
		subject.RailJunctionSettlementRoleCode = "0";
		subject.StandardCarrierAlphaCode2 = "Fy";
		subject.RailJunctionSettlementRoleCode2 = railJunctionSettlementRoleCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
