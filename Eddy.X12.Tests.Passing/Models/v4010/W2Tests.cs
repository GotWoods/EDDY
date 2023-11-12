using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class W2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2*G*n*a*jY*R*8*0*VLs*eyIKcgbl*tB*l*F*2*f*8*W";

		var expected = new W2_EquipmentIdentification()
		{
			EquipmentInitial = "G",
			EquipmentNumber = "n",
			CommodityCode = "a",
			EquipmentDescriptionCode = "jY",
			EquipmentStatusCode = "R",
			NetTons = 8,
			IntermodalServiceCode = "0",
			CarServiceOrderCode = "VLs",
			Date = "eyIKcgbl",
			TypeOfLocomotiveMaintenanceCode = "tB",
			EquipmentInitial2 = "l",
			EquipmentNumber2 = "F",
			EquipmentNumberCheckDigit = 2,
			Position = "f",
			CarTypeCode = "8",
			YesNoConditionOrResponseCode = "W",
		};

		var actual = Map.MapObject<W2_EquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentNumber = "n";
		subject.EquipmentDescriptionCode = "jY";
		subject.EquipmentStatusCode = "R";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "eyIKcgbl";
			subject.TypeOfLocomotiveMaintenanceCode = "tB";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.EquipmentDescriptionCode = "jY";
		subject.EquipmentStatusCode = "R";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "eyIKcgbl";
			subject.TypeOfLocomotiveMaintenanceCode = "tB";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jY", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = "n";
		subject.EquipmentStatusCode = "R";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "eyIKcgbl";
			subject.TypeOfLocomotiveMaintenanceCode = "tB";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = "n";
		subject.EquipmentDescriptionCode = "jY";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "eyIKcgbl";
			subject.TypeOfLocomotiveMaintenanceCode = "tB";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eyIKcgbl", "tB", true)]
	[InlineData("eyIKcgbl", "", false)]
	[InlineData("", "tB", false)]
	public void Validation_AllAreRequiredDate(string date, string typeOfLocomotiveMaintenanceCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = "n";
		subject.EquipmentDescriptionCode = "jY";
		subject.EquipmentStatusCode = "R";
		//Test Parameters
		subject.Date = date;
		subject.TypeOfLocomotiveMaintenanceCode = typeOfLocomotiveMaintenanceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "F", true)]
	[InlineData("l", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = "n";
		subject.EquipmentDescriptionCode = "jY";
		subject.EquipmentStatusCode = "R";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "eyIKcgbl";
			subject.TypeOfLocomotiveMaintenanceCode = "tB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
