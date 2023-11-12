using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class IS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS2*ev*vZR*K*3GN4em*i4AhiTTz*QV9C*Tw*42*0*YlRHE8em*R*4TaksRyu*Uu5M*ZJAXZ5rb*zXCd*19*DL";

		var expected = new IS2_ScheduledEvents()
		{
			StandardCarrierAlphaCode = "ev",
			EventCode = "vZR",
			AccomplishCode = "K",
			StandardPointLocationCode = "3GN4em",
			Date = "i4AhiTTz",
			Time = "QV9C",
			TimeCode = "Tw",
			StandardCarrierAlphaCode2 = "42",
			InterchangeTrainIdentification = "0",
			Date2 = "YlRHE8em",
			BlockIdentifier = "R",
			Date3 = "4TaksRyu",
			Time2 = "Uu5M",
			Date4 = "ZJAXZ5rb",
			Time3 = "zXCd",
			CityName = "19",
			StateOrProvinceCode = "DL",
		};

		var actual = Map.MapObject<IS2_ScheduledEvents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ev", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.EventCode = "vZR";
		subject.AccomplishCode = "K";
		subject.StandardPointLocationCode = "3GN4em";
		subject.Date = "i4AhiTTz";
		subject.Time = "QV9C";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vZR", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "ev";
		subject.AccomplishCode = "K";
		subject.StandardPointLocationCode = "3GN4em";
		subject.Date = "i4AhiTTz";
		subject.Time = "QV9C";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "ev";
		subject.EventCode = "vZR";
		subject.StandardPointLocationCode = "3GN4em";
		subject.Date = "i4AhiTTz";
		subject.Time = "QV9C";
		//Test Parameters
		subject.AccomplishCode = accomplishCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3GN4em", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "ev";
		subject.EventCode = "vZR";
		subject.AccomplishCode = "K";
		subject.Date = "i4AhiTTz";
		subject.Time = "QV9C";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i4AhiTTz", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "ev";
		subject.EventCode = "vZR";
		subject.AccomplishCode = "K";
		subject.StandardPointLocationCode = "3GN4em";
		subject.Time = "QV9C";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QV9C", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "ev";
		subject.EventCode = "vZR";
		subject.AccomplishCode = "K";
		subject.StandardPointLocationCode = "3GN4em";
		subject.Date = "i4AhiTTz";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DL", "19", true)]
	[InlineData("DL", "", false)]
	[InlineData("", "19", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "ev";
		subject.EventCode = "vZR";
		subject.AccomplishCode = "K";
		subject.StandardPointLocationCode = "3GN4em";
		subject.Date = "i4AhiTTz";
		subject.Time = "QV9C";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
