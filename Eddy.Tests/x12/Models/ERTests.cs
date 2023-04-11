using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ER*U*JK*Lbm*m6YC0M*PiP*Ww*a*Ry*F*u8HVoYH4*S*P3goBF";

		var expected = new ER_RailEventReporting()
		{
			ActionCode = "U",
			StandardCarrierAlphaCode = "JK",
			EventCode = "Lbm",
			StandardPointLocationCode = "m6YC0M",
			DateTimeQualifier = "PiP",
			DateTimePeriodFormatQualifier = "Ww",
			DateTimePeriod = "a",
			StandardCarrierAlphaCode2 = "Ry",
			InterchangeTrainIdentification = "F",
			Date = "u8HVoYH4",
			LoadEmptyStatusCode = "S",
			StandardPointLocationCode2 = "P3goBF",
		};

		var actual = Map.MapObject<ER_RailEventReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validatation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		subject.StandardCarrierAlphaCode = "JK";
		subject.EventCode = "Lbm";
		subject.StandardPointLocationCode = "m6YC0M";
		subject.DateTimeQualifier = "PiP";
		subject.DateTimePeriodFormatQualifier = "Ww";
		subject.DateTimePeriod = "a";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JK", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		subject.ActionCode = "U";
		subject.EventCode = "Lbm";
		subject.StandardPointLocationCode = "m6YC0M";
		subject.DateTimeQualifier = "PiP";
		subject.DateTimePeriodFormatQualifier = "Ww";
		subject.DateTimePeriod = "a";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lbm", true)]
	public void Validatation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		subject.ActionCode = "U";
		subject.StandardCarrierAlphaCode = "JK";
		subject.StandardPointLocationCode = "m6YC0M";
		subject.DateTimeQualifier = "PiP";
		subject.DateTimePeriodFormatQualifier = "Ww";
		subject.DateTimePeriod = "a";
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m6YC0M", true)]
	public void Validatation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		subject.ActionCode = "U";
		subject.StandardCarrierAlphaCode = "JK";
		subject.EventCode = "Lbm";
		subject.DateTimeQualifier = "PiP";
		subject.DateTimePeriodFormatQualifier = "Ww";
		subject.DateTimePeriod = "a";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PiP", true)]
	public void Validatation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		subject.ActionCode = "U";
		subject.StandardCarrierAlphaCode = "JK";
		subject.EventCode = "Lbm";
		subject.StandardPointLocationCode = "m6YC0M";
		subject.DateTimePeriodFormatQualifier = "Ww";
		subject.DateTimePeriod = "a";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ww", true)]
	public void Validatation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		subject.ActionCode = "U";
		subject.StandardCarrierAlphaCode = "JK";
		subject.EventCode = "Lbm";
		subject.StandardPointLocationCode = "m6YC0M";
		subject.DateTimeQualifier = "PiP";
		subject.DateTimePeriod = "a";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validatation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		subject.ActionCode = "U";
		subject.StandardCarrierAlphaCode = "JK";
		subject.EventCode = "Lbm";
		subject.StandardPointLocationCode = "m6YC0M";
		subject.DateTimeQualifier = "PiP";
		subject.DateTimePeriodFormatQualifier = "Ww";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "u8HVoYH4", true)]
	[InlineData("F", "", false)]
	public void Validation_ARequiresBInterchangeTrainIdentification(string interchangeTrainIdentification, string date, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		subject.ActionCode = "U";
		subject.StandardCarrierAlphaCode = "JK";
		subject.EventCode = "Lbm";
		subject.StandardPointLocationCode = "m6YC0M";
		subject.DateTimeQualifier = "PiP";
		subject.DateTimePeriodFormatQualifier = "Ww";
		subject.DateTimePeriod = "a";
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
