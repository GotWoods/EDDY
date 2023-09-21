using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class B10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B10*H*x*V8*7*9Q*t*g*kW23eM6p*qdfC";

		var expected = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage()
		{
			ReferenceIdentification = "H",
			ShipmentIdentificationNumber = "x",
			StandardCarrierAlphaCode = "V8",
			InquiryRequestNumber = 7,
			ReferenceIdentificationQualifier = "9Q",
			ReferenceIdentification2 = "t",
			YesNoConditionOrResponseCode = "g",
			Date = "kW23eM6p",
			Time = "qdfC",
		};

		var actual = Map.MapObject<B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("H", "", true)]
	[InlineData("", "t", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "V8";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "9Q";
			subject.ReferenceIdentification2 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("H", "9Q", false)]
	[InlineData("H", "", true)]
	[InlineData("", "9Q", true)]
	public void Validation_OnlyOneOfReferenceIdentification(string referenceIdentification, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "V8";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "9Q";
			subject.ReferenceIdentification2 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V8", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.ReferenceIdentification = "H";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "9Q";
			subject.ReferenceIdentification2 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}



	[Theory]
	[InlineData("", "", true)]
	[InlineData("kW23eM6p", "qdfC", true)]
	[InlineData("kW23eM6p", "", false)]
	[InlineData("", "qdfC", false)]
	public void Validation_AllAreRequiredTime(string date, string time, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "V8";
		subject.Date = date;
		subject.Time = time;
			subject.ReferenceIdentification = "H";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "9Q";
			subject.ReferenceIdentification2 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
