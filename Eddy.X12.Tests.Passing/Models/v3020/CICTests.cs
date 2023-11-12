using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CIC*x*J*Fiek";

		var expected = new CIC_CarInformationControl()
		{
			EquipmentInitial = "x",
			EquipmentNumber = "J",
			CarTypeCode = "Fiek",
		};

		var actual = Map.MapObject<CIC_CarInformationControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CIC_CarInformationControl();
		//Required fields
		subject.EquipmentNumber = "J";
		subject.CarTypeCode = "Fiek";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CIC_CarInformationControl();
		//Required fields
		subject.EquipmentInitial = "x";
		subject.CarTypeCode = "Fiek";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fiek", true)]
	public void Validation_RequiredCarTypeCode(string carTypeCode, bool isValidExpected)
	{
		var subject = new CIC_CarInformationControl();
		//Required fields
		subject.EquipmentInitial = "x";
		subject.EquipmentNumber = "J";
		//Test Parameters
		subject.CarTypeCode = carTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
