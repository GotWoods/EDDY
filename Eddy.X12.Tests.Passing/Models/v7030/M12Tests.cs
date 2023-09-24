using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class M12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M12*jc*K*C*7*PL*1*F0*8O*U*u*9G*N*AaJRmwAb*O";

		var expected = new M12_InBondIdentifyingInformation()
		{
			CustomsEntryTypeCode = "jc",
			CustomsEntryNumber = "K",
			LocationIdentifier = "C",
			LocationIdentifier2 = "7",
			CustomsShipmentValue = "PL",
			InBondControlNumber = "1",
			StandardCarrierAlphaCode = "F0",
			ReferenceIdentificationQualifier = "8O",
			ReferenceIdentification = "U",
			TransportationMethodTypeCode = "u",
			VesselName = "9G",
			YesNoConditionOrResponseCode = "N",
			Date = "AaJRmwAb",
			LocationIdentifier3 = "O",
		};

		var actual = Map.MapObject<M12_InBondIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jc", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "8O";
			subject.ReferenceIdentification = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "u";
			subject.VesselName = "9G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "1", false)]
	[InlineData("K", "", true)]
	[InlineData("", "1", true)]
	public void Validation_OnlyOneOfCustomsEntryNumber(string customsEntryNumber, string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "jc";
		subject.CustomsEntryNumber = customsEntryNumber;
		subject.InBondControlNumber = inBondControlNumber;
		if (inBondControlNumber != "")
			subject.ReferenceIdentificationQualifier = "8O";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "8O";
			subject.ReferenceIdentification = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "u";
			subject.VesselName = "9G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "8O", true)]
	[InlineData("1", "", false)]
	[InlineData("", "8O", true)]
	public void Validation_ARequiresBInBondControlNumber(string inBondControlNumber, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "jc";
		subject.InBondControlNumber = inBondControlNumber;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "8O";
			subject.ReferenceIdentification = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "u";
			subject.VesselName = "9G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8O", "U", true)]
	[InlineData("8O", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "jc";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "u";
			subject.VesselName = "9G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "9G", true)]
	[InlineData("u", "", false)]
	[InlineData("", "9G", false)]
	public void Validation_AllAreRequiredTransportationMethodTypeCode(string transportationMethodTypeCode, string vesselName, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "jc";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		subject.VesselName = vesselName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "8O";
			subject.ReferenceIdentification = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
