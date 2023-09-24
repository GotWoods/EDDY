using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD3*YX*D*r*f*7*yy*C";

		var expected = new TD3_CarrierDetailsEquipment()
		{
			EquipmentDescriptionCode = "YX",
			EquipmentInitial = "D",
			EquipmentNumber = "r",
			WeightQualifier = "f",
			Weight = 7,
			UnitOfMeasurementCode = "yy",
			OwnershipCode = "C",
		};

		var actual = Map.MapObject<TD3_CarrierDetailsEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YX", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "r", true)]
	[InlineData("D", "", false)]
	[InlineData("", "r", true)]
	public void Validation_ARequiresBEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentDescriptionCode = "YX";
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
