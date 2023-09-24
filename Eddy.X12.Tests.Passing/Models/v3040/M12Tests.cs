using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class M12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M12*Rz*l*h*N*Al*U*YN*Go*J*g*aM";

		var expected = new M12_InBondIdentifyingInformation()
		{
			InBondTypeCode = "Rz",
			EntryNumber = "l",
			LocationIdentifier = "h",
			LocationIdentifier2 = "N",
			CustomsShipmentValue = "Al",
			InBondControlNumber = "U",
			StandardCarrierAlphaCode = "YN",
			ReferenceNumberQualifier = "Go",
			ReferenceNumber = "J",
			TransportationMethodTypeCode = "g",
			VesselName = "aM",
		};

		var actual = Map.MapObject<M12_InBondIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rz", true)]
	public void Validation_RequiredInBondTypeCode(string inBondTypeCode, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = inBondTypeCode;
			subject.EntryNumber = "l";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Go";
			subject.ReferenceNumber = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "g";
			subject.VesselName = "aM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("l", "U", true)]
	[InlineData("l", "", true)]
	[InlineData("", "U", true)]
	public void Validation_AtLeastOneEntryNumber(string entryNumber, string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "Rz";
		subject.EntryNumber = entryNumber;
		subject.InBondControlNumber = inBondControlNumber;
		if (inBondControlNumber != "")
			subject.ReferenceNumberQualifier = "Go";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Go";
			subject.ReferenceNumber = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "g";
			subject.VesselName = "aM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "Go", true)]
	[InlineData("U", "", false)]
	[InlineData("", "Go", true)]
	public void Validation_ARequiresBInBondControlNumber(string inBondControlNumber, string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "Rz";
		subject.InBondControlNumber = inBondControlNumber;
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
			subject.EntryNumber = "l";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Go";
			subject.ReferenceNumber = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "g";
			subject.VesselName = "aM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Go", "J", true)]
	[InlineData("Go", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "Rz";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
			subject.EntryNumber = "l";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "g";
			subject.VesselName = "aM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "aM", true)]
	[InlineData("g", "", false)]
	[InlineData("", "aM", false)]
	public void Validation_AllAreRequiredTransportationMethodTypeCode(string transportationMethodTypeCode, string vesselName, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "Rz";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		subject.VesselName = vesselName;
			subject.EntryNumber = "l";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Go";
			subject.ReferenceNumber = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
