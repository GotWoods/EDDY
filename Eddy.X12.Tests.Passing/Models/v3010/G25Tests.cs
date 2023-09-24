using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G25Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G25*IV*dS*I";

		var expected = new G25_FOBInformation()
		{
			ShipmentMethodOfPayment = "IV",
			FOBPointCode = "dS",
			FOBPoint = "I",
		};

		var actual = Map.MapObject<G25_FOBInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IV", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new G25_FOBInformation();
		subject.FOBPointCode = "dS";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dS", true)]
	public void Validation_RequiredFOBPointCode(string fOBPointCode, bool isValidExpected)
	{
		var subject = new G25_FOBInformation();
		subject.ShipmentMethodOfPayment = "IV";
		subject.FOBPointCode = fOBPointCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
