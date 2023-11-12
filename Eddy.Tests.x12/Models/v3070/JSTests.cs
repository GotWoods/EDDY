using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class JSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JS*Br*h*qd*x";

		var expected = new JS_RailJunctionSettlementRoleInformation()
		{
			StandardCarrierAlphaCode = "Br",
			RailJunctionSettlementRoleCode = "h",
			StandardCarrierAlphaCode2 = "qd",
			RailJunctionSettlementRoleCode2 = "x",
		};

		var actual = Map.MapObject<JS_RailJunctionSettlementRoleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Br", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JS_RailJunctionSettlementRoleInformation();
		//Required fields
		subject.RailJunctionSettlementRoleCode = "h";
		subject.StandardCarrierAlphaCode2 = "qd";
		subject.RailJunctionSettlementRoleCode2 = "x";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredRailJunctionSettlementRoleCode(string railJunctionSettlementRoleCode, bool isValidExpected)
	{
		var subject = new JS_RailJunctionSettlementRoleInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "Br";
		subject.StandardCarrierAlphaCode2 = "qd";
		subject.RailJunctionSettlementRoleCode2 = "x";
		//Test Parameters
		subject.RailJunctionSettlementRoleCode = railJunctionSettlementRoleCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qd", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new JS_RailJunctionSettlementRoleInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "Br";
		subject.RailJunctionSettlementRoleCode = "h";
		subject.RailJunctionSettlementRoleCode2 = "x";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredRailJunctionSettlementRoleCode2(string railJunctionSettlementRoleCode2, bool isValidExpected)
	{
		var subject = new JS_RailJunctionSettlementRoleInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "Br";
		subject.RailJunctionSettlementRoleCode = "h";
		subject.StandardCarrierAlphaCode2 = "qd";
		//Test Parameters
		subject.RailJunctionSettlementRoleCode2 = railJunctionSettlementRoleCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
