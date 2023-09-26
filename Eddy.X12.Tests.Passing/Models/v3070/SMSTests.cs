using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMS*6D*M*ViWBv8*s*L1B*h*9y*S*z*64*e*Wl*W";

		var expected = new SMS_StationCodesSegment()
		{
			StandardCarrierAlphaCode = "6D",
			FreightStationAccountingCode = "M",
			Date = "ViWBv8",
			Rule260JunctionCode = "s",
			PostalCode = "L1B",
			ReciprocalSwitchCode = "h",
			TimeCode = "9y",
			LocationIdentifier = "S",
			LocationIdentifier2 = "z",
			Century = 64,
			YesNoConditionOrResponseCode = "e",
			IdentificationCode = "Wl",
			YesNoConditionOrResponseCode2 = "W",
		};

		var actual = Map.MapObject<SMS_StationCodesSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6D", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.FreightStationAccountingCode = "M";
		subject.Date = "ViWBv8";
		subject.Century = 64;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "9y";
			subject.YesNoConditionOrResponseCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredFreightStationAccountingCode(string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "6D";
		subject.Date = "ViWBv8";
		subject.Century = 64;
		//Test Parameters
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "9y";
			subject.YesNoConditionOrResponseCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ViWBv8", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "6D";
		subject.FreightStationAccountingCode = "M";
		subject.Century = 64;
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "9y";
			subject.YesNoConditionOrResponseCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9y", "W", true)]
	[InlineData("9y", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredTimeCode(string timeCode, string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "6D";
		subject.FreightStationAccountingCode = "M";
		subject.Date = "ViWBv8";
		subject.Century = 64;
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(64, true)]
	public void Validation_RequiredCentury(int century, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "6D";
		subject.FreightStationAccountingCode = "M";
		subject.Date = "ViWBv8";
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.TimeCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode2))
		{
			subject.TimeCode = "9y";
			subject.YesNoConditionOrResponseCode2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
