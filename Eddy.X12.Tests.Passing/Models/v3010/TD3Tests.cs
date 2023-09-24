using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD3*TX*q*6*5*8*MV*U";

		var expected = new TD3_CarrierDetailsEquipment()
		{
			EquipmentDescriptionCode = "TX",
			EquipmentInitial = "q",
			EquipmentNumber = "6",
			WeightQualifier = "5",
			Weight = 8,
			UnitOfMeasurementCode = "MV",
			OwnershipCode = "U",
		};

		var actual = Map.MapObject<TD3_CarrierDetailsEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TX", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
