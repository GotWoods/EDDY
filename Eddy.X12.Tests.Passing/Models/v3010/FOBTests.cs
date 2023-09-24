using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class FOBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FOB*Vq*k*V*h3*2SR*j*U*85*S";

		var expected = new FOB_FOBRelatedInstructions()
		{
			ShipmentMethodOfPayment = "Vq",
			LocationQualifier = "k",
			Description = "V",
			TransportationTermsQualifierCode = "h3",
			TransportationTermsCode = "2SR",
			LocationQualifier2 = "j",
			Description2 = "U",
			RiskOfLossQualifier = "85",
			Description3 = "S",
		};

		var actual = Map.MapObject<FOB_FOBRelatedInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vq", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
