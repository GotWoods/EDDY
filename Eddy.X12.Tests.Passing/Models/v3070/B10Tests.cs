using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class B10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B10*V*Y*vy*3*gK*9";

		var expected = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage()
		{
			ReferenceIdentification = "V",
			ShipmentIdentificationNumber = "Y",
			StandardCarrierAlphaCode = "vy",
			InquiryRequestNumber = 3,
			ReferenceIdentificationQualifier = "gK",
			ReferenceIdentification2 = "9",
		};

		var actual = Map.MapObject<B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}


	[Theory]
	[InlineData("", false)]
	[InlineData("vy", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.ReferenceIdentification = "V";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "gK";
			subject.ReferenceIdentification2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("gK", "9", true)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
		subject.StandardCarrierAlphaCode = "vy";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
