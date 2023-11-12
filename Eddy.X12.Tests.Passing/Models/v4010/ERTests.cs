using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ER*C*x2*oKl*5JRQgh*Wvr*8R*a*7k*H*m4pwmulE*Y";

		var expected = new ER_RailEventReporting()
		{
			ActionCode = "C",
			StandardCarrierAlphaCode = "x2",
			EventCode = "oKl",
			StandardPointLocationCode = "5JRQgh",
			DateTimeQualifier = "Wvr",
			DateTimePeriodFormatQualifier = "8R",
			DateTimePeriod = "a",
			StandardCarrierAlphaCode2 = "7k",
			InterchangeTrainIdentification = "H",
			Date = "m4pwmulE",
			LoadEmptyStatusCode = "Y",
		};

		var actual = Map.MapObject<ER_RailEventReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.StandardCarrierAlphaCode = "x2";
		subject.EventCode = "oKl";
		subject.StandardPointLocationCode = "5JRQgh";
		subject.DateTimeQualifier = "Wvr";
		subject.DateTimePeriodFormatQualifier = "8R";
		subject.DateTimePeriod = "a";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x2", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "C";
		subject.EventCode = "oKl";
		subject.StandardPointLocationCode = "5JRQgh";
		subject.DateTimeQualifier = "Wvr";
		subject.DateTimePeriodFormatQualifier = "8R";
		subject.DateTimePeriod = "a";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oKl", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "C";
		subject.StandardCarrierAlphaCode = "x2";
		subject.StandardPointLocationCode = "5JRQgh";
		subject.DateTimeQualifier = "Wvr";
		subject.DateTimePeriodFormatQualifier = "8R";
		subject.DateTimePeriod = "a";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5JRQgh", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "C";
		subject.StandardCarrierAlphaCode = "x2";
		subject.EventCode = "oKl";
		subject.DateTimeQualifier = "Wvr";
		subject.DateTimePeriodFormatQualifier = "8R";
		subject.DateTimePeriod = "a";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wvr", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "C";
		subject.StandardCarrierAlphaCode = "x2";
		subject.EventCode = "oKl";
		subject.StandardPointLocationCode = "5JRQgh";
		subject.DateTimePeriodFormatQualifier = "8R";
		subject.DateTimePeriod = "a";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8R", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "C";
		subject.StandardCarrierAlphaCode = "x2";
		subject.EventCode = "oKl";
		subject.StandardPointLocationCode = "5JRQgh";
		subject.DateTimeQualifier = "Wvr";
		subject.DateTimePeriod = "a";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "C";
		subject.StandardCarrierAlphaCode = "x2";
		subject.EventCode = "oKl";
		subject.StandardPointLocationCode = "5JRQgh";
		subject.DateTimeQualifier = "Wvr";
		subject.DateTimePeriodFormatQualifier = "8R";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "m4pwmulE", true)]
	[InlineData("H", "", false)]
	[InlineData("", "m4pwmulE", true)]
	public void Validation_ARequiresBInterchangeTrainIdentification(string interchangeTrainIdentification, string date, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "C";
		subject.StandardCarrierAlphaCode = "x2";
		subject.EventCode = "oKl";
		subject.StandardPointLocationCode = "5JRQgh";
		subject.DateTimeQualifier = "Wvr";
		subject.DateTimePeriodFormatQualifier = "8R";
		subject.DateTimePeriod = "a";
		//Test Parameters
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
