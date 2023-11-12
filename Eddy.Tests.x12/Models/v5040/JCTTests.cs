using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class JCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JCT*uv*T0*i*f*84*Zv*T*n*I";

		var expected = new JCT_RailroadJunctionInformation()
		{
			StandardCarrierAlphaCode = "uv",
			StandardCarrierAlphaCode2 = "T0",
			FreightStationAccountingCode = "i",
			FreightStationAccountingCode2 = "f",
			StandardCarrierAlphaCode3 = "84",
			StandardCarrierAlphaCode4 = "Zv",
			YesNoConditionOrResponseCode = "T",
			InterchangeTypeCode = "n",
			YesNoConditionOrResponseCode2 = "I",
		};

		var actual = Map.MapObject<JCT_RailroadJunctionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uv", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode2 = "T0";
		subject.StandardCarrierAlphaCode3 = "84";
		subject.StandardCarrierAlphaCode4 = "Zv";
		subject.YesNoConditionOrResponseCode = "T";
		subject.InterchangeTypeCode = "n";
		subject.YesNoConditionOrResponseCode2 = "I";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T0", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "uv";
		subject.StandardCarrierAlphaCode3 = "84";
		subject.StandardCarrierAlphaCode4 = "Zv";
		subject.YesNoConditionOrResponseCode = "T";
		subject.InterchangeTypeCode = "n";
		subject.YesNoConditionOrResponseCode2 = "I";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("84", true)]
	public void Validation_RequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "uv";
		subject.StandardCarrierAlphaCode2 = "T0";
		subject.StandardCarrierAlphaCode4 = "Zv";
		subject.YesNoConditionOrResponseCode = "T";
		subject.InterchangeTypeCode = "n";
		subject.YesNoConditionOrResponseCode2 = "I";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zv", true)]
	public void Validation_RequiredStandardCarrierAlphaCode4(string standardCarrierAlphaCode4, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "uv";
		subject.StandardCarrierAlphaCode2 = "T0";
		subject.StandardCarrierAlphaCode3 = "84";
		subject.YesNoConditionOrResponseCode = "T";
		subject.InterchangeTypeCode = "n";
		subject.YesNoConditionOrResponseCode2 = "I";
		//Test Parameters
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "uv";
		subject.StandardCarrierAlphaCode2 = "T0";
		subject.StandardCarrierAlphaCode3 = "84";
		subject.StandardCarrierAlphaCode4 = "Zv";
		subject.InterchangeTypeCode = "n";
		subject.YesNoConditionOrResponseCode2 = "I";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredInterchangeTypeCode(string interchangeTypeCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "uv";
		subject.StandardCarrierAlphaCode2 = "T0";
		subject.StandardCarrierAlphaCode3 = "84";
		subject.StandardCarrierAlphaCode4 = "Zv";
		subject.YesNoConditionOrResponseCode = "T";
		subject.YesNoConditionOrResponseCode2 = "I";
		//Test Parameters
		subject.InterchangeTypeCode = interchangeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "uv";
		subject.StandardCarrierAlphaCode2 = "T0";
		subject.StandardCarrierAlphaCode3 = "84";
		subject.StandardCarrierAlphaCode4 = "Zv";
		subject.YesNoConditionOrResponseCode = "T";
		subject.InterchangeTypeCode = "n";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
