using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class B10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B10*P*O*QD*7*iC*7*x*uHsb3RGJ*HR2f";

		var expected = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage()
		{
			ReferenceIdentification = "P",
			ShipmentIdentificationNumber = "O",
			StandardCarrierAlphaCode = "QD",
			InquiryRequestNumber = 7,
			ReferenceIdentificationQualifier = "iC",
			ReferenceIdentification2 = "7",
			YesNoConditionOrResponseCode = "x",
			Date = "uHsb3RGJ",
			Time = "HR2f",
		};

		var actual = Map.MapObject<B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("P", "", true)]
	[InlineData("", "7", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "QD";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "iC";
			subject.ReferenceIdentification2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("P", "iC", false)]
	[InlineData("P", "", true)]
	[InlineData("", "iC", true)]
	public void Validation_OnlyOneOfReferenceIdentification(string referenceIdentification, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "QD";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "iC";
			subject.ReferenceIdentification2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QD", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.ReferenceIdentification = "P";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "iC";
			subject.ReferenceIdentification2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}


	[Theory]
	[InlineData("", "", true)]
	[InlineData("uHsb3RGJ", "HR2f", true)]
	[InlineData("uHsb3RGJ", "", false)]
	[InlineData("", "HR2f", false)]
	public void Validation_AllAreRequiredTime(string date, string time, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "QD";
		subject.Date = date;
		subject.Time = time;
			subject.ReferenceIdentification = "P";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "iC";
			subject.ReferenceIdentification2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
