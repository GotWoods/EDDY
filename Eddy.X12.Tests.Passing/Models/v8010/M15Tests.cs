using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*G*U*ftpizqrT*T*LA*p3Y0*z*z*Gu*Ec*e8*T*DQ*9*hz*Q*C*a6f38cdM*Ogdi";

		var expected = new M15_CustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "G",
			ReferenceIdentification = "U",
			Date = "ftpizqrT",
			LocationIdentifier = "T",
			StandardCarrierAlphaCode = "LA",
			Time = "p3Y0",
			SealNumber = "z",
			ReferenceIdentification2 = "z",
			StandardCarrierAlphaCode2 = "Gu",
			CityName = "Ec",
			StateOrProvinceCode = "e8",
			YesNoConditionOrResponseCode = "T",
			ReferenceIdentificationQualifier = "DQ",
			ReferenceIdentification3 = "9",
			VesselName = "hz",
			TransportationMethodTypeCode = "Q",
			LocationIdentifier2 = "C",
			Date2 = "a6f38cdM",
			Time2 = "Ogdi",
		};

		var actual = Map.MapObject<M15_CustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.ReferenceIdentification = "U";
		subject.Date = "ftpizqrT";
		subject.Time = "p3Y0";
		subject.NotificationEntityQualifier = notificationEntityQualifier;
			subject.LocationIdentifier = "T";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "DQ";
			subject.ReferenceIdentification3 = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "a6f38cdM";
			subject.Time2 = "Ogdi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "G";
		subject.Date = "ftpizqrT";
		subject.Time = "p3Y0";
		subject.ReferenceIdentification = referenceIdentification;
			subject.LocationIdentifier = "T";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "DQ";
			subject.ReferenceIdentification3 = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "a6f38cdM";
			subject.Time2 = "Ogdi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ftpizqrT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "G";
		subject.ReferenceIdentification = "U";
		subject.Time = "p3Y0";
		subject.Date = date;
			subject.LocationIdentifier = "T";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "DQ";
			subject.ReferenceIdentification3 = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "a6f38cdM";
			subject.Time2 = "Ogdi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("T", "Ec", true)]
	[InlineData("T", "", true)]
	[InlineData("", "Ec", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "G";
		subject.ReferenceIdentification = "U";
		subject.Date = "ftpizqrT";
		subject.Time = "p3Y0";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "DQ";
			subject.ReferenceIdentification3 = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "a6f38cdM";
			subject.Time2 = "Ogdi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p3Y0", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "G";
		subject.ReferenceIdentification = "U";
		subject.Date = "ftpizqrT";
		subject.Time = time;
			subject.LocationIdentifier = "T";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "DQ";
			subject.ReferenceIdentification3 = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "a6f38cdM";
			subject.Time2 = "Ogdi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e8", "Ec", true)]
	[InlineData("e8", "", false)]
	[InlineData("", "Ec", true)]
	public void Validation_ARequiresBCityName(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "G";
		subject.ReferenceIdentification = "U";
		subject.Date = "ftpizqrT";
		subject.Time = "p3Y0";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
			subject.LocationIdentifier = "T";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "DQ";
			subject.ReferenceIdentification3 = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "a6f38cdM";
			subject.Time2 = "Ogdi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DQ", "9", true)]
	[InlineData("DQ", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "G";
		subject.ReferenceIdentification = "U";
		subject.Date = "ftpizqrT";
		subject.Time = "p3Y0";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification3 = referenceIdentification3;
			subject.LocationIdentifier = "T";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "a6f38cdM";
			subject.Time2 = "Ogdi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hz", "Q", true)]
	[InlineData("hz", "", false)]
	[InlineData("", "Q", true)]
	public void Validation_ARequiresBVesselName(string vesselName, string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "G";
		subject.ReferenceIdentification = "U";
		subject.Date = "ftpizqrT";
		subject.Time = "p3Y0";
		subject.VesselName = vesselName;
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.LocationIdentifier = "T";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "DQ";
			subject.ReferenceIdentification3 = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "a6f38cdM";
			subject.Time2 = "Ogdi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a6f38cdM", "Ogdi", true)]
	[InlineData("a6f38cdM", "", false)]
	[InlineData("", "Ogdi", false)]
	public void Validation_AllAreRequiredDate2(string date2, string time2, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "G";
		subject.ReferenceIdentification = "U";
		subject.Date = "ftpizqrT";
		subject.Time = "p3Y0";
		subject.Date2 = date2;
		subject.Time2 = time2;
			subject.LocationIdentifier = "T";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "DQ";
			subject.ReferenceIdentification3 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
