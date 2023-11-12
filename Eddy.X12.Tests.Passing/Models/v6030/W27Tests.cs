using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class W27Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W27*I*R1*f*0W*hC*M*X*bX*pl*Mr";

		var expected = new W27_CarrierDetailsWarehouse()
		{
			TransportationMethodTypeCode = "I",
			StandardCarrierAlphaCode = "R1",
			Routing = "f",
			ShipmentMethodOfPaymentCode = "0W",
			EquipmentDescriptionCode = "hC",
			EquipmentInitial = "M",
			EquipmentNumber = "X",
			ShipmentOrderStatusCode = "bX",
			SpecialHandlingCode = "pl",
			CarrierRouteChangeReasonCode = "Mr",
		};

		var actual = Map.MapObject<W27_CarrierDetailsWarehouse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W27_CarrierDetailsWarehouse();
		//Required fields
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//At Least one
		subject.StandardCarrierAlphaCode = "R1";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("R1", "f", true)]
	[InlineData("R1", "", true)]
	[InlineData("", "f", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string routing, bool isValidExpected)
	{
		var subject = new W27_CarrierDetailsWarehouse();
		//Required fields
		subject.TransportationMethodTypeCode = "I";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.Routing = routing;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
