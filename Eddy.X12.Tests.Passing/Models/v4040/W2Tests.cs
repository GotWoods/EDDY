using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class W2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2*F*G*c*2F*A*4*g*pwD*Kf4phCl2*Qq*8*4*2*H*U*r";

		var expected = new W2_EquipmentIdentification()
		{
			EquipmentInitial = "F",
			EquipmentNumber = "G",
			CommodityCode = "c",
			EquipmentDescriptionCode = "2F",
			EquipmentStatusCode = "A",
			NetTons = 4,
			IntermodalServiceCode = "g",
			CarServiceOrderCode = "pwD",
			Date = "Kf4phCl2",
			TypeOfLocomotiveMaintenanceCode = "Qq",
			EquipmentInitial2 = "8",
			EquipmentNumber2 = "4",
			EquipmentNumberCheckDigit = 2,
			Position = "H",
			CarTypeCode = "U",
			YesNoConditionOrResponseCode = "r",
		};

		var actual = Map.MapObject<W2_EquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentNumber = "G";
		subject.EquipmentDescriptionCode = "2F";
		subject.EquipmentStatusCode = "A";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "Kf4phCl2";
			subject.TypeOfLocomotiveMaintenanceCode = "Qq";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "8";
			subject.EquipmentNumber2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "F";
		subject.EquipmentDescriptionCode = "2F";
		subject.EquipmentStatusCode = "A";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "Kf4phCl2";
			subject.TypeOfLocomotiveMaintenanceCode = "Qq";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "8";
			subject.EquipmentNumber2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2F", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "F";
		subject.EquipmentNumber = "G";
		subject.EquipmentStatusCode = "A";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "Kf4phCl2";
			subject.TypeOfLocomotiveMaintenanceCode = "Qq";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "8";
			subject.EquipmentNumber2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "F";
		subject.EquipmentNumber = "G";
		subject.EquipmentDescriptionCode = "2F";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "Kf4phCl2";
			subject.TypeOfLocomotiveMaintenanceCode = "Qq";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "8";
			subject.EquipmentNumber2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Kf4phCl2", "Qq", true)]
	[InlineData("Kf4phCl2", "", false)]
	[InlineData("", "Qq", false)]
	public void Validation_AllAreRequiredDate(string date, string typeOfLocomotiveMaintenanceCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "F";
		subject.EquipmentNumber = "G";
		subject.EquipmentDescriptionCode = "2F";
		subject.EquipmentStatusCode = "A";
		//Test Parameters
		subject.Date = date;
		subject.TypeOfLocomotiveMaintenanceCode = typeOfLocomotiveMaintenanceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "8";
			subject.EquipmentNumber2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "4", true)]
	[InlineData("8", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "F";
		subject.EquipmentNumber = "G";
		subject.EquipmentDescriptionCode = "2F";
		subject.EquipmentStatusCode = "A";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "Kf4phCl2";
			subject.TypeOfLocomotiveMaintenanceCode = "Qq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
