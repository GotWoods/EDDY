using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMS*Iw*D*G*q2M*M*WX*L*c*A*B3*W";

		var expected = new SMS_StationCodesSegment()
		{
			StandardCarrierAlphaCode = "Iw",
			FreightStationAccountingCode = "D",
			Rule260JunctionCode = "G",
			PostalCode = "q2M",
			ReciprocalSwitchCode = "M",
			TimeCode = "WX",
			LocationIdentifier = "L",
			LocationIdentifier2 = "c",
			YesNoConditionOrResponseCode = "A",
			IdentificationCode = "B3",
			YesNoConditionOrResponseCode2 = "W",
		};

		var actual = Map.MapObject<SMS_StationCodesSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Iw", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.FreightStationAccountingCode = "D";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "WX";
			subject.YesNoConditionOrResponseCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredFreightStationAccountingCode(string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "Iw";
		//Test Parameters
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "WX";
			subject.YesNoConditionOrResponseCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WX", "W", true)]
	[InlineData("WX", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredTimeCode(string timeCode, string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "Iw";
		subject.FreightStationAccountingCode = "D";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
