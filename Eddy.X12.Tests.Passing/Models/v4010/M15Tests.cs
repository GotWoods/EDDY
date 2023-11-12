using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*S*X*bJUUNF35*o*uT*XQzu*6t*4*dn*gT*VQ*g";

		var expected = new M15_USCustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "S",
			ReferenceIdentification = "X",
			Date = "bJUUNF35",
			LocationIdentifier = "o",
			StandardCarrierAlphaCode = "uT",
			Time = "XQzu",
			SealNumber = "6t",
			ReferenceIdentification2 = "4",
			StandardCarrierAlphaCode2 = "dn",
			CityName = "gT",
			StateOrProvinceCode = "VQ",
			YesNoConditionOrResponseCode = "g",
		};

		var actual = Map.MapObject<M15_USCustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.ReferenceIdentification = "X";
		subject.Date = "bJUUNF35";
		subject.Time = "XQzu";
		subject.NotificationEntityQualifier = notificationEntityQualifier;
			subject.LocationIdentifier = "o";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "S";
		subject.Date = "bJUUNF35";
		subject.Time = "XQzu";
		subject.ReferenceIdentification = referenceIdentification;
			subject.LocationIdentifier = "o";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bJUUNF35", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "S";
		subject.ReferenceIdentification = "X";
		subject.Time = "XQzu";
		subject.Date = date;
			subject.LocationIdentifier = "o";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("o", "gT", true)]
	[InlineData("o", "", true)]
	[InlineData("", "gT", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "S";
		subject.ReferenceIdentification = "X";
		subject.Date = "bJUUNF35";
		subject.Time = "XQzu";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XQzu", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "S";
		subject.ReferenceIdentification = "X";
		subject.Date = "bJUUNF35";
		subject.Time = time;
			subject.LocationIdentifier = "o";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VQ", "gT", true)]
	[InlineData("VQ", "", false)]
	[InlineData("", "gT", true)]
	public void Validation_ARequiresBCityName(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "S";
		subject.ReferenceIdentification = "X";
		subject.Date = "bJUUNF35";
		subject.Time = "XQzu";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
			subject.LocationIdentifier = "o";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
