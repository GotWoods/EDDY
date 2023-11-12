using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class W2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2*6*X*E*N7*v*9*Q*AIN*FtEAdXpB*M6*6*S*5*Z*D*o*H*G";

		var expected = new W2_EquipmentIdentification()
		{
			EquipmentInitial = "6",
			EquipmentNumber = "X",
			CommodityCode = "E",
			EquipmentDescriptionCode = "N7",
			EquipmentStatusCode = "v",
			NetTons = 9,
			IntermodalServiceCode = "Q",
			CarServiceOrderCode = "AIN",
			Date = "FtEAdXpB",
			TypeOfLocomotiveMaintenanceCode = "M6",
			EquipmentInitial2 = "6",
			EquipmentNumber2 = "S",
			EquipmentNumberCheckDigit = 5,
			Position = "Z",
			CarTypeCode = "D",
			YesNoConditionOrResponseCode = "o",
			TagStatusCode = "H",
			EquipmentOrientationCode = "G",
		};

		var actual = Map.MapObject<W2_EquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentNumber = "X";
		subject.EquipmentDescriptionCode = "N7";
		subject.EquipmentStatusCode = "v";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "FtEAdXpB";
			subject.TypeOfLocomotiveMaintenanceCode = "M6";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "6";
		subject.EquipmentDescriptionCode = "N7";
		subject.EquipmentStatusCode = "v";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "FtEAdXpB";
			subject.TypeOfLocomotiveMaintenanceCode = "M6";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N7", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "6";
		subject.EquipmentNumber = "X";
		subject.EquipmentStatusCode = "v";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "FtEAdXpB";
			subject.TypeOfLocomotiveMaintenanceCode = "M6";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "6";
		subject.EquipmentNumber = "X";
		subject.EquipmentDescriptionCode = "N7";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "FtEAdXpB";
			subject.TypeOfLocomotiveMaintenanceCode = "M6";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("FtEAdXpB", "M6", true)]
	[InlineData("FtEAdXpB", "", false)]
	[InlineData("", "M6", false)]
	public void Validation_AllAreRequiredDate(string date, string typeOfLocomotiveMaintenanceCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "6";
		subject.EquipmentNumber = "X";
		subject.EquipmentDescriptionCode = "N7";
		subject.EquipmentStatusCode = "v";
		//Test Parameters
		subject.Date = date;
		subject.TypeOfLocomotiveMaintenanceCode = typeOfLocomotiveMaintenanceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "S", true)]
	[InlineData("6", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "6";
		subject.EquipmentNumber = "X";
		subject.EquipmentDescriptionCode = "N7";
		subject.EquipmentStatusCode = "v";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "FtEAdXpB";
			subject.TypeOfLocomotiveMaintenanceCode = "M6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
