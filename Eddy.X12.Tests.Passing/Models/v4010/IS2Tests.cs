using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class IS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS2*XZ*Pvr*w*I9HJT5*7DhdpZYF*ZGj8*AJ*ez*O*Z1iAkbJM*g*WRWUY3QO*yxao*Ri1QeSKS*OFgr*gy*YQ";

		var expected = new IS2_ScheduledEvents()
		{
			StandardCarrierAlphaCode = "XZ",
			EventCode = "Pvr",
			AccomplishCode = "w",
			StandardPointLocationCode = "I9HJT5",
			Date = "7DhdpZYF",
			Time = "ZGj8",
			TimeCode = "AJ",
			StandardCarrierAlphaCode2 = "ez",
			InterchangeTrainIdentification = "O",
			Date2 = "Z1iAkbJM",
			BlockIdentification = "g",
			Date3 = "WRWUY3QO",
			Time2 = "yxao",
			Date4 = "Ri1QeSKS",
			Time3 = "OFgr",
			CityName = "gy",
			StateOrProvinceCode = "YQ",
		};

		var actual = Map.MapObject<IS2_ScheduledEvents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XZ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.EventCode = "Pvr";
		subject.AccomplishCode = "w";
		subject.StandardPointLocationCode = "I9HJT5";
		subject.Date = "7DhdpZYF";
		subject.Time = "ZGj8";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pvr", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "XZ";
		subject.AccomplishCode = "w";
		subject.StandardPointLocationCode = "I9HJT5";
		subject.Date = "7DhdpZYF";
		subject.Time = "ZGj8";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "XZ";
		subject.EventCode = "Pvr";
		subject.StandardPointLocationCode = "I9HJT5";
		subject.Date = "7DhdpZYF";
		subject.Time = "ZGj8";
		//Test Parameters
		subject.AccomplishCode = accomplishCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I9HJT5", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "XZ";
		subject.EventCode = "Pvr";
		subject.AccomplishCode = "w";
		subject.Date = "7DhdpZYF";
		subject.Time = "ZGj8";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7DhdpZYF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "XZ";
		subject.EventCode = "Pvr";
		subject.AccomplishCode = "w";
		subject.StandardPointLocationCode = "I9HJT5";
		subject.Time = "ZGj8";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZGj8", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "XZ";
		subject.EventCode = "Pvr";
		subject.AccomplishCode = "w";
		subject.StandardPointLocationCode = "I9HJT5";
		subject.Date = "7DhdpZYF";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YQ", "gy", true)]
	[InlineData("YQ", "", false)]
	[InlineData("", "gy", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new IS2_ScheduledEvents();
		//Required fields
		subject.StandardCarrierAlphaCode = "XZ";
		subject.EventCode = "Pvr";
		subject.AccomplishCode = "w";
		subject.StandardPointLocationCode = "I9HJT5";
		subject.Date = "7DhdpZYF";
		subject.Time = "ZGj8";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
