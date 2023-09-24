using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W08Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W08*n*W4*d*M*n*L*0*cO*gH";

		var expected = new W08_ReceiptCarrierInformation()
		{
			TransportationMethodTypeCode = "n",
			StandardCarrierAlphaCode = "W4",
			Routing = "d",
			EquipmentInitial = "M",
			EquipmentNumber = "n",
			SealNumber = "L",
			SealNumber2 = "0",
			SealStatusCode = "cO",
			UnitLoadOptionCode = "gH",
		};

		var actual = Map.MapObject<W08_ReceiptCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("W4","M", true)]
	[InlineData("", "M", true)]
	[InlineData("W4", "", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string equipmentInitial, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		subject.TransportationMethodTypeCode = "n";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.EquipmentInitial = equipmentInitial;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("M", "n", true)]
	[InlineData("", "n", false)]
	[InlineData("M", "", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		subject.TransportationMethodTypeCode = "n";
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
