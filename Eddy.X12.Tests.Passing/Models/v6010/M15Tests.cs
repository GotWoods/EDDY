using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*q*X*H7Fpb6vj*4*le*Tqq5*og*f*Qf*KH*Dm*J*2M*P*yQ*5*f*jxgZuXNk*L9Ex";

		var expected = new M15_CustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "q",
			ReferenceIdentification = "X",
			Date = "H7Fpb6vj",
			LocationIdentifier = "4",
			StandardCarrierAlphaCode = "le",
			Time = "Tqq5",
			SealNumber = "og",
			ReferenceIdentification2 = "f",
			StandardCarrierAlphaCode2 = "Qf",
			CityName = "KH",
			StateOrProvinceCode = "Dm",
			YesNoConditionOrResponseCode = "J",
			ReferenceIdentificationQualifier = "2M",
			ReferenceIdentification3 = "P",
			VesselName = "yQ",
			TransportationMethodTypeCode = "5",
			LocationIdentifier2 = "f",
			Date2 = "jxgZuXNk",
			Time2 = "L9Ex",
		};

		var actual = Map.MapObject<M15_CustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.ReferenceIdentification = "X";
		subject.Date = "H7Fpb6vj";
		subject.Time = "Tqq5";
		subject.NotificationEntityQualifier = notificationEntityQualifier;
			subject.LocationIdentifier = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "2M";
			subject.ReferenceIdentification3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "jxgZuXNk";
			subject.Time2 = "L9Ex";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.Date = "H7Fpb6vj";
		subject.Time = "Tqq5";
		subject.ReferenceIdentification = referenceIdentification;
			subject.LocationIdentifier = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "2M";
			subject.ReferenceIdentification3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "jxgZuXNk";
			subject.Time2 = "L9Ex";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H7Fpb6vj", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "X";
		subject.Time = "Tqq5";
		subject.Date = date;
			subject.LocationIdentifier = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "2M";
			subject.ReferenceIdentification3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "jxgZuXNk";
			subject.Time2 = "L9Ex";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("4", "KH", true)]
	[InlineData("4", "", true)]
	[InlineData("", "KH", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "X";
		subject.Date = "H7Fpb6vj";
		subject.Time = "Tqq5";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "2M";
			subject.ReferenceIdentification3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "jxgZuXNk";
			subject.Time2 = "L9Ex";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tqq5", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "X";
		subject.Date = "H7Fpb6vj";
		subject.Time = time;
			subject.LocationIdentifier = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "2M";
			subject.ReferenceIdentification3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "jxgZuXNk";
			subject.Time2 = "L9Ex";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Dm", "KH", true)]
	[InlineData("Dm", "", false)]
	[InlineData("", "KH", true)]
	public void Validation_ARequiresBCityName(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "X";
		subject.Date = "H7Fpb6vj";
		subject.Time = "Tqq5";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
			subject.LocationIdentifier = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "2M";
			subject.ReferenceIdentification3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "jxgZuXNk";
			subject.Time2 = "L9Ex";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2M", "P", true)]
	[InlineData("2M", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "X";
		subject.Date = "H7Fpb6vj";
		subject.Time = "Tqq5";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification3 = referenceIdentification3;
			subject.LocationIdentifier = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "jxgZuXNk";
			subject.Time2 = "L9Ex";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yQ", "5", true)]
	[InlineData("yQ", "", false)]
	[InlineData("", "5", true)]
	public void Validation_ARequiresBVesselName(string vesselName, string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "X";
		subject.Date = "H7Fpb6vj";
		subject.Time = "Tqq5";
		subject.VesselName = vesselName;
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.LocationIdentifier = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "2M";
			subject.ReferenceIdentification3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Date2 = "jxgZuXNk";
			subject.Time2 = "L9Ex";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jxgZuXNk", "L9Ex", true)]
	[InlineData("jxgZuXNk", "", false)]
	[InlineData("", "L9Ex", false)]
	public void Validation_AllAreRequiredDate2(string date2, string time2, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "q";
		subject.ReferenceIdentification = "X";
		subject.Date = "H7Fpb6vj";
		subject.Time = "Tqq5";
		subject.Date2 = date2;
		subject.Time2 = time2;
			subject.LocationIdentifier = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "2M";
			subject.ReferenceIdentification3 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
