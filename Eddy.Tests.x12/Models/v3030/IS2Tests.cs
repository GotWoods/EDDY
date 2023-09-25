using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class IS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS2*D3*RwD*5*gvwDNA*gADQAw*Mcic*mW*NV*J*OEODwZ*i*gzAM4W*Vvjc*EoPFNA*1qUn";

		var expected = new IS2_ScheduledEvents()
		{
			StandardCarrierAlphaCode = "D3",
			EventCode = "RwD",
			AccomplishCode = "5",
			StandardPointLocationCode = "gvwDNA",
			Date = "gADQAw",
			Time = "Mcic",
			TimeCode = "mW",
			StandardCarrierAlphaCode2 = "NV",
			InterchangeTrainIdentification = "J",
			Date2 = "OEODwZ",
			BlockIdentification = "i",
			Date3 = "gzAM4W",
			Time2 = "Vvjc",
			Date4 = "EoPFNA",
			Time3 = "1qUn",
		};

		var actual = Map.MapObject<IS2_ScheduledEvents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D3", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.EventCode = "RwD";
		subject.AccomplishCode = "5";
		subject.StandardPointLocationCode = "gvwDNA";
		subject.Date = "gADQAw";
		subject.Time = "Mcic";
		subject.TimeCode = "mW";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RwD", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "D3";
		subject.AccomplishCode = "5";
		subject.StandardPointLocationCode = "gvwDNA";
		subject.Date = "gADQAw";
		subject.Time = "Mcic";
		subject.TimeCode = "mW";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "D3";
		subject.EventCode = "RwD";
		subject.StandardPointLocationCode = "gvwDNA";
		subject.Date = "gADQAw";
		subject.Time = "Mcic";
		subject.TimeCode = "mW";
		//Test Parameters
		subject.AccomplishCode = accomplishCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gvwDNA", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "D3";
		subject.EventCode = "RwD";
		subject.AccomplishCode = "5";
		subject.Date = "gADQAw";
		subject.Time = "Mcic";
		subject.TimeCode = "mW";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gADQAw", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "D3";
		subject.EventCode = "RwD";
		subject.AccomplishCode = "5";
		subject.StandardPointLocationCode = "gvwDNA";
		subject.Time = "Mcic";
		subject.TimeCode = "mW";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mcic", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "D3";
		subject.EventCode = "RwD";
		subject.AccomplishCode = "5";
		subject.StandardPointLocationCode = "gvwDNA";
		subject.Date = "gADQAw";
		subject.TimeCode = "mW";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mW", true)]
	public void Validation_RequiredTimeCode(string timeCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "D3";
		subject.EventCode = "RwD";
		subject.AccomplishCode = "5";
		subject.StandardPointLocationCode = "gvwDNA";
		subject.Date = "gADQAw";
		subject.Time = "Mcic";
		//Test Parameters
		subject.TimeCode = timeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
