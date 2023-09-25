using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class W08Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W08*Y*sx*e*4*E*G*3*2O*mY";

		var expected = new W08_ReceiptCarrierInformation()
		{
			TransportationMethodTypeCode = "Y",
			StandardCarrierAlphaCode = "sx",
			Routing = "e",
			EquipmentInitial = "4",
			EquipmentNumber = "E",
			SealNumber = "G",
			SealNumber2 = "3",
			SealStatusCode = "2O",
			UnitLoadOptionCode = "mY",
		};

		var actual = Map.MapObject<W08_ReceiptCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//At Least one
		subject.StandardCarrierAlphaCode = "sx";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "4";
			subject.EquipmentNumber = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("sx", "4", true)]
	[InlineData("sx", "", true)]
	[InlineData("", "4", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string equipmentInitial, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "Y";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "4";
			subject.EquipmentNumber = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "E", true)]
	[InlineData("4", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "Y";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//At Least one
		subject.StandardCarrierAlphaCode = "sx";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
