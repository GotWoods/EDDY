using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class B12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B12*o*7*WMiK";

		var expected = new B12_BeginningSegmentForConsolidationOfGoodsInContainer()
		{
			EquipmentInitial = "o",
			EquipmentNumber = "7",
			EquipmentTypeCode = "WMiK",
		};

		var actual = Map.MapObject<B12_BeginningSegmentForConsolidationOfGoodsInContainer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		subject.EquipmentNumber = "7";
		subject.EquipmentTypeCode = "WMiK";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		subject.EquipmentInitial = "o";
		subject.EquipmentTypeCode = "WMiK";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WMiK", true)]
	public void Validation_RequiredEquipmentTypeCode(string equipmentTypeCode, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		subject.EquipmentInitial = "o";
		subject.EquipmentNumber = "7";
		subject.EquipmentTypeCode = equipmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
