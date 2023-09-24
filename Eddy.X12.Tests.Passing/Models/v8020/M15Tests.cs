using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*k*7*oTRY0esc*Z*cw*B7K3*b*g*OG*qV*pP*m*yz*1*Sc*t*9*xbaI4xua*uL7u";

		var expected = new M15_CustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "k",
			ReferenceIdentification = "7",
			Date = "oTRY0esc",
			LocationIdentifier = "Z",
			StandardCarrierAlphaCode = "cw",
			Time = "B7K3",
			SealNumber = "b",
			ReferenceIdentification2 = "g",
			StandardCarrierAlphaCode2 = "OG",
			CityName = "qV",
			StateOrProvinceCode = "pP",
			YesNoConditionOrResponseCode = "m",
			ReferenceIdentificationQualifier = "yz",
			ReferenceIdentification3 = "1",
			VesselName = "Sc",
			TransportationMethodTypeCode = "t",
			LocationIdentifier2 = "9",
			Date2 = "xbaI4xua",
			Time2 = "uL7u",
		};

		var actual = Map.MapObject<M15_CustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.ReferenceIdentification = "7";
		subject.Date = "oTRY0esc";
		subject.Time = "B7K3";
		subject.NotificationEntityQualifier = notificationEntityQualifier;
			subject.LocationIdentifier = "Z";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "yz";
			subject.ReferenceIdentification3 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "xbaI4xua";
			subject.Time2 = "uL7u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "k";
		subject.Date = "oTRY0esc";
		subject.Time = "B7K3";
		subject.ReferenceIdentification = referenceIdentification;
			subject.LocationIdentifier = "Z";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "yz";
			subject.ReferenceIdentification3 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "xbaI4xua";
			subject.Time2 = "uL7u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oTRY0esc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "k";
		subject.ReferenceIdentification = "7";
		subject.Time = "B7K3";
		subject.Date = date;
			subject.LocationIdentifier = "Z";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "yz";
			subject.ReferenceIdentification3 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "xbaI4xua";
			subject.Time2 = "uL7u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Z", "qV", true)]
	[InlineData("Z", "", true)]
	[InlineData("", "qV", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "k";
		subject.ReferenceIdentification = "7";
		subject.Date = "oTRY0esc";
		subject.Time = "B7K3";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "yz";
			subject.ReferenceIdentification3 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "xbaI4xua";
			subject.Time2 = "uL7u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B7K3", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "k";
		subject.ReferenceIdentification = "7";
		subject.Date = "oTRY0esc";
		subject.Time = time;
			subject.LocationIdentifier = "Z";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "yz";
			subject.ReferenceIdentification3 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "xbaI4xua";
			subject.Time2 = "uL7u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pP", "qV", true)]
	[InlineData("pP", "", false)]
	[InlineData("", "qV", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "k";
		subject.ReferenceIdentification = "7";
		subject.Date = "oTRY0esc";
		subject.Time = "B7K3";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
			subject.LocationIdentifier = "Z";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "yz";
			subject.ReferenceIdentification3 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "xbaI4xua";
			subject.Time2 = "uL7u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yz", "1", true)]
	[InlineData("yz", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "k";
		subject.ReferenceIdentification = "7";
		subject.Date = "oTRY0esc";
		subject.Time = "B7K3";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification3 = referenceIdentification3;
			subject.LocationIdentifier = "Z";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "xbaI4xua";
			subject.Time2 = "uL7u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Sc", "t", true)]
	[InlineData("Sc", "", false)]
	[InlineData("", "t", true)]
	public void Validation_ARequiresBVesselName(string vesselName, string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "k";
		subject.ReferenceIdentification = "7";
		subject.Date = "oTRY0esc";
		subject.Time = "B7K3";
		subject.VesselName = vesselName;
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.LocationIdentifier = "Z";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "yz";
			subject.ReferenceIdentification3 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "xbaI4xua";
			subject.Time2 = "uL7u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xbaI4xua", "uL7u", true)]
	[InlineData("xbaI4xua", "", false)]
	[InlineData("", "uL7u", false)]
	public void Validation_AllAreRequiredDate2(string date2, string time2, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "k";
		subject.ReferenceIdentification = "7";
		subject.Date = "oTRY0esc";
		subject.Time = "B7K3";
		subject.Date2 = date2;
		subject.Time2 = time2;
			subject.LocationIdentifier = "Z";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "yz";
			subject.ReferenceIdentification3 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
