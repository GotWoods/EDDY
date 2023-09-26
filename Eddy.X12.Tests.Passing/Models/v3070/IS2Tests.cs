using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class IS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS2*sU*Iis*4*1ujTQW*hPYchK*DjaH*dp*Lv*L*s32nwk*G*mOW0oy*7R8M*an8emw*MdDH*v8*v8";

		var expected = new IS2_ScheduledEvents()
		{
			StandardCarrierAlphaCode = "sU",
			EventCode = "Iis",
			AccomplishCode = "4",
			StandardPointLocationCode = "1ujTQW",
			Date = "hPYchK",
			Time = "DjaH",
			TimeCode = "dp",
			StandardCarrierAlphaCode2 = "Lv",
			InterchangeTrainIdentification = "L",
			Date2 = "s32nwk",
			BlockIdentification = "G",
			Date3 = "mOW0oy",
			Time2 = "7R8M",
			Date4 = "an8emw",
			Time3 = "MdDH",
			CityName = "v8",
			StateOrProvinceCode = "v8",
		};

		var actual = Map.MapObject<IS2_ScheduledEvents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sU", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.EventCode = "Iis";
		subject.AccomplishCode = "4";
		subject.StandardPointLocationCode = "1ujTQW";
		subject.Date = "hPYchK";
		subject.Time = "DjaH";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Iis", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "sU";
		subject.AccomplishCode = "4";
		subject.StandardPointLocationCode = "1ujTQW";
		subject.Date = "hPYchK";
		subject.Time = "DjaH";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "sU";
		subject.EventCode = "Iis";
		subject.StandardPointLocationCode = "1ujTQW";
		subject.Date = "hPYchK";
		subject.Time = "DjaH";
		//Test Parameters
		subject.AccomplishCode = accomplishCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1ujTQW", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "sU";
		subject.EventCode = "Iis";
		subject.AccomplishCode = "4";
		subject.Date = "hPYchK";
		subject.Time = "DjaH";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hPYchK", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "sU";
		subject.EventCode = "Iis";
		subject.AccomplishCode = "4";
		subject.StandardPointLocationCode = "1ujTQW";
		subject.Time = "DjaH";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DjaH", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "sU";
		subject.EventCode = "Iis";
		subject.AccomplishCode = "4";
		subject.StandardPointLocationCode = "1ujTQW";
		subject.Date = "hPYchK";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v8", "v8", true)]
	[InlineData("v8", "", false)]
	[InlineData("", "v8", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "sU";
		subject.EventCode = "Iis";
		subject.AccomplishCode = "4";
		subject.StandardPointLocationCode = "1ujTQW";
		subject.Date = "hPYchK";
		subject.Time = "DjaH";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
