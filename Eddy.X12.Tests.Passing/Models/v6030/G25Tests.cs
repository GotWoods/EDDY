using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class G25Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G25*v1*GJ*D";

		var expected = new G25_FOBInformation()
		{
			ShipmentMethodOfPaymentCode = "v1",
			FOBPointCode = "GJ",
			FOBPoint = "D",
		};

		var actual = Map.MapObject<G25_FOBInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v1", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new G25_FOBInformation();
		subject.FOBPointCode = "GJ";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GJ", true)]
	public void Validation_RequiredFOBPointCode(string fOBPointCode, bool isValidExpected)
	{
		var subject = new G25_FOBInformation();
		subject.ShipmentMethodOfPaymentCode = "v1";
		subject.FOBPointCode = fOBPointCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
