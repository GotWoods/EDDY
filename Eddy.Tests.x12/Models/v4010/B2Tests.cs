using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class B2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B2*TA*is*6AonyE*T*5*a8*A*3*q*OA*DHn*cmD";

		var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
		{
			TariffServiceCode = "TA",
			StandardCarrierAlphaCode = "is",
			StandardPointLocationCode = "6AonyE",
			ShipmentIdentificationNumber = "T",
			WeightUnitCode = "5",
			ShipmentMethodOfPayment = "a8",
			ShipmentQualifier = "A",
			TotalEquipment = 3,
			ShipmentWeightCode = "q",
			CustomsDocumentationHandlingCode = "OA",
			TransportationTermsCode = "DHn",
			PaymentMethodCode = "cmD",
		};

		var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a8", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
