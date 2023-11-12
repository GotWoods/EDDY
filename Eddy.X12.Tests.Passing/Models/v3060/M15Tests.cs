using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*q*y*wSyqQb*x*Ly*5OMH*NP*v*wv*IZ*1u*k";

		var expected = new M15_USCustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "q",
			ReferenceIdentification = "y",
			Date = "wSyqQb",
			LocationIdentifier = "x",
			StandardCarrierAlphaCode = "Ly",
			Time = "5OMH",
			SealNumber = "NP",
			ReferenceIdentification2 = "v",
			StandardCarrierAlphaCode2 = "wv",
			CityName = "IZ",
			StateOrProvinceCode = "1u",
			YesNoConditionOrResponseCode = "k",
		};

		var actual = Map.MapObject<M15_USCustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.ReferenceIdentification = "y";
		subject.Date = "wSyqQb";
		subject.Time = "5OMH";
		subject.NotificationEntityQualifier = notificationEntityQualifier;
			subject.LocationIdentifier = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.Date = "wSyqQb";
		subject.Time = "5OMH";
		subject.ReferenceIdentification = referenceIdentification;
			subject.LocationIdentifier = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wSyqQb", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "y";
		subject.Time = "5OMH";
		subject.Date = date;
			subject.LocationIdentifier = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("x", "IZ", true)]
	[InlineData("x", "", true)]
	[InlineData("", "IZ", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "y";
		subject.Date = "wSyqQb";
		subject.Time = "5OMH";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5OMH", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "y";
		subject.Date = "wSyqQb";
		subject.Time = time;
			subject.LocationIdentifier = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1u", "IZ", true)]
	[InlineData("1u", "", false)]
	[InlineData("", "IZ", true)]
	public void Validation_ARequiresBCityName(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_USCustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "y";
		subject.Date = "wSyqQb";
		subject.Time = "5OMH";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
			subject.LocationIdentifier = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
