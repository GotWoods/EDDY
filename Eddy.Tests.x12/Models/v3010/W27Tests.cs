using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W27Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W27*q*ky*E*B9*Gq*G*r*7D*N5*Ec";

		var expected = new W27_CarrierDetail()
		{
			TransportationMethodTypeCode = "q",
			StandardCarrierAlphaCode = "ky",
			Routing = "E",
			ShipmentMethodOfPayment = "B9",
			EquipmentDescriptionCode = "Gq",
			EquipmentInitial = "G",
			EquipmentNumber = "r",
			ShipmentOrderStatusCode = "7D",
			SpecialHandlingCode = "N5",
			CarrierRouteChangeReasonCode = "Ec",
		};

		var actual = Map.MapObject<W27_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W27_CarrierDetail();
		//Required fields
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
