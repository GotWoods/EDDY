using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class JCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JCT*lf*Dr*Y*w*KI*Kb*4*8*l";

		var expected = new JCT_RailroadJunctionInformation()
		{
			StandardCarrierAlphaCode = "lf",
			StandardCarrierAlphaCode2 = "Dr",
			FreightStationAccountingCode = "Y",
			FreightStationAccountingCode2 = "w",
			StandardCarrierAlphaCode3 = "KI",
			StandardCarrierAlphaCode4 = "Kb",
			YesNoConditionOrResponseCode = "4",
			InterchangeTypeCode = "8",
			YesNoConditionOrResponseCode2 = "l",
		};

		var actual = Map.MapObject<JCT_RailroadJunctionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lf", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		subject.StandardCarrierAlphaCode2 = "Dr";
		subject.StandardCarrierAlphaCode3 = "KI";
		subject.StandardCarrierAlphaCode4 = "Kb";
		subject.YesNoConditionOrResponseCode = "4";
		subject.InterchangeTypeCode = "8";
		subject.YesNoConditionOrResponseCode2 = "l";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dr", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		subject.StandardCarrierAlphaCode = "lf";
		subject.StandardCarrierAlphaCode3 = "KI";
		subject.StandardCarrierAlphaCode4 = "Kb";
		subject.YesNoConditionOrResponseCode = "4";
		subject.InterchangeTypeCode = "8";
		subject.YesNoConditionOrResponseCode2 = "l";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KI", true)]
	public void Validation_RequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		subject.StandardCarrierAlphaCode = "lf";
		subject.StandardCarrierAlphaCode2 = "Dr";
		subject.StandardCarrierAlphaCode4 = "Kb";
		subject.YesNoConditionOrResponseCode = "4";
		subject.InterchangeTypeCode = "8";
		subject.YesNoConditionOrResponseCode2 = "l";
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kb", true)]
	public void Validation_RequiredStandardCarrierAlphaCode4(string standardCarrierAlphaCode4, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		subject.StandardCarrierAlphaCode = "lf";
		subject.StandardCarrierAlphaCode2 = "Dr";
		subject.StandardCarrierAlphaCode3 = "KI";
		subject.YesNoConditionOrResponseCode = "4";
		subject.InterchangeTypeCode = "8";
		subject.YesNoConditionOrResponseCode2 = "l";
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		subject.StandardCarrierAlphaCode = "lf";
		subject.StandardCarrierAlphaCode2 = "Dr";
		subject.StandardCarrierAlphaCode3 = "KI";
		subject.StandardCarrierAlphaCode4 = "Kb";
		subject.InterchangeTypeCode = "8";
		subject.YesNoConditionOrResponseCode2 = "l";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredInterchangeTypeCode(string interchangeTypeCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		subject.StandardCarrierAlphaCode = "lf";
		subject.StandardCarrierAlphaCode2 = "Dr";
		subject.StandardCarrierAlphaCode3 = "KI";
		subject.StandardCarrierAlphaCode4 = "Kb";
		subject.YesNoConditionOrResponseCode = "4";
		subject.YesNoConditionOrResponseCode2 = "l";
		subject.InterchangeTypeCode = interchangeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		subject.StandardCarrierAlphaCode = "lf";
		subject.StandardCarrierAlphaCode2 = "Dr";
		subject.StandardCarrierAlphaCode3 = "KI";
		subject.StandardCarrierAlphaCode4 = "Kb";
		subject.YesNoConditionOrResponseCode = "4";
		subject.InterchangeTypeCode = "8";
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
