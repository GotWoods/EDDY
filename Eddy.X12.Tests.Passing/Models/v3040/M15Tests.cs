using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*E*J*1U8TxQ*X*8a*awzt*T9*k*KD*x9*qR*y";

		var expected = new M15_USCustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "E",
			ReferenceNumber = "J",
			Date = "1U8TxQ",
			LocationIdentifier = "X",
			StandardCarrierAlphaCode = "8a",
			Time = "awzt",
			SealNumber = "T9",
			ReferenceNumber2 = "k",
			StandardCarrierAlphaCode2 = "KD",
			CityName = "x9",
			StateOrProvinceCode = "qR",
			YesNoConditionOrResponseCode = "y",
		};

		var actual = Map.MapObject<M15_USCustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.ReferenceNumber = "J";
		subject.Date = "1U8TxQ";
		subject.LocationIdentifier = "X";
		subject.Time = "awzt";
		subject.NotificationEntityQualifier = notificationEntityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "E";
		subject.Date = "1U8TxQ";
		subject.LocationIdentifier = "X";
		subject.Time = "awzt";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1U8TxQ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "E";
		subject.ReferenceNumber = "J";
		subject.LocationIdentifier = "X";
		subject.Time = "awzt";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "E";
		subject.ReferenceNumber = "J";
		subject.Date = "1U8TxQ";
		subject.Time = "awzt";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("awzt", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "E";
		subject.ReferenceNumber = "J";
		subject.Date = "1U8TxQ";
		subject.LocationIdentifier = "X";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qR", "x9", true)]
	[InlineData("qR", "", false)]
	[InlineData("", "x9", true)]
	public void Validation_ARequiresBCityName(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "E";
		subject.ReferenceNumber = "J";
		subject.Date = "1U8TxQ";
		subject.LocationIdentifier = "X";
		subject.Time = "awzt";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
