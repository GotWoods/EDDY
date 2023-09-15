using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class M12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M12*N3*C*L*h*Gu*l*V9*41*6*N*jk";

		var expected = new M12_InBondIdentifyingInformation()
		{
			CustomsEntryTypeCode = "N3",
			CustomsEntryNumber = "C",
			LocationIdentifier = "L",
			LocationIdentifier2 = "h",
			CustomsShipmentValue = "Gu",
			InBondControlNumber = "l",
			StandardCarrierAlphaCode = "V9",
			ReferenceIdentificationQualifier = "41",
			ReferenceIdentification = "6",
			TransportationMethodTypeCode = "N",
			VesselName = "jk",
		};

		var actual = Map.MapObject<M12_InBondIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N3", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "41";
			subject.ReferenceIdentification = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "N";
			subject.VesselName = "jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "l", false)]
	[InlineData("C", "", true)]
	[InlineData("", "l", true)]
	public void Validation_OnlyOneOfCustomsEntryNumber(string customsEntryNumber, string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "N3";
		subject.CustomsEntryNumber = customsEntryNumber;
		subject.InBondControlNumber = inBondControlNumber;
		if (inBondControlNumber != "")
			subject.ReferenceIdentificationQualifier = "41";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "41";
			subject.ReferenceIdentification = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "N";
			subject.VesselName = "jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "41", true)]
	[InlineData("l", "", false)]
	[InlineData("", "41", true)]
	public void Validation_ARequiresBInBondControlNumber(string inBondControlNumber, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "N3";
		subject.InBondControlNumber = inBondControlNumber;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "41";
			subject.ReferenceIdentification = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "N";
			subject.VesselName = "jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("41", "6", true)]
	[InlineData("41", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "N3";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "N";
			subject.VesselName = "jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "jk", true)]
	[InlineData("N", "", false)]
	[InlineData("", "jk", false)]
	public void Validation_AllAreRequiredTransportationMethodTypeCode(string transportationMethodTypeCode, string vesselName, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "N3";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		subject.VesselName = vesselName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "41";
			subject.ReferenceIdentification = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
