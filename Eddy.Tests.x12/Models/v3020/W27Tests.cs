using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W27Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W27*W*eo*m*RR*Ct*c*x*Cx*5l*B6";

		var expected = new W27_CarrierDetail()
		{
			TransportationMethodTypeCode = "W",
			StandardCarrierAlphaCode = "eo",
			Routing = "m",
			ShipmentMethodOfPayment = "RR",
			EquipmentDescriptionCode = "Ct",
			EquipmentInitial = "c",
			EquipmentNumber = "x",
			ShipmentOrderStatusCode = "Cx",
			SpecialHandlingCode = "5l",
			CarrierRouteChangeReasonCode = "B6",
		};

		var actual = Map.MapObject<W27_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W27_CarrierDetail();
		//Required fields
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//At Least one
		subject.StandardCarrierAlphaCode = "eo";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("eo", "m", true)]
	[InlineData("eo", "", true)]
	[InlineData("", "m", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string routing, bool isValidExpected)
	{
		var subject = new W27_CarrierDetail();
		//Required fields
		subject.TransportationMethodTypeCode = "W";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.Routing = routing;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
