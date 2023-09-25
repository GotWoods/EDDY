using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class XCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XC*F*S*7*w*n";

		var expected = new XC_EquipmentIdentification()
		{
			EquipmentInitial = "F",
			EquipmentNumber = "S",
			LoadEmptyStatusCode = "7",
			CommodityCode = "w",
			TypeOfConsistCode = "n",
		};

		var actual = Map.MapObject<XC_EquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new XC_EquipmentIdentification();
		//Required fields
		subject.EquipmentNumber = "S";
		subject.LoadEmptyStatusCode = "7";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new XC_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "F";
		subject.LoadEmptyStatusCode = "7";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new XC_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "F";
		subject.EquipmentNumber = "S";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
