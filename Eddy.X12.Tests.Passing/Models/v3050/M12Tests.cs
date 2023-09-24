using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class M12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M12*Gr*5*o*V*rt*z*YE*6t*C*K*GV";

		var expected = new M12_InBondIdentifyingInformation()
		{
			InBondTypeCode = "Gr",
			EntryNumber = "5",
			LocationIdentifier = "o",
			LocationIdentifier2 = "V",
			CustomsShipmentValue = "rt",
			InBondControlNumber = "z",
			StandardCarrierAlphaCode = "YE",
			ReferenceNumberQualifier = "6t",
			ReferenceNumber = "C",
			TransportationMethodTypeCode = "K",
			VesselName = "GV",
		};

		var actual = Map.MapObject<M12_InBondIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gr", true)]
	public void Validation_RequiredInBondTypeCode(string inBondTypeCode, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = inBondTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "6t";
			subject.ReferenceNumber = "C";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "K";
			subject.VesselName = "GV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "z", false)]
	[InlineData("5", "", true)]
	[InlineData("", "z", true)]
	public void Validation_OnlyOneOfEntryNumber(string entryNumber, string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "Gr";
		subject.EntryNumber = entryNumber;
		subject.InBondControlNumber = inBondControlNumber;
		if (inBondControlNumber != "")
			subject.ReferenceNumberQualifier = "6t";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "6t";
			subject.ReferenceNumber = "C";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "K";
			subject.VesselName = "GV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "6t", true)]
	[InlineData("z", "", false)]
	[InlineData("", "6t", true)]
	public void Validation_ARequiresBInBondControlNumber(string inBondControlNumber, string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "Gr";
		subject.InBondControlNumber = inBondControlNumber;
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "6t";
			subject.ReferenceNumber = "C";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "K";
			subject.VesselName = "GV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6t", "C", true)]
	[InlineData("6t", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "Gr";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.TransportationMethodTypeCode) || !string.IsNullOrEmpty(subject.VesselName))
		{
			subject.TransportationMethodTypeCode = "K";
			subject.VesselName = "GV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "GV", true)]
	[InlineData("K", "", false)]
	[InlineData("", "GV", false)]
	public void Validation_AllAreRequiredTransportationMethodTypeCode(string transportationMethodTypeCode, string vesselName, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "Gr";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		subject.VesselName = vesselName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "6t";
			subject.ReferenceNumber = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
