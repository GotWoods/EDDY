using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class EDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ED*P*s*p*6*6*8*S*hfYfexGG";

		var expected = new ED_EquipmentDescription()
		{
			EquipmentInitial = "P",
			EquipmentNumber = "s",
			LoadEmptyStatusCode = "p",
			CommodityCode = "6",
			LadingDescription = "6",
			WaybillNumber = 8,
			EquipmentNumber2 = "S",
			Date = "hfYfexGG",
		};

		var actual = Map.MapObject<ED_EquipmentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentNumber = "s";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
