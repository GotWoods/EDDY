using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G25Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G25*fI*RT*N";

		var expected = new G25_FOBInformation()
		{
			ShipmentMethodOfPaymentCode = "fI",
			FOBPointCode = "RT",
			FOBPoint = "N",
		};

		var actual = Map.MapObject<G25_FOBInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fI", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new G25_FOBInformation();
		subject.FOBPointCode = "RT";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RT", true)]
	public void Validation_RequiredFOBPointCode(string fOBPointCode, bool isValidExpected)
	{
		var subject = new G25_FOBInformation();
		subject.ShipmentMethodOfPaymentCode = "fI";
		subject.FOBPointCode = fOBPointCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
