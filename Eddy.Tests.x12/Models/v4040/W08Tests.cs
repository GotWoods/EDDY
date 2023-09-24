using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class W08Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W08*b*FI*y*I*G*i4*fm*6X*6n";

		var expected = new W08_ReceiptCarrierInformation()
		{
			TransportationMethodTypeCode = "b",
			StandardCarrierAlphaCode = "FI",
			Routing = "y",
			EquipmentInitial = "I",
			EquipmentNumber = "G",
			SealNumber = "i4",
			SealNumber2 = "fm",
			SealStatusCode = "6X",
			UnitLoadOptionCode = "6n",
		};

		var actual = Map.MapObject<W08_ReceiptCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//At Least one
		subject.StandardCarrierAlphaCode = "FI";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "I";
			subject.EquipmentNumber = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("FI", "I", true)]
	[InlineData("FI", "", true)]
	[InlineData("", "I", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string equipmentInitial, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "b";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "I";
			subject.EquipmentNumber = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "G", true)]
	[InlineData("I", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "b";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//At Least one
		subject.StandardCarrierAlphaCode = "FI";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
