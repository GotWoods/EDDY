using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class IS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS2*2a*5kd*G*rIgcL4*a63xV3*O99s*PJ*nm*9*MhXLmD*l*dElcpd*PaHj*ifgzYY*RXAM";

		var expected = new IS2_ScheduledEvents()
		{
			StandardCarrierAlphaCode = "2a",
			EventCode = "5kd",
			AccomplishCode = "G",
			StandardPointLocationCode = "rIgcL4",
			Date = "a63xV3",
			Time = "O99s",
			TimeCode = "PJ",
			StandardCarrierAlphaCode2 = "nm",
			InterchangeTrainIdentification = "9",
			Date2 = "MhXLmD",
			BlockIdentification = "l",
			Date3 = "dElcpd",
			Time2 = "PaHj",
			Date4 = "ifgzYY",
			Time3 = "RXAM",
		};

		var actual = Map.MapObject<IS2_ScheduledEvents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2a", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.EventCode = "5kd";
		subject.AccomplishCode = "G";
		subject.StandardPointLocationCode = "rIgcL4";
		subject.Date = "a63xV3";
		subject.Time = "O99s";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5kd", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "2a";
		subject.AccomplishCode = "G";
		subject.StandardPointLocationCode = "rIgcL4";
		subject.Date = "a63xV3";
		subject.Time = "O99s";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "2a";
		subject.EventCode = "5kd";
		subject.StandardPointLocationCode = "rIgcL4";
		subject.Date = "a63xV3";
		subject.Time = "O99s";
		//Test Parameters
		subject.AccomplishCode = accomplishCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rIgcL4", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "2a";
		subject.EventCode = "5kd";
		subject.AccomplishCode = "G";
		subject.Date = "a63xV3";
		subject.Time = "O99s";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a63xV3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "2a";
		subject.EventCode = "5kd";
		subject.AccomplishCode = "G";
		subject.StandardPointLocationCode = "rIgcL4";
		subject.Time = "O99s";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O99s", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "2a";
		subject.EventCode = "5kd";
		subject.AccomplishCode = "G";
		subject.StandardPointLocationCode = "rIgcL4";
		subject.Date = "a63xV3";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
