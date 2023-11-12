using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W08Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W08*0*9r*g*n*F*JB*ej*ph*1M";

		var expected = new W08_ReceiptCarrierInformation()
		{
			TransportationMethodTypeCode = "0",
			StandardCarrierAlphaCode = "9r",
			Routing = "g",
			EquipmentInitial = "n",
			EquipmentNumber = "F",
			SealNumber = "JB",
			SealNumber2 = "ej",
			SealStatusCode = "ph",
			UnitLoadOptionCode = "1M",
		};

		var actual = Map.MapObject<W08_ReceiptCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//At Least one
		subject.StandardCarrierAlphaCode = "9r";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "n";
			subject.EquipmentNumber = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9r", "n", true)]
	[InlineData("9r", "", true)]
	[InlineData("", "n", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string equipmentInitial, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "0";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "n";
			subject.EquipmentNumber = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "F", true)]
	[InlineData("n", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "0";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//At Least one
		subject.StandardCarrierAlphaCode = "9r";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
