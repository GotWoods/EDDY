using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class IS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS2*tC*f6j*d*wor1AC*805MDu*KpLr*W8*Ws*K*ggbdb1*J*UvMmip*y9K9*AIQZZx*LRlT";

		var expected = new IS2_ScheduledEvents()
		{
			StandardCarrierAlphaCode = "tC",
			EventCode = "f6j",
			AccomplishCode = "d",
			StandardPointLocationCode = "wor1AC",
			Date = "805MDu",
			Time = "KpLr",
			TimeCode = "W8",
			StandardCarrierAlphaCode2 = "Ws",
			InterchangeTrainIdentification = "K",
			Date2 = "ggbdb1",
			BlockIdentification = "J",
			Date3 = "UvMmip",
			Time2 = "y9K9",
			Date4 = "AIQZZx",
			Time3 = "LRlT",
		};

		var actual = Map.MapObject<IS2_ScheduledEvents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tC", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.EventCode = "f6j";
		subject.AccomplishCode = "d";
		subject.StandardPointLocationCode = "wor1AC";
		subject.Date = "805MDu";
		subject.Time = "KpLr";
		subject.TimeCode = "W8";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f6j", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "tC";
		subject.AccomplishCode = "d";
		subject.StandardPointLocationCode = "wor1AC";
		subject.Date = "805MDu";
		subject.Time = "KpLr";
		subject.TimeCode = "W8";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "tC";
		subject.EventCode = "f6j";
		subject.StandardPointLocationCode = "wor1AC";
		subject.Date = "805MDu";
		subject.Time = "KpLr";
		subject.TimeCode = "W8";
		//Test Parameters
		subject.AccomplishCode = accomplishCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wor1AC", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "tC";
		subject.EventCode = "f6j";
		subject.AccomplishCode = "d";
		subject.Date = "805MDu";
		subject.Time = "KpLr";
		subject.TimeCode = "W8";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("805MDu", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "tC";
		subject.EventCode = "f6j";
		subject.AccomplishCode = "d";
		subject.StandardPointLocationCode = "wor1AC";
		subject.Time = "KpLr";
		subject.TimeCode = "W8";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KpLr", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "tC";
		subject.EventCode = "f6j";
		subject.AccomplishCode = "d";
		subject.StandardPointLocationCode = "wor1AC";
		subject.Date = "805MDu";
		subject.TimeCode = "W8";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W8", true)]
	public void Validation_RequiredTimeCode(string timeCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "tC";
		subject.EventCode = "f6j";
		subject.AccomplishCode = "d";
		subject.StandardPointLocationCode = "wor1AC";
		subject.Date = "805MDu";
		subject.Time = "KpLr";
		//Test Parameters
		subject.TimeCode = timeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
