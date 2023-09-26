using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMS*TI*E*t*VOY*T*0O*o*k*Z*ji*o*ew*W";

		var expected = new SMS_StationCodesSegment()
		{
			StandardCarrierAlphaCode = "TI",
			FreightStationAccountingCode = "E",
			Rule260JunctionCode = "t",
			PostalCode = "VOY",
			ReciprocalSwitchCode = "T",
			TimeCode = "0O",
			LocationIdentifier = "o",
			LocationIdentifier2 = "k",
			YesNoConditionOrResponseCode = "Z",
			IdentificationCode = "ji",
			YesNoConditionOrResponseCode2 = "o",
			StandardCarrierAlphaCode2 = "ew",
			FreightStationAccountingCode2 = "W",
		};

		var actual = Map.MapObject<SMS_StationCodesSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TI", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.FreightStationAccountingCode = "E";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "0O";
			subject.YesNoConditionOrResponseCode2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationIdentifier = "o";
			subject.LocationIdentifier2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode2))
		{
			subject.StandardCarrierAlphaCode2 = "ew";
			subject.FreightStationAccountingCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredFreightStationAccountingCode(string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "TI";
		//Test Parameters
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "0O";
			subject.YesNoConditionOrResponseCode2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationIdentifier = "o";
			subject.LocationIdentifier2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode2))
		{
			subject.StandardCarrierAlphaCode2 = "ew";
			subject.FreightStationAccountingCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0O", "o", true)]
	[InlineData("0O", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredTimeCode(string timeCode, string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "TI";
		subject.FreightStationAccountingCode = "E";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationIdentifier = "o";
			subject.LocationIdentifier2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode2))
		{
			subject.StandardCarrierAlphaCode2 = "ew";
			subject.FreightStationAccountingCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "k", true)]
	[InlineData("o", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "TI";
		subject.FreightStationAccountingCode = "E";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationIdentifier2 = locationIdentifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "0O";
			subject.YesNoConditionOrResponseCode2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode2))
		{
			subject.StandardCarrierAlphaCode2 = "ew";
			subject.FreightStationAccountingCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ew", "W", true)]
	[InlineData("ew", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, string freightStationAccountingCode2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "TI";
		subject.FreightStationAccountingCode = "E";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		subject.FreightStationAccountingCode2 = freightStationAccountingCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "0O";
			subject.YesNoConditionOrResponseCode2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationIdentifier = "o";
			subject.LocationIdentifier2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
