using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS2*7e*DV0*E*4k2nlX*R9g25POV*bEJy*x6*lH*I*fwIdZ7gA*u*HdaGIije*T6te*bwbccVqK*QWhK*6V*pI";

		var expected = new IS2_ScheduledEvents()
		{
			StandardCarrierAlphaCode = "7e",
			EventCode = "DV0",
			AccomplishCode = "E",
			StandardPointLocationCode = "4k2nlX",
			Date = "R9g25POV",
			Time = "bEJy",
			TimeCode = "x6",
			StandardCarrierAlphaCode2 = "lH",
			InterchangeTrainIdentification = "I",
			Date2 = "fwIdZ7gA",
			BlockIdentifier = "u",
			Date3 = "HdaGIije",
			Time2 = "T6te",
			Date4 = "bwbccVqK",
			Time3 = "QWhK",
			CityName = "6V",
			StateOrProvinceCode = "pI",
		};

		var actual = Map.MapObject<IS2_ScheduledEvents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7e", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		subject.EventCode = "DV0";
		subject.AccomplishCode = "E";
		subject.StandardPointLocationCode = "4k2nlX";
		subject.Date = "R9g25POV";
		subject.Time = "bEJy";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DV0", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		subject.StandardCarrierAlphaCode = "7e";
		subject.AccomplishCode = "E";
		subject.StandardPointLocationCode = "4k2nlX";
		subject.Date = "R9g25POV";
		subject.Time = "bEJy";
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		subject.StandardCarrierAlphaCode = "7e";
		subject.EventCode = "DV0";
		subject.StandardPointLocationCode = "4k2nlX";
		subject.Date = "R9g25POV";
		subject.Time = "bEJy";
		subject.AccomplishCode = accomplishCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4k2nlX", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		subject.StandardCarrierAlphaCode = "7e";
		subject.EventCode = "DV0";
		subject.AccomplishCode = "E";
		subject.Date = "R9g25POV";
		subject.Time = "bEJy";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R9g25POV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		subject.StandardCarrierAlphaCode = "7e";
		subject.EventCode = "DV0";
		subject.AccomplishCode = "E";
		subject.StandardPointLocationCode = "4k2nlX";
		subject.Time = "bEJy";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bEJy", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		subject.StandardCarrierAlphaCode = "7e";
		subject.EventCode = "DV0";
		subject.AccomplishCode = "E";
		subject.StandardPointLocationCode = "4k2nlX";
		subject.Date = "R9g25POV";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "6V", true)]
	[InlineData("pI", "", false)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		subject.StandardCarrierAlphaCode = "7e";
		subject.EventCode = "DV0";
		subject.AccomplishCode = "E";
		subject.StandardPointLocationCode = "4k2nlX";
		subject.Date = "R9g25POV";
		subject.Time = "bEJy";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
