using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M12*kU*R*M*P*60*L*eG*GL*S";

		var expected = new M12_InBondIdentifyingInformation()
		{
			InBondTypeCode = "kU",
			EntryNumber = "R",
			LocationIdentifier = "M",
			LocationIdentifier2 = "P",
			CustomsShipmentValue = "60",
			InBondControlNumber = "L",
			StandardCarrierAlphaCode = "eG",
			ReferenceNumberQualifier = "GL",
			ReferenceNumber = "S",
		};

		var actual = Map.MapObject<M12_InBondIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kU", true)]
	public void Validation_RequiredInBondTypeCode(string inBondTypeCode, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.LocationIdentifier = "M";
		subject.CustomsShipmentValue = "60";
		subject.InBondTypeCode = inBondTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "kU";
		subject.CustomsShipmentValue = "60";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("60", true)]
	public void Validation_RequiredCustomsShipmentValue(string customsShipmentValue, bool isValidExpected)
	{
		var subject = new M12_InBondIdentifyingInformation();
		subject.InBondTypeCode = "kU";
		subject.LocationIdentifier = "M";
		subject.CustomsShipmentValue = customsShipmentValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
