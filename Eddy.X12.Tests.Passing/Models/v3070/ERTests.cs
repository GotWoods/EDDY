using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ER*o*Dg*6Ll*taVZVV*PNj*jc*k*0Q*H*LPnCwK*A";

		var expected = new ER_RailEventReporting()
		{
			ActionCode = "o",
			StandardCarrierAlphaCode = "Dg",
			EventCode = "6Ll",
			StandardPointLocationCode = "taVZVV",
			DateTimeQualifier = "PNj",
			DateTimePeriodFormatQualifier = "jc",
			DateTimePeriod = "k",
			StandardCarrierAlphaCode2 = "0Q",
			InterchangeTrainIdentification = "H",
			Date = "LPnCwK",
			LoadEmptyStatusCode = "A",
		};

		var actual = Map.MapObject<ER_RailEventReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.StandardCarrierAlphaCode = "Dg";
		subject.EventCode = "6Ll";
		subject.StandardPointLocationCode = "taVZVV";
		subject.DateTimeQualifier = "PNj";
		subject.DateTimePeriodFormatQualifier = "jc";
		subject.DateTimePeriod = "k";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dg", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "o";
		subject.EventCode = "6Ll";
		subject.StandardPointLocationCode = "taVZVV";
		subject.DateTimeQualifier = "PNj";
		subject.DateTimePeriodFormatQualifier = "jc";
		subject.DateTimePeriod = "k";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6Ll", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "o";
		subject.StandardCarrierAlphaCode = "Dg";
		subject.StandardPointLocationCode = "taVZVV";
		subject.DateTimeQualifier = "PNj";
		subject.DateTimePeriodFormatQualifier = "jc";
		subject.DateTimePeriod = "k";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("taVZVV", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "o";
		subject.StandardCarrierAlphaCode = "Dg";
		subject.EventCode = "6Ll";
		subject.DateTimeQualifier = "PNj";
		subject.DateTimePeriodFormatQualifier = "jc";
		subject.DateTimePeriod = "k";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PNj", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "o";
		subject.StandardCarrierAlphaCode = "Dg";
		subject.EventCode = "6Ll";
		subject.StandardPointLocationCode = "taVZVV";
		subject.DateTimePeriodFormatQualifier = "jc";
		subject.DateTimePeriod = "k";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jc", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "o";
		subject.StandardCarrierAlphaCode = "Dg";
		subject.EventCode = "6Ll";
		subject.StandardPointLocationCode = "taVZVV";
		subject.DateTimeQualifier = "PNj";
		subject.DateTimePeriod = "k";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "o";
		subject.StandardCarrierAlphaCode = "Dg";
		subject.EventCode = "6Ll";
		subject.StandardPointLocationCode = "taVZVV";
		subject.DateTimeQualifier = "PNj";
		subject.DateTimePeriodFormatQualifier = "jc";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "LPnCwK", true)]
	[InlineData("H", "", false)]
	[InlineData("", "LPnCwK", true)]
	public void Validation_ARequiresBInterchangeTrainIdentification(string interchangeTrainIdentification, string date, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.ActionCode = "o";
		subject.StandardCarrierAlphaCode = "Dg";
		subject.EventCode = "6Ll";
		subject.StandardPointLocationCode = "taVZVV";
		subject.DateTimeQualifier = "PNj";
		subject.DateTimePeriodFormatQualifier = "jc";
		subject.DateTimePeriod = "k";
		//Test Parameters
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
