using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F02*lM0x7I*O*h*E2*L*I7*5";

		var expected = new F02_IdentificationOfShipment()
		{
			Date = "lM0x7I",
			EquipmentInitial = "O",
			EquipmentNumber = "h",
			ReferenceNumberQualifier = "E2",
			ReferenceNumber = "L",
			ReferenceNumberQualifier2 = "I7",
			ReferenceNumber2 = "5",
		};

		var actual = Map.MapObject<F02_IdentificationOfShipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lM0x7I", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F02_IdentificationOfShipment();
		subject.EquipmentNumber = "h";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new F02_IdentificationOfShipment();
		subject.Date = "lM0x7I";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
