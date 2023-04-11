using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G1*F*z*G";

		var expected = new G1_ShipmentTypeInformation()
		{
			ShipmentTypeCode = "F",
			SpecialIndicatorCode = "z",
			SpecialIndicatorCode2 = "G",
		};

		var actual = Map.MapObject<G1_ShipmentTypeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredShipmentTypeCode(string shipmentTypeCode, bool isValidExpected)
	{
		var subject = new G1_ShipmentTypeInformation();
		subject.ShipmentTypeCode = shipmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
