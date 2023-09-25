using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMS*RP*N*9*OPh*M*0n*u*d*3*ed*W*Y0*a";

		var expected = new SMS_StationCodesSegment()
		{
			StandardCarrierAlphaCode = "RP",
			FreightStationAccountingCode = "N",
			Rule260JunctionCode = "9",
			PostalCode = "OPh",
			ReciprocalSwitchCode = "M",
			TimeCode = "0n",
			LocationIdentifier = "u",
			LocationIdentifier2 = "d",
			YesNoConditionOrResponseCode = "3",
			IdentificationCode = "ed",
			YesNoConditionOrResponseCode2 = "W",
			StandardCarrierAlphaCode2 = "Y0",
			FreightStationAccountingCode2 = "a",
		};

		var actual = Map.MapObject<SMS_StationCodesSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RP", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.FreightStationAccountingCode = "N";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "0n";
			subject.YesNoConditionOrResponseCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode2))
		{
			subject.StandardCarrierAlphaCode2 = "Y0";
			subject.FreightStationAccountingCode2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredFreightStationAccountingCode(string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "RP";
		//Test Parameters
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "0n";
			subject.YesNoConditionOrResponseCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode2))
		{
			subject.StandardCarrierAlphaCode2 = "Y0";
			subject.FreightStationAccountingCode2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0n", "W", true)]
	[InlineData("0n", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredTimeCode(string timeCode, string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "RP";
		subject.FreightStationAccountingCode = "N";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode2))
		{
			subject.StandardCarrierAlphaCode2 = "Y0";
			subject.FreightStationAccountingCode2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y0", "a", true)]
	[InlineData("Y0", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, string freightStationAccountingCode2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "RP";
		subject.FreightStationAccountingCode = "N";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		subject.FreightStationAccountingCode2 = freightStationAccountingCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "0n";
			subject.YesNoConditionOrResponseCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
