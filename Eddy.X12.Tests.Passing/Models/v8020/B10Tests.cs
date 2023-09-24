using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class B10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B10*t*Y*8G*2*3j*2*e*zac0s94y*48BA";

		var expected = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage()
		{
			ReferenceIdentification = "t",
			ShipmentIdentificationNumber = "Y",
			StandardCarrierAlphaCode = "8G",
			InquiryRequestNumber = 2,
			ReferenceIdentificationQualifier = "3j",
			ReferenceIdentification2 = "2",
			YesNoConditionOrResponseCode = "e",
			Date = "zac0s94y",
			Time = "48BA",
		};

		var actual = Map.MapObject<B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("t", "", true)]
	[InlineData("", "2", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "8G";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "3j";
			subject.ReferenceIdentification2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Date = "zac0s94y";
			subject.Time = "48BA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("t", "3j", false)]
	[InlineData("t", "", true)]
	[InlineData("", "3j", true)]
	public void Validation_OnlyOneOfReferenceIdentification(string referenceIdentification, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "8G";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "3j";
			subject.ReferenceIdentification2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Date = "zac0s94y";
			subject.Time = "48BA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8G", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.ReferenceIdentification = "t";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "3j";
			subject.ReferenceIdentification2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Date = "zac0s94y";
			subject.Time = "48BA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "8G";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;
			subject.ReferenceIdentification = "t";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Date = "zac0s94y";
			subject.Time = "48BA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zac0s94y", "48BA", true)]
	[InlineData("zac0s94y", "", false)]
	[InlineData("", "48BA", false)]
	public void Validation_AllAreRequiredDate(string date, string time, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "8G";
		subject.Date = date;
		subject.Time = time;
			subject.ReferenceIdentification = "t";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "3j";
			subject.ReferenceIdentification2 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
