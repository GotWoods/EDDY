using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class W27Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W27*D*9X*3*o1*Ao*M*o*hW*Us*iq";

		var expected = new W27_CarrierDetail()
		{
			TransportationMethodTypeCode = "D",
			StandardCarrierAlphaCode = "9X",
			Routing = "3",
			ShipmentMethodOfPayment = "o1",
			EquipmentDescriptionCode = "Ao",
			EquipmentInitial = "M",
			EquipmentNumber = "o",
			ShipmentOrderStatusCode = "hW",
			SpecialHandlingCode = "Us",
			CarrierRouteChangeReasonCode = "iq",
		};

		var actual = Map.MapObject<W27_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W27_CarrierDetail();
		//Required fields
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//At Least one
		subject.StandardCarrierAlphaCode = "9X";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9X", "3", true)]
	[InlineData("9X", "", true)]
	[InlineData("", "3", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string routing, bool isValidExpected)
	{
		var subject = new W27_CarrierDetail();
		//Required fields
		subject.TransportationMethodTypeCode = "D";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.Routing = routing;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
