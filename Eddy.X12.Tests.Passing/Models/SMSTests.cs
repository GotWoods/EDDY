using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMS*Fw*d*x*dvS*J*zz*T*f*O*5E*s*sq*y";

		var expected = new SMS_StationCodesSegment()
		{
			StandardCarrierAlphaCode = "Fw",
			FreightStationAccountingCode = "d",
			Rule260JunctionCode = "x",
			PostalCode = "dvS",
			ReciprocalSwitchCode = "J",
			TimeCode = "zz",
			LocationIdentifier = "T",
			LocationIdentifier2 = "f",
			YesNoConditionOrResponseCode = "O",
			IdentificationCode = "5E",
			YesNoConditionOrResponseCode2 = "s",
			StandardCarrierAlphaCode2 = "sq",
			FreightStationAccountingCode2 = "y",
		};

		var actual = Map.MapObject<SMS_StationCodesSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fw", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		subject.FreightStationAccountingCode = "d";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredFreightStationAccountingCode(string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		subject.StandardCarrierAlphaCode = "Fw";
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("zz", "s", true)]
	[InlineData("", "s", false)]
	[InlineData("zz", "", false)]
	public void Validation_AllAreRequiredTimeCode(string timeCode, string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		subject.StandardCarrierAlphaCode = "Fw";
		subject.FreightStationAccountingCode = "d";
		subject.TimeCode = timeCode;
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("T", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("T", "", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		subject.StandardCarrierAlphaCode = "Fw";
		subject.FreightStationAccountingCode = "d";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationIdentifier2 = locationIdentifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("sq", "y", true)]
	[InlineData("", "y", false)]
	[InlineData("sq", "", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, string freightStationAccountingCode2, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		subject.StandardCarrierAlphaCode = "Fw";
		subject.FreightStationAccountingCode = "d";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		subject.FreightStationAccountingCode2 = freightStationAccountingCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
