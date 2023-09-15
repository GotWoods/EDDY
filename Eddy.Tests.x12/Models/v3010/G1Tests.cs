using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G1*R*L*z";

		var expected = new G1_ShipmentTypeInformation()
		{
			ShipmentTypeCode = "R",
			SpecialIndicatorCode = "L",
			SpecialIndicatorCode2 = "z",
		};

		var actual = Map.MapObject<G1_ShipmentTypeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredShipmentTypeCode(string shipmentTypeCode, bool isValidExpected)
	{
		var subject = new G1_ShipmentTypeInformation();
		subject.ShipmentTypeCode = shipmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
