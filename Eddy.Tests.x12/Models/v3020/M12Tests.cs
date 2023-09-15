using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class M12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M12*nX*0*P*E*HS*t*Rl*OV*r";

		var expected = new M12_InBondIdentifyingInformation()
		{
			InBondTypeCode = "nX",
			EntryNumber = "0",
			LocationIdentifier = "P",
			LocationIdentifier2 = "E",
			CustomsShipmentValue = "HS",
			InBondControlNumber = "t",
			StandardCarrierAlphaCode = "Rl",
			ReferenceNumberQualifier = "OV",
			ReferenceNumber = "r",
		};

		var actual = Map.MapObject<M12_InBondIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nX", true)]
	public void Validation_RequiredInBondTypeCode(string inBondTypeCode, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.LocationIdentifier = "P";
		subject.CustomsShipmentValue = "HS";
		subject.InBondTypeCode = inBondTypeCode;
			subject.EntryNumber = "0";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "OV";
			subject.ReferenceNumber = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("0", "t", true)]
	[InlineData("0", "", true)]
	[InlineData("", "t", true)]
	public void Validation_AtLeastOneEntryNumber(string entryNumber, string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "nX";
		subject.LocationIdentifier = "P";
		subject.CustomsShipmentValue = "HS";
		subject.EntryNumber = entryNumber;
		subject.InBondControlNumber = inBondControlNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "OV";
			subject.ReferenceNumber = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "nX";
		subject.CustomsShipmentValue = "HS";
		subject.LocationIdentifier = locationIdentifier;
			subject.EntryNumber = "0";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "OV";
			subject.ReferenceNumber = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HS", true)]
	public void Validation_RequiredCustomsShipmentValue(string customsShipmentValue, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "nX";
		subject.LocationIdentifier = "P";
		subject.CustomsShipmentValue = customsShipmentValue;
			subject.EntryNumber = "0";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "OV";
			subject.ReferenceNumber = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("OV", "r", true)]
	[InlineData("OV", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "nX";
		subject.LocationIdentifier = "P";
		subject.CustomsShipmentValue = "HS";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
			subject.EntryNumber = "0";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
