using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2*m*V*l*t0*j*2*d*4hR*NCDiuizh*3N*i*q*9*8*s*O*q*L";

		var expected = new W2_EquipmentIdentification()
		{
			EquipmentInitial = "m",
			EquipmentNumber = "V",
			CommodityCode = "l",
			EquipmentDescriptionCode = "t0",
			EquipmentStatusCode = "j",
			NetTons = 2,
			IntermodalServiceCode = "d",
			CarServiceOrderCode = "4hR",
			Date = "NCDiuizh",
			TypeOfLocomotiveMaintenanceCode = "3N",
			EquipmentInitial2 = "i",
			EquipmentNumber2 = "q",
			EquipmentNumberCheckDigit = 9,
			Position = "8",
			CarTypeCode = "s",
			YesNoConditionOrResponseCode = "O",
			TagStatusCode = "q",
			EquipmentOrientationCode = "L",
		};

		var actual = Map.MapObject<W2_EquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		subject.EquipmentNumber = "V";
		subject.EquipmentDescriptionCode = "t0";
		subject.EquipmentStatusCode = "j";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		subject.EquipmentInitial = "m";
		subject.EquipmentDescriptionCode = "t0";
		subject.EquipmentStatusCode = "j";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t0", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "V";
		subject.EquipmentStatusCode = "j";
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "V";
		subject.EquipmentDescriptionCode = "t0";
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("NCDiuizh", "3N", true)]
	[InlineData("", "3N", false)]
	[InlineData("NCDiuizh", "", false)]
	public void Validation_AllAreRequiredDate(string date, string typeOfLocomotiveMaintenanceCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "V";
		subject.EquipmentDescriptionCode = "t0";
		subject.EquipmentStatusCode = "j";
		subject.Date = date;
		subject.TypeOfLocomotiveMaintenanceCode = typeOfLocomotiveMaintenanceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("i", "q", true)]
	[InlineData("", "q", false)]
	[InlineData("i", "", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "V";
		subject.EquipmentDescriptionCode = "t0";
		subject.EquipmentStatusCode = "j";
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
