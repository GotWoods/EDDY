using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*d*V*7LSRK6Te*n*qu*mwDW*mQ*D*xa*aR*RY*H*Ks*K*5U*Q*8*CjysaCTZ*s7Yw";

		var expected = new M15_CustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "d",
			ReferenceIdentification = "V",
			Date = "7LSRK6Te",
			LocationIdentifier = "n",
			StandardCarrierAlphaCode = "qu",
			Time = "mwDW",
			SealNumber = "mQ",
			ReferenceIdentification2 = "D",
			StandardCarrierAlphaCode2 = "xa",
			CityName = "aR",
			StateOrProvinceCode = "RY",
			YesNoConditionOrResponseCode = "H",
			ReferenceIdentificationQualifier = "Ks",
			ReferenceIdentification3 = "K",
			VesselName = "5U",
			TransportationMethodTypeCode = "Q",
			LocationIdentifier2 = "8",
			Date2 = "CjysaCTZ",
			Time2 = "s7Yw",
		};

		var actual = Map.MapObject<M15_CustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.ReferenceIdentification = "V";
		subject.Date = "7LSRK6Te";
		subject.Time = "mwDW";
		subject.NotificationEntityQualifier = notificationEntityQualifier;
			subject.LocationIdentifier = "n";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "Ks";
			subject.ReferenceIdentification3 = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "CjysaCTZ";
			subject.Time2 = "s7Yw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "d";
		subject.Date = "7LSRK6Te";
		subject.Time = "mwDW";
		subject.ReferenceIdentification = referenceIdentification;
			subject.LocationIdentifier = "n";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "Ks";
			subject.ReferenceIdentification3 = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "CjysaCTZ";
			subject.Time2 = "s7Yw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7LSRK6Te", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "d";
		subject.ReferenceIdentification = "V";
		subject.Time = "mwDW";
		subject.Date = date;
			subject.LocationIdentifier = "n";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "Ks";
			subject.ReferenceIdentification3 = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "CjysaCTZ";
			subject.Time2 = "s7Yw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("n", "aR", true)]
	[InlineData("n", "", true)]
	[InlineData("", "aR", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "d";
		subject.ReferenceIdentification = "V";
		subject.Date = "7LSRK6Te";
		subject.Time = "mwDW";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "Ks";
			subject.ReferenceIdentification3 = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "CjysaCTZ";
			subject.Time2 = "s7Yw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mwDW", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "d";
		subject.ReferenceIdentification = "V";
		subject.Date = "7LSRK6Te";
		subject.Time = time;
			subject.LocationIdentifier = "n";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "Ks";
			subject.ReferenceIdentification3 = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "CjysaCTZ";
			subject.Time2 = "s7Yw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RY", "aR", true)]
	[InlineData("RY", "", false)]
	[InlineData("", "aR", true)]
	public void Validation_ARequiresBCityName(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "d";
		subject.ReferenceIdentification = "V";
		subject.Date = "7LSRK6Te";
		subject.Time = "mwDW";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
			subject.LocationIdentifier = "n";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "Ks";
			subject.ReferenceIdentification3 = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "CjysaCTZ";
			subject.Time2 = "s7Yw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ks", "K", true)]
	[InlineData("Ks", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "d";
		subject.ReferenceIdentification = "V";
		subject.Date = "7LSRK6Te";
		subject.Time = "mwDW";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification3 = referenceIdentification3;
			subject.LocationIdentifier = "n";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "CjysaCTZ";
			subject.Time2 = "s7Yw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5U", "Q", true)]
	[InlineData("5U", "", false)]
	[InlineData("", "Q", true)]
	public void Validation_ARequiresBVesselName(string vesselName, string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "d";
		subject.ReferenceIdentification = "V";
		subject.Date = "7LSRK6Te";
		subject.Time = "mwDW";
		subject.VesselName = vesselName;
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.LocationIdentifier = "n";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "Ks";
			subject.ReferenceIdentification3 = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "CjysaCTZ";
			subject.Time2 = "s7Yw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CjysaCTZ", "s7Yw", true)]
	[InlineData("CjysaCTZ", "", false)]
	[InlineData("", "s7Yw", false)]
	public void Validation_AllAreRequiredDate2(string date2, string time2, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "d";
		subject.ReferenceIdentification = "V";
		subject.Date = "7LSRK6Te";
		subject.Time = "mwDW";
		subject.Date2 = date2;
		subject.Time2 = time2;
			subject.LocationIdentifier = "n";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "Ks";
			subject.ReferenceIdentification3 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
