using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class EDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ED*s*H*A*5*6*4*q";

		var expected = new ED_EquipmentDescription()
		{
			EquipmentInitial = "s",
			EquipmentNumber = "H",
			LoadEmptyStatusCode = "A",
			CommodityCode = "5",
			LadingDescription = "6",
			WaybillNumber = 4,
			EquipmentNumber2 = "q",
		};

		var actual = Map.MapObject<ED_EquipmentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentNumber = "H";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
