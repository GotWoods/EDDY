using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M12*6v*T*G*W*41*h*p0*kO*e*p*3T*J*mqiNJf3Y*v";

		var expected = new M12_InBondIdentifyingInformation()
		{
			CustomsEntryTypeCode = "6v",
			CustomsEntryNumber = "T",
			LocationIdentifier = "G",
			LocationIdentifier2 = "W",
			CustomsShipmentValue = 41,
			InBondControlNumber = "h",
			StandardCarrierAlphaCode = "p0",
			ReferenceIdentificationQualifier = "kO",
			ReferenceIdentification = "e",
			TransportationMethodTypeCode = "p",
			VesselName = "3T",
			YesNoConditionOrResponseCode = "J",
			Date = "mqiNJf3Y",
			LocationIdentifier3 = "v",
		};

		var actual = Map.MapObject<M12_InBondIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6v", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "h", false)]
	[InlineData("", "h", true)]
	[InlineData("T", "", true)]
	public void Validation_OnlyOneOfCustomsEntryNumber(string customsEntryNumber, string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "6v";
		subject.CustomsEntryNumber = customsEntryNumber;
		subject.InBondControlNumber = inBondControlNumber;

		if (inBondControlNumber != "")
		{
			subject.ReferenceIdentificationQualifier = "AA";
			subject.ReferenceIdentification = "AA";
		}

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "kO", true)]
	[InlineData("h", "", false)]
	public void Validation_ARequiresBInBondControlNumber(string inBondControlNumber, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "6v";
		subject.InBondControlNumber = inBondControlNumber;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;

		if (referenceIdentificationQualifier != "")
			subject.ReferenceIdentification = "AA";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("kO", "e", true)]
	[InlineData("", "e", false)]
	[InlineData("kO", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "6v";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("p", "3T", true)]
	[InlineData("", "3T", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredTransportationMethodTypeCode(string transportationMethodTypeCode, string vesselName, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.CustomsEntryTypeCode = "6v";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		subject.VesselName = vesselName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
