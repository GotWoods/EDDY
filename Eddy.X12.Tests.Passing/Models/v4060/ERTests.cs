using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class ERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ER*J*Iv*4L4*q3NPeC*jVd*kt*i*dR*9*ZeKMRHMK*L*XeBaFt";

		var expected = new ER_RailEventReporting()
		{
			ActionCode = "J",
			StandardCarrierAlphaCode = "Iv",
			EventCode = "4L4",
			StandardPointLocationCode = "q3NPeC",
			DateTimeQualifier = "jVd",
			DateTimePeriodFormatQualifier = "kt",
			DateTimePeriod = "i",
			StandardCarrierAlphaCode2 = "dR",
			InterchangeTrainIdentification = "9",
			Date = "ZeKMRHMK",
			LoadEmptyStatusCode = "L",
			StandardPointLocationCode2 = "XeBaFt",
		};

		var actual = Map.MapObject<ER_RailEventReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.StandardCarrierAlphaCode = "Iv";
		subject.EventCode = "4L4";
		subject.StandardPointLocationCode = "q3NPeC";
		subject.DateTimeQualifier = "jVd";
		subject.DateTimePeriodFormatQualifier = "kt";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Iv", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "J";
		subject.EventCode = "4L4";
		subject.StandardPointLocationCode = "q3NPeC";
		subject.DateTimeQualifier = "jVd";
		subject.DateTimePeriodFormatQualifier = "kt";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4L4", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "J";
		subject.StandardCarrierAlphaCode = "Iv";
		subject.StandardPointLocationCode = "q3NPeC";
		subject.DateTimeQualifier = "jVd";
		subject.DateTimePeriodFormatQualifier = "kt";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q3NPeC", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "J";
		subject.StandardCarrierAlphaCode = "Iv";
		subject.EventCode = "4L4";
		subject.DateTimeQualifier = "jVd";
		subject.DateTimePeriodFormatQualifier = "kt";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jVd", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "J";
		subject.StandardCarrierAlphaCode = "Iv";
		subject.EventCode = "4L4";
		subject.StandardPointLocationCode = "q3NPeC";
		subject.DateTimePeriodFormatQualifier = "kt";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kt", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "J";
		subject.StandardCarrierAlphaCode = "Iv";
		subject.EventCode = "4L4";
		subject.StandardPointLocationCode = "q3NPeC";
		subject.DateTimeQualifier = "jVd";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "J";
		subject.StandardCarrierAlphaCode = "Iv";
		subject.EventCode = "4L4";
		subject.StandardPointLocationCode = "q3NPeC";
		subject.DateTimeQualifier = "jVd";
		subject.DateTimePeriodFormatQualifier = "kt";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "ZeKMRHMK", true)]
	[InlineData("9", "", false)]
	[InlineData("", "ZeKMRHMK", true)]
	public void Validation_ARequiresBInterchangeTrainIdentification(string interchangeTrainIdentification, string date, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "J";
		subject.StandardCarrierAlphaCode = "Iv";
		subject.EventCode = "4L4";
		subject.StandardPointLocationCode = "q3NPeC";
		subject.DateTimeQualifier = "jVd";
		subject.DateTimePeriodFormatQualifier = "kt";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
