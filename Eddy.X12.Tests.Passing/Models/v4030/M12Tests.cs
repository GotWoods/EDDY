using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class M12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M12*Xw*I*f*j*DI*s*x1*t9*z*q*j0";

		var expected = new M12_InBondIdentifyingInformation()
		{
			CustomsEntryTypeCode = "Xw",
			CustomsEntryNumber = "I",
			LocationIdentifier = "f",
			LocationIdentifier2 = "j",
			CustomsShipmentValue = "DI",
			InBondControlNumber = "s",
			StandardCarrierAlphaCode = "x1",
			ReferenceIdentificationQualifier = "t9",
			ReferenceIdentification = "z",
			TransportationMethodTypeCode = "q",
			VesselName = "j0",
		};

		var actual = Map.MapObject<M12_InBondIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xw", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "t9";
			subject.ReferenceIdentification = "z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "q";
			subject.VesselName = "j0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "s", false)]
	[InlineData("I", "", true)]
	[InlineData("", "s", true)]
	public void Validation_OnlyOneOfCustomsEntryNumber(string customsEntryNumber, string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "Xw";
		subject.CustomsEntryNumber = customsEntryNumber;
		subject.InBondControlNumber = inBondControlNumber;
		if (inBondControlNumber != "")
			subject.ReferenceIdentificationQualifier = "t9";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "t9";
			subject.ReferenceIdentification = "z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "q";
			subject.VesselName = "j0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "t9", true)]
	[InlineData("s", "", false)]
	[InlineData("", "t9", true)]
	public void Validation_ARequiresBInBondControlNumber(string inBondControlNumber, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "Xw";
		subject.InBondControlNumber = inBondControlNumber;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "t9";
			subject.ReferenceIdentification = "z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "q";
			subject.VesselName = "j0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t9", "z", true)]
	[InlineData("t9", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "Xw";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "q";
			subject.VesselName = "j0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "j0", true)]
	[InlineData("q", "", false)]
	[InlineData("", "j0", false)]
	public void Validation_AllAreRequiredTransportationMethodTypeCode(string transportationMethodTypeCode, string vesselName, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "Xw";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		subject.VesselName = vesselName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "t9";
			subject.ReferenceIdentification = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
