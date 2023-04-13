using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*m*J*VWiBWi86*t*Lr*QU1u*Y*j*uS*3k*ww*m*EZ*Y*NQ*F*b*QHwLd2zE*nzz5";

		var expected = new M15_CustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "m",
			ReferenceIdentification = "J",
			Date = "VWiBWi86",
			LocationIdentifier = "t",
			StandardCarrierAlphaCode = "Lr",
			Time = "QU1u",
			SealNumber = "Y",
			ReferenceIdentification2 = "j",
			StandardCarrierAlphaCode2 = "uS",
			CityName = "3k",
			StateOrProvinceCode = "ww",
			YesNoConditionOrResponseCode = "m",
			ReferenceIdentificationQualifier = "EZ",
			ReferenceIdentification3 = "Y",
			VesselName = "NQ",
			TransportationMethodTypeCode = "F",
			LocationIdentifier2 = "b",
			Date2 = "QHwLd2zE",
			Time2 = "nzz5",
		};

		var actual = Map.MapObject<M15_CustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.ReferenceIdentification = "J";
		subject.Date = "VWiBWi86";
		subject.Time = "QU1u";
        subject.LocationIdentifier = "AA";
        subject.NotificationEntityQualifier = notificationEntityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "m";
		subject.Date = "VWiBWi86";
		subject.Time = "QU1u";
        subject.LocationIdentifier = "AA";
        subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VWiBWi86", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "m";
		subject.ReferenceIdentification = "J";
		subject.Time = "QU1u";
        subject.LocationIdentifier = "AA";
        subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("t","3k", true)]
	[InlineData("", "3k", true)]
	[InlineData("t", "", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "m";
		subject.ReferenceIdentification = "J";
		subject.Date = "VWiBWi86";
		subject.Time = "QU1u";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QU1u", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "m";
		subject.ReferenceIdentification = "J";
		subject.Date = "VWiBWi86";
        subject.LocationIdentifier = "AA";
        subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "3k", true)]
	[InlineData("ww", "", false)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "m";
		subject.ReferenceIdentification = "J";
		subject.Date = "VWiBWi86";
		subject.Time = "QU1u";
        subject.LocationIdentifier = "AA";
        subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("EZ", "Y", true)]
	[InlineData("", "Y", false)]
	[InlineData("EZ", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "m";
		subject.ReferenceIdentification = "J";
		subject.Date = "VWiBWi86";
		subject.Time = "QU1u";
        subject.LocationIdentifier = "AA";
        subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification3 = referenceIdentification3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "F", true)]
	[InlineData("NQ", "", false)]
	public void Validation_ARequiresBVesselName(string vesselName, string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "m";
		subject.ReferenceIdentification = "J";
		subject.Date = "VWiBWi86";
		subject.Time = "QU1u";
        subject.LocationIdentifier = "AA";
        subject.VesselName = vesselName;
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("QHwLd2zE", "nzz5", true)]
	[InlineData("", "nzz5", false)]
	[InlineData("QHwLd2zE", "", false)]
	public void Validation_AllAreRequiredDate2(string date2, string time2, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "m";
		subject.ReferenceIdentification = "J";
		subject.Date = "VWiBWi86";
		subject.Time = "QU1u";
        subject.LocationIdentifier = "AA";
        subject.Date2 = date2;
		subject.Time2 = time2;
		
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
