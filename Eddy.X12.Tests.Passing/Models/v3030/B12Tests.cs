using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class B12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B12*7*3*t0GT";

		var expected = new B12_BeginningSegmentForConsolidationOfGoodsInContainer()
		{
			EquipmentInitial = "7",
			EquipmentNumber = "3",
			EquipmentType = "t0GT",
		};

		var actual = Map.MapObject<B12_BeginningSegmentForConsolidationOfGoodsInContainer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		//Required fields
		subject.EquipmentNumber = "3";
		subject.EquipmentType = "t0GT";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		//Required fields
		subject.EquipmentInitial = "7";
		subject.EquipmentType = "t0GT";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t0GT", true)]
	public void Validation_RequiredEquipmentType(string equipmentType, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		//Required fields
		subject.EquipmentInitial = "7";
		subject.EquipmentNumber = "3";
		//Test Parameters
		subject.EquipmentType = equipmentType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
