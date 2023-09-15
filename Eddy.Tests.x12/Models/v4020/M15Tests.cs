using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*U*c*DMc7jvBf*B*op*GVsP*rN*H*GC*7r*3K*C*8J*g*rh*3";

		var expected = new M15_CustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "U",
			ReferenceIdentification = "c",
			Date = "DMc7jvBf",
			LocationIdentifier = "B",
			StandardCarrierAlphaCode = "op",
			Time = "GVsP",
			SealNumber = "rN",
			ReferenceIdentification2 = "H",
			StandardCarrierAlphaCode2 = "GC",
			CityName = "7r",
			StateOrProvinceCode = "3K",
			YesNoConditionOrResponseCode = "C",
			ReferenceIdentificationQualifier = "8J",
			ReferenceIdentification3 = "g",
			VesselName = "rh",
			TransportationMethodTypeCode = "3",
		};

		var actual = Map.MapObject<M15_CustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.ReferenceIdentification = "c";
		subject.Date = "DMc7jvBf";
		subject.Time = "GVsP";
		subject.NotificationEntityQualifier = notificationEntityQualifier;
			subject.LocationIdentifier = "B";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "8J";
			subject.ReferenceIdentification3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "U";
		subject.Date = "DMc7jvBf";
		subject.Time = "GVsP";
		subject.ReferenceIdentification = referenceIdentification;
			subject.LocationIdentifier = "B";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "8J";
			subject.ReferenceIdentification3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DMc7jvBf", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "U";
		subject.ReferenceIdentification = "c";
		subject.Time = "GVsP";
		subject.Date = date;
			subject.LocationIdentifier = "B";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "8J";
			subject.ReferenceIdentification3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("B", "7r", true)]
	[InlineData("B", "", true)]
	[InlineData("", "7r", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "U";
		subject.ReferenceIdentification = "c";
		subject.Date = "DMc7jvBf";
		subject.Time = "GVsP";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "8J";
			subject.ReferenceIdentification3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GVsP", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "U";
		subject.ReferenceIdentification = "c";
		subject.Date = "DMc7jvBf";
		subject.Time = time;
			subject.LocationIdentifier = "B";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "8J";
			subject.ReferenceIdentification3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3K", "7r", true)]
	[InlineData("3K", "", false)]
	[InlineData("", "7r", true)]
	public void Validation_ARequiresBCityName(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "U";
		subject.ReferenceIdentification = "c";
		subject.Date = "DMc7jvBf";
		subject.Time = "GVsP";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
			subject.LocationIdentifier = "B";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "8J";
			subject.ReferenceIdentification3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8J", "g", true)]
	[InlineData("8J", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "U";
		subject.ReferenceIdentification = "c";
		subject.Date = "DMc7jvBf";
		subject.Time = "GVsP";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification3 = referenceIdentification3;
			subject.LocationIdentifier = "B";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
