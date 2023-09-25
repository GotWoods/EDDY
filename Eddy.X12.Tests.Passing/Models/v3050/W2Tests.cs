using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class W2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2*e*A*Z*95*4*7*W*tLD*zT4RgL*EZ*O*X*5*8*1*a";

		var expected = new W2_EquipmentIdentification()
		{
			EquipmentInitial = "e",
			EquipmentNumber = "A",
			CommodityCode = "Z",
			EquipmentDescriptionCode = "95",
			EquipmentStatusCode = "4",
			NetTons = 7,
			IntermodalServiceCode = "W",
			CarServiceOrderCode = "tLD",
			Date = "zT4RgL",
			TypeOfLocomotiveMaintenanceCode = "EZ",
			EquipmentInitial2 = "O",
			EquipmentNumber2 = "X",
			EquipmentNumberCheckDigit = 5,
			Position = "8",
			CarTypeCode = "1",
			YesNoConditionOrResponseCode = "a",
		};

		var actual = Map.MapObject<W2_EquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentNumber = "A";
		subject.EquipmentDescriptionCode = "95";
		subject.EquipmentStatusCode = "4";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "zT4RgL";
			subject.TypeOfLocomotiveMaintenanceCode = "EZ";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "O";
			subject.EquipmentNumber2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "e";
		subject.EquipmentDescriptionCode = "95";
		subject.EquipmentStatusCode = "4";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "zT4RgL";
			subject.TypeOfLocomotiveMaintenanceCode = "EZ";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "O";
			subject.EquipmentNumber2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("95", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "A";
		subject.EquipmentStatusCode = "4";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "zT4RgL";
			subject.TypeOfLocomotiveMaintenanceCode = "EZ";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "O";
			subject.EquipmentNumber2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "A";
		subject.EquipmentDescriptionCode = "95";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "zT4RgL";
			subject.TypeOfLocomotiveMaintenanceCode = "EZ";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "O";
			subject.EquipmentNumber2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zT4RgL", "EZ", true)]
	[InlineData("zT4RgL", "", false)]
	[InlineData("", "EZ", false)]
	public void Validation_AllAreRequiredDate(string date, string typeOfLocomotiveMaintenanceCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "A";
		subject.EquipmentDescriptionCode = "95";
		subject.EquipmentStatusCode = "4";
		//Test Parameters
		subject.Date = date;
		subject.TypeOfLocomotiveMaintenanceCode = typeOfLocomotiveMaintenanceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "O";
			subject.EquipmentNumber2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "X", true)]
	[InlineData("O", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "A";
		subject.EquipmentDescriptionCode = "95";
		subject.EquipmentStatusCode = "4";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "zT4RgL";
			subject.TypeOfLocomotiveMaintenanceCode = "EZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
