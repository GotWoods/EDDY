using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class B10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B10*4*q*Ss*7*7Z*9*w*xnokRjvJ*PmHN";

		var expected = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage()
		{
			ReferenceIdentification = "4",
			ShipmentIdentificationNumber = "q",
			StandardCarrierAlphaCode = "Ss",
			InquiryRequestNumber = 7,
			ReferenceIdentificationQualifier = "7Z",
			ReferenceIdentification2 = "9",
			YesNoConditionOrResponseCode = "w",
			Date = "xnokRjvJ",
			Time = "PmHN",
		};

		var actual = Map.MapObject<B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("4", "", true)]
	[InlineData("", "9", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "Ss";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "7Z";
			subject.ReferenceIdentification2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("4", "7Z", false)]
	[InlineData("4", "", true)]
	[InlineData("", "7Z", true)]
	public void Validation_OnlyOneOfReferenceIdentification(string referenceIdentification, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "Ss";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "7Z";
			subject.ReferenceIdentification2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ss", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.ReferenceIdentification = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "7Z";
			subject.ReferenceIdentification2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}



	[Theory]
	[InlineData("", "", true)]
	[InlineData("xnokRjvJ", "PmHN", true)]
	[InlineData("xnokRjvJ", "", false)]
	[InlineData("", "PmHN", false)]
	public void Validation_AllAreRequiredTime(string date, string time, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "Ss";
		subject.Date = date;
		subject.Time = time;
			subject.ReferenceIdentification = "4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "7Z";
			subject.ReferenceIdentification2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
