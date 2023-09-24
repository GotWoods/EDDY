using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W27Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W27*y*j4*K*18*8n*M*3*DM*Yh*os";

		var expected = new W27_CarrierDetailsWarehouse()
		{
			TransportationMethodTypeCode = "y",
			StandardCarrierAlphaCode = "j4",
			Routing = "K",
			ShipmentMethodOfPaymentCode = "18",
			EquipmentDescriptionCode = "8n",
			EquipmentInitial = "M",
			EquipmentNumber = "3",
			ShipmentOrderStatusCode = "DM",
			SpecialHandlingCode = "Yh",
			CarrierRouteChangeReasonCode = "os",
		};

		var actual = Map.MapObject<W27_CarrierDetailsWarehouse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W27_CarrierDetailsWarehouse();
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("j4","K", true)]
	[InlineData("", "K", true)]
	[InlineData("j4", "", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string routing, bool isValidExpected)
	{
		var subject = new W27_CarrierDetailsWarehouse();
		subject.TransportationMethodTypeCode = "y";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.Routing = routing;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
