using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class JCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JCT*vZ*2N*K*y*ad*Sl*X*p*T";

		var expected = new JCT_RailroadJunctionInformation()
		{
			StandardCarrierAlphaCode = "vZ",
			StandardCarrierAlphaCode2 = "2N",
			FreightStationAccountingCode = "K",
			FreightStationAccountingCode2 = "y",
			StandardCarrierAlphaCode3 = "ad",
			StandardCarrierAlphaCode4 = "Sl",
			YesNoConditionOrResponseCode = "X",
			InterchangeTypeCode = "p",
			YesNoConditionOrResponseCode2 = "T",
		};

		var actual = Map.MapObject<JCT_RailroadJunctionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vZ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode2 = "2N";
		subject.FreightStationAccountingCode = "K";
		subject.FreightStationAccountingCode2 = "y";
		subject.StandardCarrierAlphaCode3 = "ad";
		subject.StandardCarrierAlphaCode4 = "Sl";
		subject.YesNoConditionOrResponseCode = "X";
		subject.InterchangeTypeCode = "p";
		subject.YesNoConditionOrResponseCode2 = "T";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2N", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "vZ";
		subject.FreightStationAccountingCode = "K";
		subject.FreightStationAccountingCode2 = "y";
		subject.StandardCarrierAlphaCode3 = "ad";
		subject.StandardCarrierAlphaCode4 = "Sl";
		subject.YesNoConditionOrResponseCode = "X";
		subject.InterchangeTypeCode = "p";
		subject.YesNoConditionOrResponseCode2 = "T";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredFreightStationAccountingCode(string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "vZ";
		subject.StandardCarrierAlphaCode2 = "2N";
		subject.FreightStationAccountingCode2 = "y";
		subject.StandardCarrierAlphaCode3 = "ad";
		subject.StandardCarrierAlphaCode4 = "Sl";
		subject.YesNoConditionOrResponseCode = "X";
		subject.InterchangeTypeCode = "p";
		subject.YesNoConditionOrResponseCode2 = "T";
		//Test Parameters
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredFreightStationAccountingCode2(string freightStationAccountingCode2, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "vZ";
		subject.StandardCarrierAlphaCode2 = "2N";
		subject.FreightStationAccountingCode = "K";
		subject.StandardCarrierAlphaCode3 = "ad";
		subject.StandardCarrierAlphaCode4 = "Sl";
		subject.YesNoConditionOrResponseCode = "X";
		subject.InterchangeTypeCode = "p";
		subject.YesNoConditionOrResponseCode2 = "T";
		//Test Parameters
		subject.FreightStationAccountingCode2 = freightStationAccountingCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ad", true)]
	public void Validation_RequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "vZ";
		subject.StandardCarrierAlphaCode2 = "2N";
		subject.FreightStationAccountingCode = "K";
		subject.FreightStationAccountingCode2 = "y";
		subject.StandardCarrierAlphaCode4 = "Sl";
		subject.YesNoConditionOrResponseCode = "X";
		subject.InterchangeTypeCode = "p";
		subject.YesNoConditionOrResponseCode2 = "T";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sl", true)]
	public void Validation_RequiredStandardCarrierAlphaCode4(string standardCarrierAlphaCode4, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "vZ";
		subject.StandardCarrierAlphaCode2 = "2N";
		subject.FreightStationAccountingCode = "K";
		subject.FreightStationAccountingCode2 = "y";
		subject.StandardCarrierAlphaCode3 = "ad";
		subject.YesNoConditionOrResponseCode = "X";
		subject.InterchangeTypeCode = "p";
		subject.YesNoConditionOrResponseCode2 = "T";
		//Test Parameters
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "vZ";
		subject.StandardCarrierAlphaCode2 = "2N";
		subject.FreightStationAccountingCode = "K";
		subject.FreightStationAccountingCode2 = "y";
		subject.StandardCarrierAlphaCode3 = "ad";
		subject.StandardCarrierAlphaCode4 = "Sl";
		subject.InterchangeTypeCode = "p";
		subject.YesNoConditionOrResponseCode2 = "T";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredInterchangeTypeCode(string interchangeTypeCode, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "vZ";
		subject.StandardCarrierAlphaCode2 = "2N";
		subject.FreightStationAccountingCode = "K";
		subject.FreightStationAccountingCode2 = "y";
		subject.StandardCarrierAlphaCode3 = "ad";
		subject.StandardCarrierAlphaCode4 = "Sl";
		subject.YesNoConditionOrResponseCode = "X";
		subject.YesNoConditionOrResponseCode2 = "T";
		//Test Parameters
		subject.InterchangeTypeCode = interchangeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new JCT_RailroadJunctionInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "vZ";
		subject.StandardCarrierAlphaCode2 = "2N";
		subject.FreightStationAccountingCode = "K";
		subject.FreightStationAccountingCode2 = "y";
		subject.StandardCarrierAlphaCode3 = "ad";
		subject.StandardCarrierAlphaCode4 = "Sl";
		subject.YesNoConditionOrResponseCode = "X";
		subject.InterchangeTypeCode = "p";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
