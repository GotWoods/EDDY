using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class EDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ED*4*v*z*7*l*8*J4lZFF";

		var expected = new ED_EquipmentDescription()
		{
			EquipmentInitial = "4",
			EquipmentNumber = "v",
			LoadEmptyStatusCode = "z",
			CommodityCode = "7",
			LadingDescription = "l",
			WaybillNumber = 8,
			Date = "J4lZFF",
		};

		var actual = Map.MapObject<ED_EquipmentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentNumber = "v";
		subject.LoadEmptyStatusCode = "z";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentInitial = "4";
		subject.LoadEmptyStatusCode = "z";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentInitial = "4";
		subject.EquipmentNumber = "v";
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
