using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*t*M*zJtGgWxk*I*8F*pEvM*Vf*3*c6*Mh*IC*i*x4*J*TW*B*0";

		var expected = new M15_CustomsEventsAdvisoryDetails()
		{
			NotificationEntityQualifier = "t",
			ReferenceIdentification = "M",
			Date = "zJtGgWxk",
			LocationIdentifier = "I",
			StandardCarrierAlphaCode = "8F",
			Time = "pEvM",
			SealNumber = "Vf",
			ReferenceIdentification2 = "3",
			StandardCarrierAlphaCode2 = "c6",
			CityName = "Mh",
			StateOrProvinceCode = "IC",
			YesNoConditionOrResponseCode = "i",
			ReferenceIdentificationQualifier = "x4",
			ReferenceIdentification3 = "J",
			VesselName = "TW",
			TransportationMethodTypeCode = "B",
			LocationIdentifier2 = "0",
		};

		var actual = Map.MapObject<M15_CustomsEventsAdvisoryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredNotificationEntityQualifier(string notificationEntityQualifier, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.ReferenceIdentification = "M";
		subject.Date = "zJtGgWxk";
		subject.Time = "pEvM";
		subject.NotificationEntityQualifier = notificationEntityQualifier;
			subject.LocationIdentifier = "I";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "x4";
			subject.ReferenceIdentification3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "t";
		subject.Date = "zJtGgWxk";
		subject.Time = "pEvM";
		subject.ReferenceIdentification = referenceIdentification;
			subject.LocationIdentifier = "I";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "x4";
			subject.ReferenceIdentification3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zJtGgWxk", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "t";
		subject.ReferenceIdentification = "M";
		subject.Time = "pEvM";
		subject.Date = date;
			subject.LocationIdentifier = "I";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "x4";
			subject.ReferenceIdentification3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("I", "Mh", true)]
	[InlineData("I", "", true)]
	[InlineData("", "Mh", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "t";
		subject.ReferenceIdentification = "M";
		subject.Date = "zJtGgWxk";
		subject.Time = "pEvM";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "x4";
			subject.ReferenceIdentification3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pEvM", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "t";
		subject.ReferenceIdentification = "M";
		subject.Date = "zJtGgWxk";
		subject.Time = time;
			subject.LocationIdentifier = "I";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "x4";
			subject.ReferenceIdentification3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IC", "Mh", true)]
	[InlineData("IC", "", false)]
	[InlineData("", "Mh", true)]
	public void Validation_ARequiresBCityName(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "t";
		subject.ReferenceIdentification = "M";
		subject.Date = "zJtGgWxk";
		subject.Time = "pEvM";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
			subject.LocationIdentifier = "I";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier = "x4";
			subject.ReferenceIdentification3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x4", "J", true)]
	[InlineData("x4", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new M15_CustomsEventsAdvisoryDetails();
		subject.NotificationEntityQualifier = "t";
		subject.ReferenceIdentification = "M";
		subject.Date = "zJtGgWxk";
		subject.Time = "pEvM";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification3 = referenceIdentification3;
			subject.LocationIdentifier = "I";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
