using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class B12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B12*n*I*vbno";

		var expected = new B12_BeginningSegmentForConsolidationOfGoodsInContainer()
		{
			EquipmentInitial = "n",
			EquipmentNumber = "I",
			EquipmentType = "vbno",
		};

		var actual = Map.MapObject<B12_BeginningSegmentForConsolidationOfGoodsInContainer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		//Required fields
		subject.EquipmentNumber = "I";
		subject.EquipmentType = "vbno";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		//Required fields
		subject.EquipmentInitial = "n";
		subject.EquipmentType = "vbno";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vbno", true)]
	public void Validation_RequiredEquipmentType(string equipmentType, bool isValidExpected)
	{
		var subject = new B12_BeginningSegmentForConsolidationOfGoodsInContainer();
		//Required fields
		subject.EquipmentInitial = "n";
		subject.EquipmentNumber = "I";
		//Test Parameters
		subject.EquipmentType = equipmentType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
