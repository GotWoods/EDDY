using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class N7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7*P*L*4*R*953*44*9*5*H*d*3z*6*5P8*b*8176*V*f*1*Ql*7*6*JwQ7";

		var expected = new N7_EquipmentDetails()
		{
			EquipmentInitial = "P",
			EquipmentNumber = "L",
			Weight = 4,
			WeightQualifier = "R",
			TareWeight = 953,
			WeightAllowance = 44,
			Dunnage = 9,
			Volume = 5,
			VolumeUnitQualifier = "H",
			OwnershipCode = "d",
			EquipmentDescriptionCode = "3z",
			EquipmentOwnerCode = "6",
			TemperatureControl = "5P8",
			Position = "b",
			EquipmentLength = 8176,
			TareQualifierCode = "V",
			WeightUnitQualifier = "f",
			EquipmentNumberCheckDigit = 1,
			TypeOfServiceCode = "Ql",
			Height = 7,
			Width = 6,
			EquipmentType = "JwQ7",
		};

		var actual = Map.MapObject<N7_EquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new N7_EquipmentDetails();
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
