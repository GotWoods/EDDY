using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class B12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B12*s*n*8oKh";

		var expected = new B12_BeginningSegmentForConsolidationOfGoodsInContainer()
		{
			EquipmentInitial = "s",
			EquipmentNumber = "n",
			EquipmentTypeCode = "8oKh",
		};

		var actual = Map.MapObject<B12_BeginningSegmentForConsolidationOfGoodsInContainer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		//Required fields
		subject.EquipmentNumber = "n";
		subject.EquipmentTypeCode = "8oKh";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		//Required fields
		subject.EquipmentInitial = "s";
		subject.EquipmentTypeCode = "8oKh";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8oKh", true)]
	public void Validation_RequiredEquipmentTypeCode(string equipmentTypeCode, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		//Required fields
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "n";
		//Test Parameters
		subject.EquipmentTypeCode = equipmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
